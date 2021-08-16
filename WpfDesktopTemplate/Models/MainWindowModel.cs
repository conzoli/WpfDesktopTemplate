using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDesktopTemplate.Models
{
    public class MainWindowModel
    {

        public int windowsSizeHeight { get; set; }

        public int windowsSizeWidth { get; set; }

        public string windowTitle { get; set; }


        public string HomeButtonClickedColor { get; set; }

        public string SettingsButtonClickedColor { get; set; }

        public string FavButtonClickedColor { get; set; }


        public int navMenuWidth { get; set; }

        public string ActiveColor = "Red";
        public string InactiveColor = "Transparent";


        public MainWindowModel()
        {
            windowsSizeHeight = 800;
            windowsSizeWidth = 1000;

            navMenuWidth = 55;

            HomeButtonClickedColor = ActiveColor;
            SettingsButtonClickedColor = InactiveColor;

            windowTitle = "WpfDesktopTemplate";

        }

    }
}
