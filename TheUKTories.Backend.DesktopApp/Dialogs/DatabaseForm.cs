using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheUKTories.Services.Data.EFCore;

namespace TheUKTories.Backend.DesktopApp.Dialogs
{
    public partial class DatabaseForm : Form
    {
        private readonly SqlServerDataContext context;

        public DatabaseForm(SqlServerDataContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void b_Migrate_Click(object sender, EventArgs e)
        {
            using (context)
            {
                context.Database.Migrate();
            }
        }
    }
}
