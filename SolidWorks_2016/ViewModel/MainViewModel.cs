using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks_2016.Model;


namespace SolidWorks_2016.ViewModel
{
    class MainViewModel
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainViewModel()
        {
            People = new PeopleModel
            {
                FirstName = "First name",
                LastName = "Last name"
            };
        }
        /// <summary>
        /// Get or set people.
        /// </summary>
        public PeopleModel People { get; set; }
    }
}
