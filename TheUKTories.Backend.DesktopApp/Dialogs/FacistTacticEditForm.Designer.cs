namespace TheUKTories.Backend.DesktopApp.Dialogs
{
    partial class FacistTacticEditForm
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
            this.c_Data = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // c_Data
            // 
            this.c_Data.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.c_Data.GridLines = true;
            this.c_Data.Location = new System.Drawing.Point(12, 12);
            this.c_Data.Name = "c_Data";
            this.c_Data.Size = new System.Drawing.Size(349, 677);
            this.c_Data.TabIndex = 1;
            this.c_Data.UseCompatibleStateImageBehavior = false;
            this.c_Data.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.Width = 300;
            // 
            // FacistTacticEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 677);
            this.Controls.Add(this.c_Data);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FacistTacticEditForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FacistTacticEditForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ListView c_Data;
        private ColumnHeader columnHeader1;
        public ColumnHeader columnHeader2;
    }
}