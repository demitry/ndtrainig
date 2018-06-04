using FirstApp.MenuItems;
using FirstApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstApp
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> MenuList
        {
            get;
            set;
        }
        public MainPage()
        {
            InitializeComponent();

            MenuList = new List<MasterPageItem>
            {
                // Adding menu items to menuList and you can define title ,page and icon  
                new MasterPageItem()
                {
                    Title = "Home",
                    Icon = "homeicon.png",
                    TargetType = typeof(HomePage)
                },
                new MasterPageItem()
                {
                    Title = "Contact",
                    Icon = "contacticon.png",
                    TargetType = typeof(HomePage)
                },
                new MasterPageItem()
                {
                    Title = "About",
                    Icon = "abouticon.png",
                    TargetType = typeof(HomePage)
                },
                new MasterPageItem()
                {
                    Title = "Main",
                    Icon = "icon.png",
                    TargetType = typeof(HomePage)
                }
            };
            // Setting our list to be ItemSource for ListView in MainPage.xaml  
            navigationDrawerList.ItemsSource = MenuList;
            // Initial navigation, this can be used for our home page  
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
        }
        // Event for Menu Item selection, here we are going to handle navigation based  
        // on user selection in menu ListView  
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}