using Database_crud_p.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Database_crud_p
{
    /// <summary>
    /// Interaction logic for ToyWindow.xaml
    /// </summary>
    public partial class ToyWindow : Window
    {
        public ToyWindow()
        {
            InitializeComponent();
        }

        //public void SetupToyWindow()
        //{
            
        //}

        private void btnSubmitNewToy_Click(object sender, RoutedEventArgs e)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(txtBoxToyName.Text))
            {
                errors.Add("Toy name is missing");
            }
            if (string.IsNullOrEmpty(txtBoxToyImage.Text))
            {
                errors.Add("Toy image link is missing");
            }

            if (errors.Count == 0)
            {
                string hasSqueeker;

                if (checkBoxHasSqueeker.IsChecked == true)
                {
                    hasSqueeker = "Yes";
                } else
                {
                    hasSqueeker = "No";
                }

                ToyInput t = new(txtBoxToyName.Text, txtBoxToyImage.Text, hasSqueeker);
                SoonerCoContext db = new();
                db.Toys.Add(new Toy(t));
                db.SaveChanges();

                txtBoxToyImage.Clear();
                txtBoxToyName.Clear();
                checkBoxHasSqueeker.IsChecked = false;
            }
            else
            {
                string errorStr = $"There are {errors.Count} form errors!\n\n";

                foreach (string error in errors)
                {
                    errorStr += (error + "\n");
                }
                MessageBox.Show(errorStr);
            }
        }
    }
}
