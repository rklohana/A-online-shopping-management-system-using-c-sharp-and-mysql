
namespace riozaar
{
    partial class test_form
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
            this.signup11 = new riozaar.signup1();
            this.SuspendLayout();
            // 
            // signup11
            // 
            this.signup11.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.signup11.Location = new System.Drawing.Point(121, 18);
            this.signup11.Name = "signup11";
            this.signup11.Size = new System.Drawing.Size(620, 420);
            this.signup11.TabIndex = 0;
            // 
            // test_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.signup11);
            this.Name = "test_form";
            this.Text = "test_form";
            this.Load += new System.EventHandler(this.test_form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private signup1 signup11;
    }
}