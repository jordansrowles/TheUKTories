using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUKTories.Backend.DesktopApp.Controls
{
    public static class ListViewHelpers
    {
        public static ListView SetupTactics(this ListView control, SqlServerDataContext context)
        {
            control.Clear();

            var items = context.FacistTactics?.ToList();

            if (items != null)
            {
                foreach (var item in items)
                {
                    ListViewItem row = new ListViewItem(item.FacistTacticId.ToString());
                    row.SubItems.Add(item.Title);
                    control.Items.Add(row);
                }
            }

            return control;
        }
    }
}
