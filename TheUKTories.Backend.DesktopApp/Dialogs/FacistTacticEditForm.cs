using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TheUKTories.Backend.DesktopApp.Controls;

namespace TheUKTories.Backend.DesktopApp.Dialogs
{
    public partial class FacistTacticEditForm : Form
    {
        private readonly SqlServerDataContext context;
        public FacistTactic SelectedFacist { get; set; }

        public FacistTacticEditForm(SqlServerDataContext context)
        {
            InitializeComponent();
            this.context = context;
            c_Data.SetupTactics(context);
        }

        private void FacistTacticEditForm_Load(object sender, EventArgs e)
        {
        }

        private async void c_Data_SelectedIndexChanged(object sender, EventArgs e) { }

        private async void c_Data_DoubleClick(object sender, EventArgs e)
        {
            var selected_id = c_Data.SelectedItems[0].Text;
            int.TryParse(selected_id, out int final_id);
            SelectedFacist = await context.FacistTactics.Where(i => i.FacistTacticId == final_id).SingleOrDefaultAsync();

            using ModelForms.FacistTacticForm form = new ModelForms.FacistTacticForm(SelectedFacist, context);
            form.ShowDialog();

            c_Data.SetupTactics(context);
        }
    }
}
