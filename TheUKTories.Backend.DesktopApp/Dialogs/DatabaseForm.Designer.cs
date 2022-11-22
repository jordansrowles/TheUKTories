namespace TheUKTories.Backend.DesktopApp.Dialogs
{
    partial class DatabaseForm
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
            this.b_Migrate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_Migrate
            // 
            this.b_Migrate.Location = new System.Drawing.Point(12, 12);
            this.b_Migrate.Name = "b_Migrate";
            this.b_Migrate.Size = new System.Drawing.Size(217, 34);
            this.b_Migrate.TabIndex = 0;
            this.b_Migrate.Text = "Run Migrate";
            this.b_Migrate.UseVisualStyleBackColor = true;
            this.b_Migrate.Click += new System.EventHandler(this.b_Migrate_Click);
            // 
            // DatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.b_Migrate);
            this.Name = "DatabaseForm";
            this.Text = "DatabaseForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button b_Migrate;
    }
}