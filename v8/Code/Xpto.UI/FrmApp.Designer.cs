namespace Xpto.UI
{
    partial class FrmApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCustomerSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMessage = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRegister});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(800, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmRegister
            // 
            this.tsmRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCustomerSearch});
            this.tsmRegister.Name = "tsmRegister";
            this.tsmRegister.Size = new System.Drawing.Size(99, 29);
            this.tsmRegister.Text = "Cadastro";
            // 
            // tsmCustomerSearch
            // 
            this.tsmCustomerSearch.Name = "tsmCustomerSearch";
            this.tsmCustomerSearch.Size = new System.Drawing.Size(270, 34);
            this.tsmCustomerSearch.Text = "Cliente";
            this.tsmCustomerSearch.Click += new System.EventHandler(this.tsmCustomerSearch_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 420);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(47, 25);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Msg";
            // 
            // FrmApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 630);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmApp";
            this.Text = "Xpto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmRegister;
        private ToolStripMenuItem tsmCustomerSearch;
        private Label lblMessage;
    }
}