using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;

namespace TheUKTories.AdminClient.Dialogs
{
    public partial class AusterityForm : Form
    {
        public Austeritys Austerity { get; set; }

        public AusterityForm(ICosmosDbContext context)
        {
            InitializeComponent();
            Austerity = new ();
        }

        public AusterityForm(ICosmosDbContext context, Austeritys austerity)
        {
            InitializeComponent();
            Austerity = austerity;
            tbString.Text = Austerity.String;
            tbType.Text = Austerity.Type;
            dgvSources.DataSource = Austerity.Sources;
        }

        private void AusterityForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvSources_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SourceForm dlg = new((SourceItem)dgvSources.SelectedRows[0].DataBoundItem);
            dlg.ShowDialog();
        }
    }
}
