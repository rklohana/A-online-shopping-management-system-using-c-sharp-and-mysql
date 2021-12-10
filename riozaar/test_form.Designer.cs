
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
            this.producttemplate1 = new riozaar.producttemplate();
            this.SuspendLayout();
            // 
            // producttemplate1
            // 
            this.producttemplate1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.producttemplate1.Location = new System.Drawing.Point(97, 0);
            this.producttemplate1.Name = "producttemplate1";
            this.producttemplate1.Size = new System.Drawing.Size(644, 322);
            this.producttemplate1.TabIndex = 0;
            // 
            // test_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.producttemplate1);
            this.Name = "test_form";
            this.Text = "test_form";
            this.ResumeLayout(false);

        }

        #endregion

        private producttemplate producttemplate1;
    }
}