namespace Xpto.UI
{
    partial class FrmCustomerRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNickname = new System.Windows.Forms.Label();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.lblIdentity = new System.Windows.Forms.Label();
            this.txtIdentity = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblPersonType = new System.Windows.Forms.Label();
            this.cboPersonType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(12, 53);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(555, 23);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 35);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(40, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nome";
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Location = new System.Drawing.Point(12, 79);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(86, 15);
            this.lblNickname.TabIndex = 3;
            this.lblNickname.Text = "Nome Fantasia";
            // 
            // txtNickname
            // 
            this.txtNickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNickname.Location = new System.Drawing.Point(12, 97);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(555, 23);
            this.txtNickname.TabIndex = 2;
            // 
            // lblIdentity
            // 
            this.lblIdentity.AutoSize = true;
            this.lblIdentity.Location = new System.Drawing.Point(12, 123);
            this.lblIdentity.Name = "lblIdentity";
            this.lblIdentity.Size = new System.Drawing.Size(60, 15);
            this.lblIdentity.TabIndex = 5;
            this.lblIdentity.Text = "CPF/CNPJ";
            // 
            // txtIdentity
            // 
            this.txtIdentity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdentity.Location = new System.Drawing.Point(12, 141);
            this.txtIdentity.Name = "txtIdentity";
            this.txtIdentity.Size = new System.Drawing.Size(555, 23);
            this.txtIdentity.TabIndex = 4;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(12, 167);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(69, 15);
            this.lblNote.TabIndex = 7;
            this.lblNote.Text = "Observação";
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Location = new System.Drawing.Point(12, 185);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(555, 23);
            this.txtNote.TabIndex = 6;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(12, 231);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(142, 23);
            this.dtpBirthDate.TabIndex = 8;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(12, 213);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(114, 15);
            this.lblBirthDate.TabIndex = 9;
            this.lblBirthDate.Text = "Data de Nascimento";
            // 
            // lblPersonType
            // 
            this.lblPersonType.AutoSize = true;
            this.lblPersonType.Location = new System.Drawing.Point(12, 271);
            this.lblPersonType.Name = "lblPersonType";
            this.lblPersonType.Size = new System.Drawing.Size(85, 15);
            this.lblPersonType.TabIndex = 10;
            this.lblPersonType.Text = "Tipo de Pessoa";
            // 
            // cboPersonType
            // 
            this.cboPersonType.FormattingEnabled = true;
            this.cboPersonType.Items.AddRange(new object[] {
            "PF",
            "PJ"});
            this.cboPersonType.Location = new System.Drawing.Point(15, 293);
            this.cboPersonType.Name = "cboPersonType";
            this.cboPersonType.Size = new System.Drawing.Size(121, 23);
            this.cboPersonType.TabIndex = 11;
            this.cboPersonType.Text = "PF";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(15, 385);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(492, 385);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Sair";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(96, 385);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Excluir";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // FrmCustomerRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 420);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboPersonType);
            this.Controls.Add(this.lblPersonType);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblIdentity);
            this.Controls.Add(this.txtIdentity);
            this.Controls.Add(this.lblNickname);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Name = "FrmCustomerRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCustomerRegister";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtName;
        private Label lblName;
        private Label lblNickname;
        private TextBox txtNickname;
        private Label lblIdentity;
        private TextBox txtIdentity;
        private Label lblNote;
        private TextBox txtNote;
        private DateTimePicker dtpBirthDate;
        private Label lblBirthDate;
        private Label lblPersonType;
        private ComboBox cboPersonType;
        private Button btnSave;
        private Button btnExit;
        private Button btnDelete;
    }
}