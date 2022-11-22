namespace TheUKTories.Backend.DesktopApp
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.b_UKAusterityNew = new System.Windows.Forms.LinkLabel();
            this.b_DbTools = new System.Windows.Forms.LinkLabel();
            this.b_NewAltRight = new System.Windows.Forms.LinkLabel();
            this.b_AllTactics = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.b_UKAusterityNew);
            this.flowLayoutPanel1.Controls.Add(this.b_DbTools);
            this.flowLayoutPanel1.Controls.Add(this.b_NewAltRight);
            this.flowLayoutPanel1.Controls.Add(this.b_AllTactics);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(281, 450);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // b_UKAusterityNew
            // 
            this.b_UKAusterityNew.AutoSize = true;
            this.b_UKAusterityNew.Location = new System.Drawing.Point(3, 0);
            this.b_UKAusterityNew.Name = "b_UKAusterityNew";
            this.b_UKAusterityNew.Size = new System.Drawing.Size(189, 25);
            this.b_UKAusterityNew.TabIndex = 0;
            this.b_UKAusterityNew.TabStop = true;
            this.b_UKAusterityNew.Text = "Add UK Austerity Item";
            this.b_UKAusterityNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.b_UKAusterityNew_LinkClicked);
            // 
            // b_DbTools
            // 
            this.b_DbTools.AutoSize = true;
            this.b_DbTools.Location = new System.Drawing.Point(3, 25);
            this.b_DbTools.Name = "b_DbTools";
            this.b_DbTools.Size = new System.Drawing.Size(132, 25);
            this.b_DbTools.TabIndex = 1;
            this.b_DbTools.TabStop = true;
            this.b_DbTools.Text = "Database Tools";
            this.b_DbTools.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.b_DbTools_LinkClicked);
            // 
            // b_NewAltRight
            // 
            this.b_NewAltRight.AutoSize = true;
            this.b_NewAltRight.Location = new System.Drawing.Point(3, 50);
            this.b_NewAltRight.Name = "b_NewAltRight";
            this.b_NewAltRight.Size = new System.Drawing.Size(116, 25);
            this.b_NewAltRight.TabIndex = 2;
            this.b_NewAltRight.TabStop = true;
            this.b_NewAltRight.Text = "New AltRight";
            this.b_NewAltRight.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.b_NewAltRight_LinkClicked);
            // 
            // b_AllTactics
            // 
            this.b_AllTactics.AutoSize = true;
            this.b_AllTactics.Location = new System.Drawing.Point(3, 75);
            this.b_AllTactics.Name = "b_AllTactics";
            this.b_AllTactics.Size = new System.Drawing.Size(97, 25);
            this.b_AllTactics.TabIndex = 3;
            this.b_AllTactics.TabStop = true;
            this.b_AllTactics.Text = "Edit Tactics";
            this.b_AllTactics.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.b_AllTactics_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TheUKTories Backend";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private LinkLabel b_UKAusterityNew;
        private LinkLabel b_DbTools;
        private LinkLabel b_NewAltRight;
        private LinkLabel b_AllTactics;
    }
}