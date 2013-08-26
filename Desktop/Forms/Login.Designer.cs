using System.Drawing;
using System.Windows.Forms;
namespace Desktop
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.bOk = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.ePassword = new System.Windows.Forms.TextBox();
            this.eUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bOk
            // 
            //this.bOk.BackColor = System.Drawing.Color.Transparent;
            this.bOk.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOk.Location = new System.Drawing.Point(157, 27);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(86, 23);
            this.bOk.TabIndex = 3;
            this.bOk.Text = "Ok";
            this.bOk.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.bOk.UseVisualStyleBackColor = false;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.Location = new System.Drawing.Point(282, 27);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(86, 23);
            this.bClose.TabIndex = 4;
            this.bClose.Text = "Cancel";
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // ePassword
            // 
            this.ePassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ePassword.Location = new System.Drawing.Point(213, 126);
            this.ePassword.Name = "ePassword";
            this.ePassword.Size = new System.Drawing.Size(125, 14);
            this.ePassword.TabIndex = 2;
            this.ePassword.Text = "123456";
            this.ePassword.UseSystemPasswordChar = true;
            // 
            // eUserName
            // 
            this.eUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eUserName.Location = new System.Drawing.Point(24, 126);
            this.eUserName.Name = "eUserName";
            this.eUserName.Size = new System.Drawing.Size(121, 14);
            this.eUserName.TabIndex = 0;
            this.eUserName.Text = "test";
            // 
            // Login
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.bClose;
            this.ClientSize = new System.Drawing.Size(401, 169);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.ePassword);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.eUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Přihlášení k ACE Desktop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.TextBox ePassword;
        private System.Windows.Forms.TextBox eUserName;
    }
}