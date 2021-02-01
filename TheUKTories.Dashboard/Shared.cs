using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AdonisUI;
using AdonisUI.Controls;
using TheUKTories.DataStores.AzureCosmos;
using TheUKTories.DataStores.AzureCosmos.Models;


namespace TheUKTories.Dashboard
{
    public static class Shared
    {
        public static bool ValidateListOfControls(bool dialog = false, params Control[] controls)
        {
            foreach (var c in controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    var a = (TextBox)c;
                    if (string.IsNullOrWhiteSpace(a.Text))
                    {
                        if (dialog) ShowValidationDialog(a.Name);
                        return false;
                    }
                }
                if (c.GetType() == typeof(ComboBox))
                {
                    var a = (ComboBox)c;
                    if (a.SelectedValue == null || string.IsNullOrWhiteSpace(a.Text))
                    {
                        if (dialog) ShowValidationDialog(a.Name);
                        return false;
                    }
                }
            }
            return true;
        }

        static void ShowValidationDialog(string name)
        {
            AdonisUI.Controls.MessageBox.Show($"All fields must be populated\n{name}", 
                "Validation Error", 
                AdonisUI.Controls.MessageBoxButton.OK);
        }
    }
}
