namespace TheUKTories.Backend.DesktopApp.ModelForms
{
    partial class FacistTacticForm
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
            this.c_Title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.c_Link = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c_Subtitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.b_Submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // c_Title
            // 
            this.c_Title.Location = new System.Drawing.Point(12, 38);
            this.c_Title.Name = "c_Title";
            this.c_Title.Size = new System.Drawing.Size(776, 31);
            this.c_Title.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title";
            // 
            // c_Link
            // 
            this.c_Link.Location = new System.Drawing.Point(12, 100);
            this.c_Link.Name = "c_Link";
            this.c_Link.Size = new System.Drawing.Size(776, 31);
            this.c_Link.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Link";
            // 
            // c_Subtitle
            // 
            this.c_Subtitle.Location = new System.Drawing.Point(12, 162);
            this.c_Subtitle.Multiline = true;
            this.c_Subtitle.Name = "c_Subtitle";
            this.c_Subtitle.Size = new System.Drawing.Size(776, 232);
            this.c_Subtitle.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Subtitle";
            // 
            // b_Submit
            // 
            this.b_Submit.Location = new System.Drawing.Point(676, 404);
            this.b_Submit.Name = "b_Submit";
            this.b_Submit.Size = new System.Drawing.Size(112, 34);
            this.b_Submit.TabIndex = 9;
            this.b_Submit.Text = "Submit";
            this.b_Submit.UseVisualStyleBackColor = true;
            this.b_Submit.Click += new System.EventHandler(this.b_Submit_Click);
            // 
            // FacistTactic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.b_Submit);
            this.Controls.Add(this.c_Subtitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.c_Link);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.c_Title);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FacistTactic";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facist Tactic Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox c_Title;
        private Label label1;
        private TextBox c_Link;
        private Label label2;
        private TextBox c_Subtitle;
        private Label label3;
        private Button b_Submit;
    }
}