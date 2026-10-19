<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormulairePrincipal
    Inherits System.Windows.Forms.Form

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents lblNom As System.Windows.Forms.Label
    Friend WithEvents txtNom As System.Windows.Forms.TextBox
    Friend WithEvents lblTC As System.Windows.Forms.Label
    Friend WithEvents txtTC As System.Windows.Forms.TextBox
    Friend WithEvents lblMentionTC As System.Windows.Forms.Label
    Friend WithEvents lblSpe As System.Windows.Forms.Label
    Friend WithEvents txtSpe As System.Windows.Forms.TextBox
    Friend WithEvents lblMentionSpe As System.Windows.Forms.Label
    Friend WithEvents lblEPP As System.Windows.Forms.Label
    Friend WithEvents txtEPP As System.Windows.Forms.TextBox
    Friend WithEvents lblMentionEPP As System.Windows.Forms.Label
    Friend WithEvents lblMoyenne As System.Windows.Forms.Label
    Friend WithEvents btnAjouter As System.Windows.Forms.Button
    Friend WithEvents btnClassement As System.Windows.Forms.Button
    Friend WithEvents btnBulletin As System.Windows.Forms.Button
    Friend WithEvents dgvEtudiants As System.Windows.Forms.DataGridView

    Private Sub InitializeComponent()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.lblTC = New System.Windows.Forms.Label()
        Me.txtTC = New System.Windows.Forms.TextBox()
        Me.lblMentionTC = New System.Windows.Forms.Label()
        Me.lblSpe = New System.Windows.Forms.Label()
        Me.txtSpe = New System.Windows.Forms.TextBox()
        Me.lblMentionSpe = New System.Windows.Forms.Label()
        Me.lblEPP = New System.Windows.Forms.Label()
        Me.txtEPP = New System.Windows.Forms.TextBox()
        Me.lblMentionEPP = New System.Windows.Forms.Label()
        Me.lblMoyenne = New System.Windows.Forms.Label()
        Me.btnAjouter = New System.Windows.Forms.Button()
        Me.btnClassement = New System.Windows.Forms.Button()
        Me.btnBulletin = New System.Windows.Forms.Button()
        Me.dgvEtudiants = New System.Windows.Forms.DataGridView()
        CType(Me.dgvEtudiants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' lblNom
        '
        Me.lblNom.AutoSize = True
        Me.lblNom.Location = New System.Drawing.Point(20, 20)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(35, 15)
        Me.lblNom.TabIndex = 0
        Me.lblNom.Text = "Nom :"
        '
        ' txtNom
        '
        Me.txtNom.Location = New System.Drawing.Point(170, 17)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(260, 23)
        Me.txtNom.TabIndex = 1
        '
        ' lblTC
        '
        Me.lblTC.AutoSize = True
        Me.lblTC.Location = New System.Drawing.Point(20, 57)
        Me.lblTC.Name = "lblTC"
        Me.lblTC.Size = New System.Drawing.Size(104, 15)
        Me.lblTC.TabIndex = 2
        Me.lblTC.Text = "Tronc commun :"
        '
        ' txtTC
        '
        Me.txtTC.Location = New System.Drawing.Point(170, 53)
        Me.txtTC.Name = "txtTC"
        Me.txtTC.Size = New System.Drawing.Size(70, 23)
        Me.txtTC.TabIndex = 3
        '
        ' lblMentionTC
        '
        Me.lblMentionTC.AutoSize = True
        Me.lblMentionTC.Location = New System.Drawing.Point(260, 57)
        Me.lblMentionTC.Name = "lblMentionTC"
        Me.lblMentionTC.Size = New System.Drawing.Size(61, 15)
        Me.lblMentionTC.TabIndex = 4
        Me.lblMentionTC.Text = ""
        '
        ' lblSpe
        '
        Me.lblSpe.AutoSize = True
        Me.lblSpe.Location = New System.Drawing.Point(20, 91)
        Me.lblSpe.Name = "lblSpe"
        Me.lblSpe.Size = New System.Drawing.Size(71, 15)
        Me.lblSpe.TabIndex = 5
        Me.lblSpe.Text = "Spécialité :"
        '
        ' txtSpe
        '
        Me.txtSpe.Location = New System.Drawing.Point(170, 87)
        Me.txtSpe.Name = "txtSpe"
        Me.txtSpe.Size = New System.Drawing.Size(70, 23)
        Me.txtSpe.TabIndex = 6
        '
        ' lblMentionSpe
        '
        Me.lblMentionSpe.AutoSize = True
        Me.lblMentionSpe.Location = New System.Drawing.Point(260, 91)
        Me.lblMentionSpe.Name = "lblMentionSpe"
        Me.lblMentionSpe.Size = New System.Drawing.Size(61, 15)
        Me.lblMentionSpe.TabIndex = 7
        Me.lblMentionSpe.Text = ""
        '
        ' lblEPP
        '
        Me.lblEPP.AutoSize = True
        Me.lblEPP.Location = New System.Drawing.Point(20, 125)
        Me.lblEPP.Name = "lblEPP"
        Me.lblEPP.Size = New System.Drawing.Size(39, 15)
        Me.lblEPP.TabIndex = 8
        Me.lblEPP.Text = "EPP :"
        '
        ' txtEPP
        '
        Me.txtEPP.Location = New System.Drawing.Point(170, 121)
        Me.txtEPP.Name = "txtEPP"
        Me.txtEPP.Size = New System.Drawing.Size(70, 23)
        Me.txtEPP.TabIndex = 9
        '
        ' lblMentionEPP
        '
        Me.lblMentionEPP.AutoSize = True
        Me.lblMentionEPP.Location = New System.Drawing.Point(260, 125)
        Me.lblMentionEPP.Name = "lblMentionEPP"
        Me.lblMentionEPP.Size = New System.Drawing.Size(61, 15)
        Me.lblMentionEPP.TabIndex = 10
        Me.lblMentionEPP.Text = ""
        '
        ' lblMoyenne
        '
        Me.lblMoyenne.AutoSize = True
        Me.lblMoyenne.Location = New System.Drawing.Point(20, 159)
        Me.lblMoyenne.Name = "lblMoyenne"
        Me.lblMoyenne.Size = New System.Drawing.Size(139, 15)
        Me.lblMoyenne.TabIndex = 11
        Me.lblMoyenne.Text = "Moyenne générale : -"
        '
        ' btnAjouter
        '
        Me.btnAjouter.Location = New System.Drawing.Point(20, 190)
        Me.btnAjouter.Name = "btnAjouter"
        Me.btnAjouter.Size = New System.Drawing.Size(120, 30)
        Me.btnAjouter.TabIndex = 12
        Me.btnAjouter.Text = "Ajouter"
        Me.btnAjouter.UseVisualStyleBackColor = True
        '
        ' btnClassement
        '
        Me.btnClassement.Location = New System.Drawing.Point(155, 190)
        Me.btnClassement.Name = "btnClassement"
        Me.btnClassement.Size = New System.Drawing.Size(150, 30)
        Me.btnClassement.TabIndex = 13
        Me.btnClassement.Text = "Actualiser le classement"
        Me.btnClassement.UseVisualStyleBackColor = True
        '
        ' btnBulletin
        '
        Me.btnBulletin.Location = New System.Drawing.Point(320, 190)
        Me.btnBulletin.Name = "btnBulletin"
        Me.btnBulletin.Size = New System.Drawing.Size(130, 30)
        Me.btnBulletin.TabIndex = 14
        Me.btnBulletin.Text = "Voir le bulletin"
        Me.btnBulletin.UseVisualStyleBackColor = True
        '
        ' dgvEtudiants
        '
        Me.dgvEtudiants.AllowUserToAddRows = False
        Me.dgvEtudiants.AllowUserToDeleteRows = False
        Me.dgvEtudiants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEtudiants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEtudiants.Location = New System.Drawing.Point(20, 235)
        Me.dgvEtudiants.MultiSelect = False
        Me.dgvEtudiants.Name = "dgvEtudiants"
        Me.dgvEtudiants.ReadOnly = True
        Me.dgvEtudiants.RowHeadersVisible = False
        Me.dgvEtudiants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEtudiants.Size = New System.Drawing.Size(850, 340)
        Me.dgvEtudiants.TabIndex = 15
        '
        ' FormulairePrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 595)
        Me.Controls.Add(Me.dgvEtudiants)
        Me.Controls.Add(Me.btnBulletin)
        Me.Controls.Add(Me.btnClassement)
        Me.Controls.Add(Me.btnAjouter)
        Me.Controls.Add(Me.lblMoyenne)
        Me.Controls.Add(Me.lblMentionEPP)
        Me.Controls.Add(Me.txtEPP)
        Me.Controls.Add(Me.lblEPP)
        Me.Controls.Add(Me.lblMentionSpe)
        Me.Controls.Add(Me.txtSpe)
        Me.Controls.Add(Me.lblSpe)
        Me.Controls.Add(Me.lblMentionTC)
        Me.Controls.Add(Me.txtTC)
        Me.Controls.Add(Me.lblTC)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.lblNom)
        Me.Name = "FormulairePrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion des etudiants"
        CType(Me.dgvEtudiants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
