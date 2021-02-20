
namespace TheUKTories.Client.DbBackup
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
            this.label1 = new System.Windows.Forms.Label();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chTactics = new System.Windows.Forms.CheckBox();
            this.chAusterity = new System.Windows.Forms.CheckBox();
            this.chContacts = new System.Windows.Forms.CheckBox();
            this.chExternalLink = new System.Windows.Forms.CheckBox();
            this.chC19Responses = new System.Windows.Forms.CheckBox();
            this.chC19contracts = new System.Windows.Forms.CheckBox();
            this.chPeople = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.chGovContracts = new System.Windows.Forms.CheckBox();
            this.chAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup Cosmos Database";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmit.Location = new System.Drawing.Point(12, 295);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(94, 29);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(207, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chTactics
            // 
            this.chTactics.AutoSize = true;
            this.chTactics.Location = new System.Drawing.Point(46, 87);
            this.chTactics.Name = "chTactics";
            this.chTactics.Size = new System.Drawing.Size(132, 24);
            this.chTactics.TabIndex = 6;
            this.chTactics.Tag = "tactics";
            this.chTactics.Text = "AltRight Tactics";
            this.chTactics.UseVisualStyleBackColor = true;
            // 
            // chAusterity
            // 
            this.chAusterity.AutoSize = true;
            this.chAusterity.Location = new System.Drawing.Point(46, 108);
            this.chAusterity.Name = "chAusterity";
            this.chAusterity.Size = new System.Drawing.Size(100, 24);
            this.chAusterity.TabIndex = 7;
            this.chAusterity.Tag = "austerity";
            this.chAusterity.Text = "Austerities";
            this.chAusterity.UseVisualStyleBackColor = true;
            // 
            // chContacts
            // 
            this.chContacts.AutoSize = true;
            this.chContacts.Location = new System.Drawing.Point(46, 129);
            this.chContacts.Name = "chContacts";
            this.chContacts.Size = new System.Drawing.Size(88, 24);
            this.chContacts.TabIndex = 8;
            this.chContacts.Tag = "contacts";
            this.chContacts.Text = "Contacts";
            this.chContacts.UseVisualStyleBackColor = true;
            // 
            // chExternalLink
            // 
            this.chExternalLink.AutoSize = true;
            this.chExternalLink.Location = new System.Drawing.Point(46, 192);
            this.chExternalLink.Name = "chExternalLink";
            this.chExternalLink.Size = new System.Drawing.Size(120, 24);
            this.chExternalLink.TabIndex = 11;
            this.chExternalLink.Tag = "external_links";
            this.chExternalLink.Text = "External Links";
            this.chExternalLink.UseVisualStyleBackColor = true;
            // 
            // chC19Responses
            // 
            this.chC19Responses.AutoSize = true;
            this.chC19Responses.Location = new System.Drawing.Point(46, 171);
            this.chC19Responses.Name = "chC19Responses";
            this.chC19Responses.Size = new System.Drawing.Size(142, 24);
            this.chC19Responses.TabIndex = 10;
            this.chC19Responses.Tag = "covid_responses";
            this.chC19Responses.Text = "Covid Responses";
            this.chC19Responses.UseVisualStyleBackColor = true;
            // 
            // chC19contracts
            // 
            this.chC19contracts.AutoSize = true;
            this.chC19contracts.Location = new System.Drawing.Point(46, 150);
            this.chC19contracts.Name = "chC19contracts";
            this.chC19contracts.Size = new System.Drawing.Size(171, 24);
            this.chC19contracts.TabIndex = 9;
            this.chC19contracts.Tag = "covid_contracts";
            this.chC19contracts.Text = "Covid Contracts (old)";
            this.chC19contracts.UseVisualStyleBackColor = true;
            // 
            // chPeople
            // 
            this.chPeople.AutoSize = true;
            this.chPeople.Location = new System.Drawing.Point(46, 254);
            this.chPeople.Name = "chPeople";
            this.chPeople.Size = new System.Drawing.Size(76, 24);
            this.chPeople.TabIndex = 14;
            this.chPeople.Tag = "people";
            this.chPeople.Text = "People";
            this.chPeople.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(46, 233);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(146, 24);
            this.checkBox6.TabIndex = 13;
            this.checkBox6.Tag = "isc_report";
            this.checkBox6.Text = "ISC Russia Report";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // chGovContracts
            // 
            this.chGovContracts.AutoSize = true;
            this.chGovContracts.Location = new System.Drawing.Point(46, 212);
            this.chGovContracts.Name = "chGovContracts";
            this.chGovContracts.Size = new System.Drawing.Size(165, 24);
            this.chGovContracts.TabIndex = 12;
            this.chGovContracts.Tag = "gov_covid_contracts";
            this.chGovContracts.Text = "Gov Covid Contracts";
            this.chGovContracts.UseVisualStyleBackColor = true;
            // 
            // chAll
            // 
            this.chAll.AutoSize = true;
            this.chAll.Location = new System.Drawing.Point(46, 49);
            this.chAll.Name = "chAll";
            this.chAll.Size = new System.Drawing.Size(49, 24);
            this.chAll.TabIndex = 16;
            this.chAll.Tag = "";
            this.chAll.Text = "All";
            this.chAll.UseVisualStyleBackColor = true;
            this.chAll.CheckedChanged += new System.EventHandler(this.chAll_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 336);
            this.Controls.Add(this.chAll);
            this.Controls.Add(this.chPeople);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.chGovContracts);
            this.Controls.Add(this.chExternalLink);
            this.Controls.Add(this.chC19Responses);
            this.Controls.Add(this.chC19contracts);
            this.Controls.Add(this.chContacts);
            this.Controls.Add(this.chAusterity);
            this.Controls.Add(this.chTactics);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TheUKTories - Backend";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chTactics;
        private System.Windows.Forms.CheckBox chAusterity;
        private System.Windows.Forms.CheckBox chContacts;
        private System.Windows.Forms.CheckBox chExternalLink;
        private System.Windows.Forms.CheckBox chC19Responses;
        private System.Windows.Forms.CheckBox chC19contracts;
        private System.Windows.Forms.CheckBox chPeople;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox chGovContracts;
        private System.Windows.Forms.CheckBox chAll;
    }
}

