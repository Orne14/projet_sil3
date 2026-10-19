Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms

Module BaseEtudiants
    Private Function OuvrirConnexion() As OleDbConnection
        Dim chemin As String = Application.StartupPath & "\etudiants.accdb"

        If Not File.Exists(chemin) Then
            MessageBox.Show("Le fichier etudiants.accdb est introuvable a cote du programme.",
                            "Base de donnees", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End If

        Dim fournisseurs() As String = {"Microsoft.ACE.OLEDB.16.0", "Microsoft.ACE.OLEDB.12.0"}

        For Each fournisseur As String In fournisseurs
            Dim connexion As New OleDbConnection(
                "Provider=" & fournisseur & ";Data Source=" & chemin & ";Persist Security Info=False;")

            Try
                connexion.Open()
                Return connexion
            Catch ex As Exception
                connexion.Dispose()
            End Try
        Next

        MessageBox.Show("Aucun fournisseur Access ACE 16.0 ou 12.0 n'a pu ouvrir la base. Installez le moteur Access Database Engine.",
                        "Fournisseur Access absent", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return Nothing
    End Function

    Public Function AssurerTable() As Boolean
        Dim connexion As OleDbConnection = OuvrirConnexion()
        If connexion Is Nothing Then
            Return False
        End If

        Try
            Dim tables As DataTable = connexion.GetSchema("Tables")
            Dim tableExiste As Boolean = False

            For Each ligne As DataRow In tables.Rows
                If String.Equals(ligne("TABLE_NAME").ToString(), "Etudiants",
                                 StringComparison.OrdinalIgnoreCase) Then
                    tableExiste = True
                End If
            Next

            If Not tableExiste Then
                Dim sql As String = "CREATE TABLE [Etudiants] (" &
                    "[IdEtudiant] COUNTER CONSTRAINT [PK_Etudiants] PRIMARY KEY, " &
                    "[Nom] TEXT(50), [NoteTC] DOUBLE, [NoteSpe] DOUBLE, " &
                    "[NoteEPP] DOUBLE, [Moyenne] DOUBLE, [Rang] INTEGER)"

                Using commande As New OleDbCommand(sql, connexion)
                    commande.ExecuteNonQuery()
                End Using
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show("Impossible de verifier ou de creer la table Etudiants.",
                            "Base de donnees", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            connexion.Close()
        End Try
    End Function

    Public Function AjouterEtudiant(nom As String, noteTC As Double,
                                    noteSpe As Double, noteEPP As Double,
                                    moyenne As Double) As Boolean
        Dim connexion As OleDbConnection = OuvrirConnexion()
        If connexion Is Nothing Then
            Return False
        End If

        Try
            Dim sql As String = "INSERT INTO [Etudiants] " &
                "([Nom], [NoteTC], [NoteSpe], [NoteEPP], [Moyenne], [Rang]) " &
                "VALUES (?, ?, ?, ?, ?, ?)"

            Using commande As New OleDbCommand(sql, connexion)
                commande.Parameters.Add("?", OleDbType.VarWChar, 50).Value = nom
                commande.Parameters.Add("?", OleDbType.Double).Value = noteTC
                commande.Parameters.Add("?", OleDbType.Double).Value = noteSpe
                commande.Parameters.Add("?", OleDbType.Double).Value = noteEPP
                commande.Parameters.Add("?", OleDbType.Double).Value = moyenne
                commande.Parameters.Add("?", OleDbType.Integer).Value = 0
                commande.ExecuteNonQuery()
            End Using

            RecalculerRangs(connexion)
            Return True
        Catch ex As Exception
            MessageBox.Show("Impossible d'enregistrer l'etudiant ou de recalculer les rangs.",
                            "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            connexion.Close()
        End Try
    End Function

    Private Sub RecalculerRangs(connexion As OleDbConnection)
        Dim sqlLecture As String = "SELECT [IdEtudiant], [Moyenne] FROM [Etudiants] " &
            "ORDER BY [Moyenne] DESC, [IdEtudiant] ASC"
        Dim donnees As New DataTable()

        Using commandeLecture As New OleDbCommand(sqlLecture, connexion)
            Using adaptateur As New OleDbDataAdapter(commandeLecture)
                adaptateur.Fill(donnees)
            End Using
        End Using

        Dim position As Integer = 0
        Dim rang As Integer = 0
        Dim moyennePrecedente As Double = 0

        Using commandeMaj As New OleDbCommand(
            "UPDATE [Etudiants] SET [Rang] = ? WHERE [IdEtudiant] = ?", connexion)
            For Each ligne As DataRow In donnees.Rows
                position = position + 1
                Dim moyenneCourante As Double = CDbl(ligne("Moyenne"))

                If position = 1 OrElse moyenneCourante <> moyennePrecedente Then
                    rang = position
                End If

                commandeMaj.Parameters.Clear()
                commandeMaj.Parameters.Add("?", OleDbType.Integer).Value = rang
                commandeMaj.Parameters.Add("?", OleDbType.Integer).Value = CInt(ligne("IdEtudiant"))
                commandeMaj.ExecuteNonQuery()
                moyennePrecedente = moyenneCourante
            Next
        End Using
    End Sub

    Public Function ChargerEtudiants() As DataTable
        Dim connexion As OleDbConnection = OuvrirConnexion()
        If connexion Is Nothing Then
            Return Nothing
        End If

        Try
            Dim sql As String = "SELECT [IdEtudiant], [Rang], [Nom], [NoteTC], " &
                "[NoteSpe], [NoteEPP], [Moyenne] FROM [Etudiants] " &
                "ORDER BY [Moyenne] DESC"
            Dim donnees As New DataTable()

            Using adaptateur As New OleDbDataAdapter(sql, connexion)
                adaptateur.Fill(donnees)
            End Using

            donnees.Columns.Add("MentionTC", GetType(String))
            donnees.Columns.Add("MentionSpe", GetType(String))
            donnees.Columns.Add("MentionEPP", GetType(String))

            For Each ligne As DataRow In donnees.Rows
                If CDbl(ligne("NoteTC")) >= 10 Then
                    ligne("MentionTC") = "Validé"
                Else
                    ligne("MentionTC") = "Non validé"
                End If

                If CDbl(ligne("NoteSpe")) >= 10 Then
                    ligne("MentionSpe") = "Validé"
                Else
                    ligne("MentionSpe") = "Non validé"
                End If

                If CDbl(ligne("NoteEPP")) >= 10 Then
                    ligne("MentionEPP") = "Validé"
                Else
                    ligne("MentionEPP") = "Non validé"
                End If
            Next

            Return donnees
        Catch ex As Exception
            MessageBox.Show("Impossible de charger le classement.",
                            "Base de donnees", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            connexion.Close()
        End Try
    End Function

    Public Function ChargerBulletin(idEtudiant As Integer) As DataTable
        Dim connexion As OleDbConnection = OuvrirConnexion()
        If connexion Is Nothing Then
            Return Nothing
        End If

        Try
            Dim sql As String = "SELECT [Nom], [NoteTC], [NoteSpe], [NoteEPP], " &
                "[Moyenne], [Rang] FROM [Etudiants] WHERE [IdEtudiant] = ?"
            Dim donnees As New DataTable()

            Using commande As New OleDbCommand(sql, connexion)
                commande.Parameters.Add("?", OleDbType.Integer).Value = idEtudiant
                Using adaptateur As New OleDbDataAdapter(commande)
                    adaptateur.Fill(donnees)
                End Using
            End Using

            Return donnees
        Catch ex As Exception
            MessageBox.Show("Impossible de charger le bulletin.",
                            "Base de donnees", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            connexion.Close()
        End Try
    End Function

    Public Sub AfficherMention(etiquette As Label, note As Double)
        If note >= 10 Then
            etiquette.Text = "Validé"
            etiquette.ForeColor = System.Drawing.Color.DarkGreen
        Else
            etiquette.Text = "Non validé"
            etiquette.ForeColor = System.Drawing.Color.DarkRed
        End If
    End Sub
End Module
