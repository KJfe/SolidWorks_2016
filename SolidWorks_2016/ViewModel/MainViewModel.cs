using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks_2016.Model;
using System.Windows;
using System.Windows.Input;

namespace SolidWorks_2016.ViewModel
{
    class MainViewModel
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainViewModel()
        {
            ClickCommand = new Command(arg => ClickMethod());
            ParametrsEndHead = new ParametrsEndHeadModel
            {
                RadiusFirstCylinder = "0",
                RadiusSecondCylinder = "0",
                HeightFirstCylinder = "0",
                HeightSecondCylinder = "0",
                DeepExtrusionFirstCylinder = "0"
            };

            /*var People = new PeopleModel
            {
                FirstName = "",
                LastName = ""
            };*/
        }

        public ParametrsEndHeadModel ParametrsEndHead { get; set; }


        public ICommand ClickCommand { get; set; }
        private void ClickMethod()
        {
            MessageBox.Show("This is click command.");
        }
        /// <summary>
        /// Get or set people.
        /// </summary>
        public PeopleModel People { get; set; }
    }
}
