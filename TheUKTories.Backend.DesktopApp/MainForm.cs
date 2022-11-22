using TheUKTories.Services.Data.EFCore;

namespace TheUKTories.Backend.DesktopApp
{
    public partial class MainForm : Form
    {
        private readonly SqlServerDataContext context;

        public MainForm(SqlServerDataContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void b_DbTools_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using Dialogs.DatabaseForm form = new Dialogs.DatabaseForm(context);
            form.ShowDialog();
        }

        private void b_NewAltRight_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using ModelForms.FacistTacticForm form = new ModelForms.FacistTacticForm(context);
            form.ShowDialog();
        }

        private void b_UKAusterityNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void b_AllTactics_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using Dialogs.FacistTacticEditForm form = new Dialogs.FacistTacticEditForm(context);
            form.ShowDialog();
        }
    }
}