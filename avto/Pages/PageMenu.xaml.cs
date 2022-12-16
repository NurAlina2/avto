using avto.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace avto.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        int actualPage = 0;
        public PageMenu()
        {
            DbConnect.db.Product.Load();
            Products = DbConnect.db.Product.Local;
            InitializeComponent();
            //ListProduct.Items.Clear();
            if (Navigation.AuthUser.RoleId == 2)
                AddNewProductBtn.Visibility = Visibility.Collapsed;
            else if (Navigation.AuthUser.RoleId == 4)
                OrdersBtn.Visibility = Visibility.Collapsed;

            ListProduct.ItemsSource = DbConnect.db.Product.Where(x => x.IsActive != false).ToList();
            GeneralCount.Text = DbConnect.db.Product.Where(x => x.IsActive != false).Count().ToString();
        }

        public ObservableCollection<Product> Products
        {
            get { return (ObservableCollection<Product>)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }
        public static readonly DependencyProperty ProductsProperty = DependencyProperty.Register("Products", typeof(ObservableCollection<Product>), typeof(PageMenu));
        
        private void Refresh()
        {
            IEnumerable<Product> prodL = DbConnect.db.Product;
            ObservableCollection<Product> products = Products;
            {
                if (CbSort == null)
                    return;

                if (CbSort.SelectedItem != null)
                {
                    switch ((CbSort.SelectedItem as ComboBoxItem).Tag)
                    {
                        case "1":

                            prodL = DbConnect.db.Product;
                            break;
                        case "2":

                            prodL = prodL.OrderBy(x => x.Name);
                            break;
                        case "3":

                            prodL = prodL.OrderByDescending(x => x.Name);

                            break;
                        case "4":

                            prodL = prodL.OrderBy(x => x.DateOfAddition);
                            break;
                        case "5":

                            prodL = prodL.OrderByDescending(x => x.DateOfAddition);
                            break;

                    }

                }


                if (TxtSearch == null)
                    return;
                if (TxtSearch.Text.Length > 0)
                {

                    prodL = prodL.Where(x => x.Name.StartsWith(TxtSearch.Text) || x.Description.StartsWith(TxtSearch.Text));
                }


                if (CbFiltration == null)
                    return;
                if (CbFiltration.SelectedItem != null)
                {
                    switch ((CbFiltration.SelectedItem as ComboBoxItem).Tag)
                    {
                        case "1":

                            prodL = DbConnect.db.Product;
                            break;
                        case "2":

                            prodL = prodL.Where(x => x.CategorId == 2);
                            break;
                        case "3":

                            prodL = prodL.Where(x => x.CategorId == 1);
                            break;
                    }
                }

                if (CbCount.SelectedIndex > 0 && products.Count() > 0)
                {
                    int selCount = Convert.ToInt32((CbCount.SelectedItem as ComboBoxItem).Content);
                    products = new ObservableCollection<Product>(Products.Skip(selCount * actualPage).Take(selCount));
                    if (products.Count() == 0)
                    {
                        actualPage--;

                    }
                }

                FoundCount.Text = products.Count().ToString() + " из ";
            }

            ListProduct.ItemsSource = prodL.ToList();

        }

        private void AddNewProductBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Nav("Добавление продукции", new EditPage (new Product())));
        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Nav("Список заказов продукции", new OrderPage()));
        }

        private void DecBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Nav("Оформление заказа", new DecorationOrderPage()));
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            actualPage = 0;
            Refresh();
        }

        private void CbCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CbFiltration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            actualPage = 0;
            Refresh();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualPage = 0;
            Refresh();
        }

        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            actualPage--;
            if (actualPage < 0)
                actualPage = 0;
            Refresh();
        }
        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            actualPage++;
            Refresh();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selProduct = (sender as Button).DataContext as Product;
            Navigation.NextPage(new Nav("Редактирование продукции", new EditPage(selProduct)));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selProduct = (sender as Button).DataContext as Product;
            if (MessageBox.Show("Вы точно хотите удалить эту запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                selProduct.IsActive = false;
                MessageBox.Show("Запись удалена");
                DbConnect.db.SaveChanges();
                ListProduct.ItemsSource = DbConnect.db.Product.ToList();
            }
        }
    }
}
