using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;

namespace WpfDesktopTemplate.Models
{
    public class FavUserControlModel
    {


        public List<String> SampleComboBoxContent { get; set; }

        public string TestString = "";

        public int SliderValue { get; set; }



        public FavUserControlModel()
        {

            SampleComboBoxContent = new List<string>()
            {
                "Eins",
                "Zwei",
                "Drei",
                "Vier",
                "Fünf"
            };

            ResourceManager rm = new ResourceManager("WpfDesktopTemplate.Resources.Strings", Assembly.GetExecutingAssembly());

            TestString = rm.GetString("Test");

            SliderValue = 0;

        }

    }
}
