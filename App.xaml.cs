using Microsoft.Maui.Controls;
using MVVMApp.Models;
using System.IO;

namespace MVVMApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "friends.db";
        private static FriendRepository _database;

        public static FriendRepository Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new FriendRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.LoginPage());
        }
    }
}
