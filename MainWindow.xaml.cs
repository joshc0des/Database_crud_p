using Database_crud_p.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Database_crud_p
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoonerCoContext db = new SoonerCoContext();
        private bool ShouldLoadToys;
        private bool ShouldLoadOwners;
        private bool ShouldLoadDogs;

        public MainWindow()
        {
            InitializeComponent();
            ShouldLoadToys = false;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //LoadToys(ShouldLoadToys);
            //LoadOwners(ShouldLoadOwners);
            //LoadDogs(ShouldLoadDogs);

            DisplayDatabaseContent();
        }

        private void DisplayDatabaseContent()
        {
            lstBoxDogs.Items.Clear();
            lstBoxToys.Items.Clear();
            lstBoxDogToys.Items.Clear();

            imgDog.Visibility = Visibility.Hidden;
            imgToy.Visibility = Visibility.Hidden;

            foreach (var dog in db.Dogs)
            {
                lstBoxDogs.Items.Add(dog);
            }

            foreach (var toy in db.Toys)
            {
                lstBoxToys.Items.Add(toy);
            }

            foreach (var dogToy in db.DogToys.Include(x => x.Dog).Include(y => y.Toy))
            {
                lstBoxDogToys.Items.Add(dogToy);
            }
        }

        //private void DisplayOwners()
        //{
        //    foreach (var toy in db.Toys)
        //    {
        //        lstBoxData.Items.Add(toy);
        //    }
        //}

        //private void DisplayToys()
        //{
        //    foreach (var toy in db.Toys)
        //    {
        //        lstBoxData.Items.Add(toy);
        //    }
        //}

        //private void LoadToys(bool load)
        //{
        //    if (load == false) return;

        //    string toyInputJson = File.ReadAllText("Toys.json");
        //    var toys = JsonConvert.DeserializeObject<List<ToyInput>>(toyInputJson);

        //    foreach (var toy in toys)
        //    {
        //        db.Toys.Add(new Toy(toy));
        //    }

        //    db.SaveChanges();
        //}

        //private void LoadDogs(bool load)
        //{
        //    if (load == false) return;

        //    string dogInputJson = File.ReadAllText("Dogs.json");
        //    var dogs = JsonConvert.DeserializeObject<List<DogInput>>(dogInputJson);

        //    foreach (var dog in dogs)
        //    {
        //        db.Dogs.Add(new Dog(dog));
        //    }

        //    db.SaveChanges();
        //}

        //private void LoadOwners(bool load)
        //{
        //    if (load == false) return;

        //    string ownerInputJson = File.ReadAllText("Owners.json");
        //    var owners = JsonConvert.DeserializeObject<List<OwnerInput>>(ownerInputJson);

        //    foreach (var owner in owners)
        //    {
        //        db.Owners.Add(new Owner(owner));
        //    }

        //    db.SaveChanges();
        //}

        private void lstBoxToys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Toy selected = (Toy)lstBoxToys.SelectedItem;
            if (selected == null) return;
            imgToy.Source = new BitmapImage(new Uri(selected.Image));
            imgToy.Visibility = Visibility.Visible;
        }

        private void lstBoxDogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dog selected = (Dog)lstBoxDogs.SelectedItem;
            if (selected == null) return;
            imgDog.Source = new BitmapImage(new Uri(selected.Image));
            imgDog.Visibility = Visibility.Visible;
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            Dog selectedDog = (Dog)lstBoxDogs.SelectedItem;
            Toy selectedToy = (Toy)lstBoxToys.SelectedItem;

            if (selectedDog is null || selectedToy is null)
            {
                return;
            }

            DogToy dt = new DogToy()
            {
                DogId = selectedDog.Id,
                ToyId = selectedToy.Id
            };

            db.DogToys.Add(dt);
            db.SaveChanges();

            DisplayDatabaseContent();
        }

        private void btnDeleteDogToy_Click(object sender, RoutedEventArgs e)
        {
            DogToy selectedDog = (DogToy)lstBoxDogToys.SelectedItem;

            db.DogToys.Remove(selectedDog);
            db.SaveChanges();

            DisplayDatabaseContent();
        }
    }
}
