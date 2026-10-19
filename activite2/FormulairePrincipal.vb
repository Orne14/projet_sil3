Imports System.Data
Imports System.Globalization
Imports System.Windows.Forms

Public Class FormulairePrincipal
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FormulairePrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not BaseEtudiants.AssurerTable() Then
            btnAjouter.Enabled = False
            btnClassement.Enabled = False
            btnBulletin.Enabled = False
            Return
        End If

        AfficherClassement()
    End Sub

    Private Function LireNote(zone As TextBox, matiere As String,
                              ByRef note As Double) As Boolean
        Dim texte As String = zone.Text.Trim().Replace(","c, "."c)

        If Not Double.TryParse(texte,
                               NumberStyles.AllowDecimalPoint,
                               CultureInfo.InvariantCulture,
                               note) Then
            MessageBox.Show("Saisissez une note numerique pour " & matiere & ".",
                            "Saisie incorrecte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            zone.Focus()
            Return False
        End If

        If note < 0 OrElse note > 20 Then
            MessageBox.Show("La note de " & matiere & " doit etre comprise entre 0 et 20.",
                            "Saisie incorrecte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            zone.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnAjouter_Click(sender As Object, e As EventArgs) Handles btnAjouter.Click
        Dim nom As String = txtNom.Text.Trim()
        Dim noteTC As Double
        Dim noteSpe As Double
        Dim noteEPP As Double

        If nom = "" Then
            MessageBox.Show("Saisissez le nom de l'etudiant.",
                            "Saisie incorrecte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNom.Focus()
            Return
        End If

        If nom.Length > 50 Then
            MessageBox.Show("Le nom ne doit pas depasser 50 caracteres.",
                            "Saisie incorrecte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNom.Focus()
            Return
        End If

        If Not LireNote(txtTC, "Tronc commun", noteTC) Then
            Return
        End If
        If Not LireNote(txtSpe, "Spécialité", noteSpe) Then
            Return
        End If
        If Not LireNote(txtEPP, "EPP", noteEPP) Then
            Return
        End If

        ' Calcul de la moyenne generale
        Dim moyenne As Double = (3 * noteTC + 4 * noteSpe + 3 * noteEPP) / 10

        If Not BaseEtudiants.AjouterEtudiant(nom, noteTC, noteSpe, noteEPP, moyenne) Then
            Return
        End If

        BaseEtudiants.AfficherMention(lblMentionTC, noteTC)
        BaseEtudiants.AfficherMention(lblMentionSpe, noteSpe)
        BaseEtudiants.AfficherMention(lblMentionEPP, noteEPP)
        lblMoyenne.Text = "Moyenne generale : " & moyenne.ToString("0.00")
        txtNom.Clear()
        txtTC.Clear()
        txtSpe.Clear()
        txtEPP.Clear()
        txtNom.Focus()
        AfficherClassement()
    End Sub

    Private Sub btnClassement_Click(sender As Object, e As EventArgs) Handles btnClassement.Click
        AfficherClassement()
    End Sub

    Private Sub AfficherClassement()
        Dim donnees As DataTable = BaseEtudiants.ChargerEtudiants()
        If donnees Is Nothing Then
            Return
        End If

        dgvEtudiants.DataSource = donnees
        dgvEtudiants.Columns("Rang").HeaderText = "Rang"
        dgvEtudiants.Columns("Nom").HeaderText = "Nom"
        dgvEtudiants.Columns("NoteTC").HeaderText = "Tronc commun"
        dgvEtudiants.Columns("NoteSpe").HeaderText = "Spécialité"
        dgvEtudiants.Columns("NoteEPP").HeaderText = "EPP"
        dgvEtudiants.Columns("Moyenne").HeaderText = "Moyenne générale"
        dgvEtudiants.Columns("MentionTC").HeaderText = "Mention TC"
        dgvEtudiants.Columns("MentionSpe").HeaderText = "Mention spécialité"
        dgvEtudiants.Columns("MentionEPP").HeaderText = "Mention EPP"
        If dgvEtudiants.Columns.Contains("IdEtudiant") Then
            dgvEtudiants.Columns("IdEtudiant").Visible = False
        End If
    End Sub

    Private Sub btnBulletin_Click(sender As Object, e As EventArgs) Handles btnBulletin.Click
        If dgvEtudiants.CurrentRow Is Nothing Then
            MessageBox.Show("Choisissez un etudiant dans le classement.",
                            "Bulletin", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim valeurId As Object = dgvEtudiants.CurrentRow.Cells("IdEtudiant").Value
        If valeurId Is Nothing Then
            MessageBox.Show("Choisissez un etudiant dans le classement.",
                            "Bulletin", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim idEtudiant As Integer = CInt(valeurId)
        Dim fenetreBulletin As New FormulaireBulletin()
        If fenetreBulletin.ChargerBulletin(idEtudiant) Then
            fenetreBulletin.ShowDialog(Me)
        End If
    End Sub

    Private Sub dgvEtudiants_CellFormatting(sender As Object,
                                             e As DataGridViewCellFormattingEventArgs) _
                                             Handles dgvEtudiants.CellFormatting
        If e.Value Is Nothing OrElse e.Value Is DBNull.Value Then
            Return
        End If

        Dim nomColonne As String = dgvEtudiants.Columns(e.ColumnIndex).Name
        If nomColonne = "MentionTC" OrElse nomColonne = "MentionSpe" _
            OrElse nomColonne = "MentionEPP" Then
            If e.Value.ToString() = "Validé" Then
                e.CellStyle.ForeColor = System.Drawing.Color.DarkGreen
            ElseIf e.Value.ToString() = "Non validé" Then
                e.CellStyle.ForeColor = System.Drawing.Color.DarkRed
            End If
        End If
    End Sub
End Class

