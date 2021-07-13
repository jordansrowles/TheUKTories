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
    public partial class AusterityListForm : Form
    {
        ICosmosDbContext _context;
        List<Austeritys> _data;

        public AusterityListForm(ICosmosDbContext context)
        {
            _context = context;
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }

        private async void AusterityListForm_Load(object sender, EventArgs e)
        {
            _data = await _context.GetDocumentsAsync<Austeritys>(_context.AusterityContainer);
            dgvData.DataSource = _data;
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AusterityForm dlg = new (_context, (Austeritys)dgvData.SelectedRows[0].DataBoundItem);
            dlg.ShowDialog();
        }
    }
}
