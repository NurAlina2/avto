using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using avto.Components;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using avto.Pages;


namespace avto.Components
{
    class Navigation
    {
        public static MainWindow main;
        public static List<Nav> navs = new List<Nav>();
        public static User AuthUser = null;
        public static bool isAuth = false;
        public static void NextPage(Nav nav)
        {
            navs.Add(nav);
            Update(nav);
        }
        private static void Update(Nav nav)
        {
            main.FrameMain.Navigate(nav.Page);
        }
        public static void BackPage()
        {
            if (navs.Count > 1)
            {
                navs.RemoveAt(navs.Count - 1);

            }
            Update(navs[navs.Count - 1]);
        }

    }
    class Nav
    {
        public string Title { get; set; }
        public Page Page { get; set; }
        public Nav(string Title, Page Page)
        {
            this.Title = Title;
            this.Page = Page;
        }
    }
}
