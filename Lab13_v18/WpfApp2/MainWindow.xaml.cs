using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;

namespace WPFProductInventory
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private const string FilePath = "products.bin";
        private readonly Encoding _encoding = Encoding.UTF8;
        private double _totalLoss;

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public double TotalLoss
        {
            get { return _totalLoss; }
            set
            {
                _totalLoss = value;
                OnPropertyChanged(nameof(TotalLoss));
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            LoadProductsFromFile();
            CalculateTotalLoss();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void LoadProductsFromFile()
        {
            if (!File.Exists(FilePath)) return;

            Products.Clear();
            try
            {
                using (var reader = new BinaryReader(File.Open(FilePath, FileMode.Open), _encoding))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        try
                        {
                            Product product = ReadProduct(reader);
                            Products.Add(product);
                        }
                        catch (EndOfStreamException)
                        {
                            MessageBox.Show("Ошибка чтения информации: Неожиданное завершение.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка чтения информации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SaveProductsToFile()
        {
            try
            {
                using (var writer = new BinaryWriter(File.Open(FilePath, FileMode.Create), _encoding))
                {
                    foreach (var product in Products)
                    {
                        WriteProduct(writer, product);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохраниения продукта в файл: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CalculateTotalLoss()
        {
            TotalLoss = 0;
            foreach (var product in Products)
            {
                if (DateTime.Now.Year - product.Year > 5)
                {
                    TotalLoss += product.Quantity * product.Price;
                }
            }
        }
        private static void WriteProduct(BinaryWriter writer, Product product)
        {
            writer.Write(product.Name);
            writer.Write(product.Year);
            writer.Write(product.Quantity);
            writer.Write(product.Manufacturer);
            writer.Write(product.Price);
        }
        private static Product ReadProduct(BinaryReader reader)
        {
            Product product = new Product();
            product.Name = reader.ReadString();
            product.Year = reader.ReadInt32();
            product.Quantity = reader.ReadInt32();
            product.Manufacturer = reader.ReadString();
            product.Price = reader.ReadDouble();
            return product;
        }
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            var newProductWindow = new AddProductWindow();
            if (newProductWindow.ShowDialog() == true)
            {
                Products.Add(newProductWindow.NewProduct);
                SaveProductsToFile();
                CalculateTotalLoss();
            }
        }
        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is Product selectedProduct)
            {
                Products.Remove(selectedProduct);
                SaveProductsToFile();
                CalculateTotalLoss();
            }
            else
            {
                MessageBox.Show("Пожалуйста выберите продукт для удаления.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            SaveProductsToFile();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is Product selectedProduct)
            {
                var editProductWindow = new EditProductWindow(selectedProduct);
                if (editProductWindow.ShowDialog() == true)
                {
                    SaveProductsToFile();
                    CalculateTotalLoss();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста выберите продукт для редактирования.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
    }

    public class AddProductWindow : Window
    {
        public Product NewProduct { get; set; }
        private TextBox nameTextBox;
        private TextBox yearTextBox;
        private TextBox quantityTextBox;
        private TextBox manufacturerTextBox;
        private TextBox priceTextBox;

        public AddProductWindow()
        {
            Title = "Добавить новый продукт";
            Width = 300;
            Height = 350;

            var stackPanel = new StackPanel { Margin = new Thickness(10) };
            stackPanel.Children.Add(new Label { Content = "Имя:" });
            nameTextBox = new TextBox();
            stackPanel.Children.Add(nameTextBox);
            stackPanel.Children.Add(new Label { Content = "Год:" });
            yearTextBox = new TextBox();
            stackPanel.Children.Add(yearTextBox);
            stackPanel.Children.Add(new Label { Content = "Количество:" });
            quantityTextBox = new TextBox();
            stackPanel.Children.Add(quantityTextBox);
            stackPanel.Children.Add(new Label { Content = "Производитель:" });
            manufacturerTextBox = new TextBox();
            stackPanel.Children.Add(manufacturerTextBox);
            stackPanel.Children.Add(new Label { Content = "Цена:" });
            priceTextBox = new TextBox();
            stackPanel.Children.Add(priceTextBox);
            var addButton = new Button { Content = "Добавить", Margin = new Thickness(0, 10, 0, 0) };
            addButton.Click += AddButton_Click;
            stackPanel.Children.Add(addButton);
            Content = stackPanel;
            nameTextBox.Focus();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text) ||
                !int.TryParse(yearTextBox.Text, out int year) ||
                !int.TryParse(quantityTextBox.Text, out int quantity) ||
                string.IsNullOrEmpty(manufacturerTextBox.Text) ||
                !double.TryParse(priceTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double price))
            {
                MessageBox.Show("Пожалуйста заполните поля правильно.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewProduct = new Product
            {
                Name = nameTextBox.Text,
                Year = year,
                Quantity = quantity,
                Manufacturer = manufacturerTextBox.Text,
                Price = price
            };

            DialogResult = true;
            Close();
        }
    }

    public class EditProductWindow : Window
    {
        private Product _product;
        private TextBox nameTextBox;
        private TextBox yearTextBox;
        private TextBox quantityTextBox;
        private TextBox manufacturerTextBox;
        private TextBox priceTextBox;

        public EditProductWindow(Product product)
        {
            _product = product;

            Title = "Редактировать продукт";
            Width = 300;
            Height = 350;

            var stackPanel = new StackPanel { Margin = new Thickness(10) };

            stackPanel.Children.Add(new Label { Content = "Имя:" });
            nameTextBox = new TextBox { Text = _product.Name };
            stackPanel.Children.Add(nameTextBox);

            stackPanel.Children.Add(new Label { Content = "Год:" });
            yearTextBox = new TextBox { Text = _product.Year.ToString() };
            stackPanel.Children.Add(yearTextBox);

            stackPanel.Children.Add(new Label { Content = "Количество:" });
            quantityTextBox = new TextBox { Text = _product.Quantity.ToString() };
            stackPanel.Children.Add(quantityTextBox);

            stackPanel.Children.Add(new Label { Content = "Производитель:" });
            manufacturerTextBox = new TextBox { Text = _product.Manufacturer };
            stackPanel.Children.Add(manufacturerTextBox);

            stackPanel.Children.Add(new Label { Content = "Цена:" });
            priceTextBox = new TextBox { Text = _product.Price.ToString(CultureInfo.InvariantCulture) }; // Use InvariantCulture
            stackPanel.Children.Add(priceTextBox);

            var saveButton = new Button { Content = "Сохранить", Margin = new Thickness(0, 10, 0, 0) };
            saveButton.Click += SaveButton_Click;
            stackPanel.Children.Add(saveButton);

            Content = stackPanel;

            nameTextBox.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text) ||
                !int.TryParse(yearTextBox.Text, out int year) ||
                !int.TryParse(quantityTextBox.Text, out int quantity) ||
                string.IsNullOrEmpty(manufacturerTextBox.Text) ||
                !double.TryParse(priceTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double price)) // Use NumberStyles.Any & InvariantCulture
            {
                MessageBox.Show("Пожалуйста заполните поля правильно.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _product.Name = nameTextBox.Text;
            _product.Year = year;
            _product.Quantity = quantity;
            _product.Manufacturer = manufacturerTextBox.Text;
            _product.Price = price;

            DialogResult = true;
            Close();
        }
    }
}
