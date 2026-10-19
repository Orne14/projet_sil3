Imports System.Data
Imports System.Windows.Forms

Public Class FormulaireBulletin
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Function ChargerBulletin(idEtudiant As Integer) As Boolean
        Dim donnees As DataTable = BaseEtudiants.ChargerBulletin(idEtudiant)

        If donnees Is Nothing OrElse donnees.Rows.Count = 0 Then
            Return False
        End If

        Dim ligne As DataRow = donnees.Rows(0)
        lblNomValeur.Text = ligne("Nom").ToString()
        lblTCValeur.Text = CDbl(ligne("NoteTC")).ToString("0.##") & " / 20"
        lblSpeValeur.Text = CDbl(ligne("NoteSpe")).ToString("0.##") & " / 20"
        lblEPPValeur.Text = CDbl(ligne("NoteEPP")).ToString("0.##") & " / 20"
        lblMoyenneValeur.Text = CDbl(ligne("Moyenne")).ToString("0.00")
        lblRangValeur.Text = ligne("Rang").ToString()

        BaseEtudiants.AfficherMention(lblMentionTC, CDbl(ligne("NoteTC")))
        BaseEtudiants.AfficherMention(lblMentionSpe, CDbl(ligne("NoteSpe")))
        BaseEtudiants.AfficherMention(lblMentionEPP, CDbl(ligne("NoteEPP")))

        Return True
    End Function
End Class
