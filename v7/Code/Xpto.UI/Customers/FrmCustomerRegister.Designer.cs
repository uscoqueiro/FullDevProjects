namespace Xpto.UI.Customers
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
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblPersonType = new System.Windows.Forms.Label();
            this.cboPersonType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.mkdBirthDate = new System.Windows.Forms.MaskedTextBox();
            this.lvwAddresses = new System.Windows.Forms.ListView();
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(12, 53);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(326, 23);
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
            this.txtNickname.Size = new System.Drawing.Size(326, 23);
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
            this.txtIdentity.Size = new System.Drawing.Size(326, 23);
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
            this.txtNote.Size = new System.Drawing.Size(326, 23);
            this.txtNote.TabIndex = 6;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(341, 31);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(114, 15);
            this.lblBirthDate.TabIndex = 9;
            this.lblBirthDate.Text = "Data de Nascimento";
            // 
            // lblPersonType
            // 
            this.lblPersonType.AutoSize = true;
            this.lblPersonType.Location = new System.Drawing.Point(341, 119);
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
            this.cboPersonType.Location = new System.Drawing.Point(344, 141);
            this.cboPersonType.Name = "cboPersonType";
            this.cboPersonType.Size = new System.Drawing.Size(121, 23);
            this.cboPersonType.TabIndex = 11;
            this.cboPersonType.Text = "PF";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(411, 473);
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
            this.btnExit.Location = new System.Drawing.Point(492, 473);
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
            this.btnDelete.Location = new System.Drawing.Point(15, 473);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Excluir";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // mkdBirthDate
            // 
            this.mkdBirthDate.Location = new System.Drawing.Point(344, 53);
            this.mkdBirthDate.Mask = "00/00/0000";
            this.mkdBirthDate.Name = "mkdBirthDate";
            this.mkdBirthDate.Size = new System.Drawing.Size(100, 23);
            this.mkdBirthDate.TabIndex = 15;
            this.mkdBirthDate.ValidatingType = typeof(System.DateTime);
            // 
            // lvwAddresses
            // 
            this.lvwAddresses.Location = new System.Drawing.Point(12, 261);
            this.lvwAddresses.Name = "lvwAddresses";
            this.lvwAddresses.Size = new System.Drawing.Size(453, 97);
            this.lvwAddresses.TabIndex = 16;
            this.lvwAddresses.UseCompatibleStateImageBehavior = false;
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddAddress.Location = new System.Drawing.Point(308, 232);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(157, 23);
            this.btnAddAddress.TabIndex = 17;
            this.btnAddAddress.Text = "Adicionar Endereço";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Endereços";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(12, 9);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(49, 15);
            this.lblCode.TabIndex = 19;
            this.lblCode.Text = "Código:";
            // 
            // FrmCustomerRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 508);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddAddress);
            this.Controls.Add(this.lvwAddresses);
            this.Controls.Add(this.mkdBirthDate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboPersonType);
            this.Controls.Add(this.lblPersonType);
            this.Controls.Add(this.lblBirthDate);
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
        private Label lblBirthDate;
        private Label lblPersonType;
        private ComboBox cboPersonType;
        private Button btnSave;
        private Button btnExit;
        private Button btnDelete;
        private MaskedTextBox mkdBirthDate;
        private ListView lvwAddresses;
        private Button btnAddAddress;
        private Label label1;
        private Label lblCode;
    }
}