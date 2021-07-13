
namespace TheUKTories.AdminClient
{
    partial class MainForm
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
            this.btnAusterity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAusterity
            // 
            this.btnAusterity.Location = new System.Drawing.Point(12, 12);
            this.btnAusterity.Name = "btnAusterity";
            this.btnAusterity.Size = new System.Drawing.Size(112, 34);
            this.btnAusterity.TabIndex = 0;
            this.btnAusterity.Text = "Austerity";
            this.btnAusterity.UseVisualStyleBackColor = true;
            this.btnAusterity.Click += new System.EventHandler(this.btnAusterity_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAusterity);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAusterity;
    }
}

