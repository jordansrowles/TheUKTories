using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheUKTories.AdminClient.Dialogs;
using TheUKTories.DataStores.AzureCosmos;

namespace TheUKTories.AdminClient
{
    public partial class MainForm : Form
    {
        ICosmosDbContext _context;
        public MainForm(ICosmosDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void btnAusterity_Click(object sender, EventArgs e)
        {
            Dialogs.AusterityListForm dlg = new AusterityListForm(_context);
            dlg.ShowDialog();
        }
    }
}
