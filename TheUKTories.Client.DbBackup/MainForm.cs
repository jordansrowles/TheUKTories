using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.Client.DbBackup
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            BackupService.Backup(GetCheckedItems());
        }

        private void chAll_CheckedChanged(object sender, EventArgs e)
        {
            var chList = GetOptionItems();
            if (chAll.Checked)
                foreach (var i in chList) i.Checked = true;
            else
                foreach (var i in chList) i.Checked = false;
        }

        List<CheckBox> GetCheckedItems()
        {
            var items = this.Controls.OfType<CheckBox>();
            return items.Where(i => i.Checked
                && i.Name != "chAll").ToList();
        }
        List<CheckBox> GetOptionItems()
        {
            var items = this.Controls.OfType<CheckBox>();
            return items.Where(i => i.Name != "chAll").ToList();
        }
        
        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}