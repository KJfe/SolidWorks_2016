using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SolidWorks_2016.View;
using SolidWorks_2016.ViewModel;

namespace SolidWorks_2016
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var mw = new PlaginWindowView
            {
                DataContext = new MainViewModel()
            };

            mw.Show();
        }
    }
}
