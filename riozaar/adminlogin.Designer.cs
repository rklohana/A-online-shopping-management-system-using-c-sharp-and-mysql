
namespace riozaar
{
    partial class adminlogin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminlogin));
            this.label4 = new System.Windows.Forms.Label();
            this.signin = new Bunifu.Framework.UI.BunifuThinButton2();
            this.passwordtext = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.emailid = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Algerian", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(384, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 22);
            this.label4.TabIndex = 34;
            this.label4.Text = "Admin";
            // 
            // signin
            // 
            this.signin.ActiveBorderThickness = 1;
            this.signin.ActiveCornerRadius = 20;
            this.signin.ActiveFillColor = System.Drawing.Color.Maroon;
            this.signin.ActiveForecolor = System.Drawing.Color.White;
            this.signin.ActiveLineColor = System.Drawing.Color.Maroon;
            this.signin.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.signin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("signin.BackgroundImage")));
            this.signin.ButtonText = "Sign In";
            this.signin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signin.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.signin.IdleBorderThickness = 1;
            this.signin.IdleCornerRadius = 20;
            this.signin.IdleFillColor = System.Drawing.Color.Maroon;
            this.signin.IdleForecolor = System.Drawing.SystemColors.AppWorkspace;
            this.signin.IdleLineColor = System.Drawing.Color.Maroon;
            this.signin.Location = new System.Drawing.Point(66, 261);
            this.signin.Margin = new System.Windows.Forms.Padding(5);
            this.signin.Name = "signin";
            this.signin.Size = new System.Drawing.Size(292, 41);
            this.signin.TabIndex = 33;
            this.signin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.signin.Click += new System.EventHandler(this.signin_Click);
            // 
            // passwordtext
            // 
            this.passwordtext.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.passwordtext.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.passwordtext.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.passwordtext.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.passwordtext.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordtext.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordtext.ForeColor = System.Drawing.Color.White;
            this.passwordtext.HintForeColor = System.Drawing.Color.Empty;
            this.passwordtext.HintText = "";
            this.passwordtext.isPassword = false;
            this.passwordtext.LineFocusedColor = System.Drawing.Color.Lavender;
            this.passwordtext.LineIdleColor = System.Drawing.Color.DarkRed;
            this.passwordtext.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.passwordtext.LineThickness = 4;
            this.passwordtext.Location = new System.Drawing.Point(66, 190);
            this.passwordtext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordtext.MaxLength = 32767;
            this.passwordtext.Name = "passwordtext";
            this.passwordtext.Size = new System.Drawing.Size(292, 39);
            this.passwordtext.TabIndex = 32;
            this.passwordtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(63, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "Password";
            // 
            // emailid
            // 
            this.emailid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.emailid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.emailid.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.emailid.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.emailid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.emailid.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailid.ForeColor = System.Drawing.Color.White;
            this.emailid.HintForeColor = System.Drawing.Color.Empty;
            this.emailid.HintText = "";
            this.emailid.isPassword = false;
            this.emailid.LineFocusedColor = System.Drawing.Color.Lavender;
            this.emailid.LineIdleColor = System.Drawing.Color.DarkRed;
            this.emailid.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.emailid.LineThickness = 4;
            this.emailid.Location = new System.Drawing.Point(66, 102);
            this.emailid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.emailid.MaxLength = 32767;
            this.emailid.Name = "emailid";
            this.emailid.Size = new System.Drawing.Size(292, 39);
            this.emailid.TabIndex = 30;
            this.emailid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(63, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 29;
            this.label2.Text = "E-mail ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(59, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 39);
            this.label1.TabIndex = 28;
            this.label1.Text = "RIOZAAR";
            // 
            // adminlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.signin);
            this.Controls.Add(this.passwordtext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.emailid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "adminlogin";
            this.Size = new System.Drawing.Size(475, 350);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuThinButton2 signin;
        private Bunifu.Framework.UI.BunifuMaterialTextbox passwordtext;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox emailid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
