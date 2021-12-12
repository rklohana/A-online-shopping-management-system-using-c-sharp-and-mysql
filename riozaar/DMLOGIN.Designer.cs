
namespace riozaar
{
    partial class DMLOGIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMLOGIN));
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.signin = new Bunifu.Framework.UI.BunifuThinButton2();
            this.passwordtext = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.emailid = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(142, 306);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(140, 13);
            this.bunifuCustomLabel1.TabIndex = 20;
            this.bunifuCustomLabel1.Text = "New to RIOZAAR? Sign up.";
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
            this.signin.Location = new System.Drawing.Point(64, 249);
            this.signin.Margin = new System.Windows.Forms.Padding(5);
            this.signin.Name = "signin";
            this.signin.Size = new System.Drawing.Size(292, 41);
            this.signin.TabIndex = 19;
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
            this.passwordtext.Location = new System.Drawing.Point(64, 178);
            this.passwordtext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordtext.MaxLength = 32767;
            this.passwordtext.Name = "passwordtext";
            this.passwordtext.Size = new System.Drawing.Size(292, 39);
            this.passwordtext.TabIndex = 18;
            this.passwordtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(61, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 17;
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
            this.emailid.Location = new System.Drawing.Point(64, 90);
            this.emailid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.emailid.MaxLength = 32767;
            this.emailid.Name = "emailid";
            this.emailid.Size = new System.Drawing.Size(292, 39);
            this.emailid.TabIndex = 16;
            this.emailid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(61, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "E-mail ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(57, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "RIOZAAR";
            // 
            // DMLOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.signin);
            this.Controls.Add(this.passwordtext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.emailid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DMLOGIN";
            this.Size = new System.Drawing.Size(475, 350);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuThinButton2 signin;
        private Bunifu.Framework.UI.BunifuMaterialTextbox passwordtext;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox emailid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
