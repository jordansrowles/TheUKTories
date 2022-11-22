using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheUKTories.Backend.DesktopApp.ModelForms
{
    public partial class FacistTacticForm : Form
    {
        private readonly FacistTactic tactic;
        private readonly SqlServerDataContext context;

        public FacistTacticForm(SqlServerDataContext context)
        {
            InitializeComponent();
            this.tactic = new FacistTactic();
            this.context = context;
        }
        public FacistTacticForm(FacistTactic tactic, SqlServerDataContext context)
        {
            this.InitializeComponent();
            this.tactic = tactic;
            this.context = context;

            c_Title.Text = tactic.Title;
            c_Subtitle.Text = tactic.Subtitle;
            c_Link.Text = tactic.Link;
        }

        private async void b_Submit_Click(object sender, EventArgs e)
        {
            tactic.Title = c_Title.Text;
            tactic.Subtitle = c_Subtitle.Text;
            tactic.Link = c_Link.Text;

            if (tactic.FacistTacticId == null)
                context.FacistTactics.Add(tactic);
            else context.FacistTactics.Update(tactic);

            context.SaveChanges();

            this.Close();
        }
    }
}
