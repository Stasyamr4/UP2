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

namespace WpfApp4.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        User user = new User();
        List<Product> products = Core.Context.Product.ToList();
        public CatalogPage(User us)
        {
            InitializeComponent();
            user = us;
            ProductList.ItemsSource = products;
        }
        public CatalogPage()
        {
            InitializeComponent();
           
            ProductList.ItemsSource = products;
        }

        private void ProfilButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage(user));
        }
    }
}
