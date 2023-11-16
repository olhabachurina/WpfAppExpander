using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Globalization;
namespace WpfAppExpander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Микроволновая печь", Description = "Мощная микроволновая печь с различными режимами приготовления.", Price = 4550, DateAdded = DateTime.Now },
                new Product { Name = "Блендер", Description = "Многофункциональный блендер для приготовления смузи и коктейлей.", Price = 2080, DateAdded = DateTime.Now },
                new Product { Name = "Кофемашина", Description = "Автоматическая кофемашина с функцией приготовления капучино.", Price = 22500, DateAdded = DateTime.Now },
                new Product { Name = "Тостер", Description = "Электрический тостер для поджаривания вкусных тостов на завтрак.", Price = 4000, DateAdded = DateTime.Now },
                new Product { Name = "Мультиварка", Description = "Мультиварка с большим набором программ для разнообразного приготовления пищи.", Price = 3120, DateAdded = DateTime.Now }
            };
            DataContext = this;
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                Products.Add(new Product
                {
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Price = double.Parse(PriceTextBox.Text),
                    DateAdded = DateTime.Now
                });

                // Очищаем текстовые поля после добавления товара
                NameTextBox.Clear();
                DescriptionTextBox.Clear();
                PriceTextBox.Clear();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка");
                return false;
            }

            try
            {
                double price = Convert.ToDouble(PriceTextBox.Text, CultureInfo.InvariantCulture);
                if (price < 0)
                {
                    MessageBox.Show("Пожалуйста, введите корректную цену.", "Ошибка");
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректную цену.", "Ошибка");
                return false;
            }

            return true;
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Product product)
            {
                Products.Remove(product);
            }
        }
    }
}
