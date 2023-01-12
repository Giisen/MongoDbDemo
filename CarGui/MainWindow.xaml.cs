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
using DataAccess;
using DataAccess.Models;

namespace CarGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRepositoryCar<Car> _carManager;
        public MainWindow()
        {
            InitializeComponent();
            _carManager = new CarManager();
            UpdateCarView();
        }

        private void Car_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cars.SelectedItem is Car car)
            {
                Make.Text = car.Make;
                Model.Text = car.Model;
                Color.Text = car.Color;
                HorsePower.Text = $"{car.HorsePower}";
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var person = new Car()
            {
                Make = Make.Text,
                Model = Model.Text,
                Color = Color.Text,
                HorsePower = int.Parse(HorsePower.Text)
            };

            _carManager.Add(person);
            UpdateCarView();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Cars.SelectedItem is Car car)
            {
                if (!string.IsNullOrEmpty(Make.Text) && !string.IsNullOrEmpty(Model.Text) && !string.IsNullOrEmpty(Color.Text) && !string.IsNullOrEmpty(HorsePower.Text))
                {
                    var newCar = new Car()
                    {
                        Make = Make.Text,
                        Model = Model.Text,
                        Color = Color.Text,
                        HorsePower = int.Parse(HorsePower.Text)
                    };
                    _carManager.Replace(car.Id, newCar);
                }

                UpdateCarView();
            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Cars.SelectedItem is Car car)
            {
                _carManager.Delete(car.Id);
            }

            UpdateCarView();
        }

        private void UpdateCarView()
        {
            var car = _carManager.GetAll();
            Cars.Items.Clear();
            foreach (var cars in car)
            {
                Cars.Items.Add(cars);
            }

            ClearFields();
        }

        private void ClearFields()
        {
            Make.Text = string.Empty;
            Model.Text = string.Empty;
            Color.Text = string.Empty;
            HorsePower.Text = string.Empty;
        }
    
}
}
