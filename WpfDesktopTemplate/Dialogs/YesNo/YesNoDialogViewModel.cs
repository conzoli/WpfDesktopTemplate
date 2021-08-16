using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDesktopTemplate.Dialogs.Service;
using WpfDesktopTemplate.Helper;

namespace WpfDesktopTemplate.Dialogs.YesNo
{
    public class YesNoDialogViewModel : DialogViewModelBase<DialogResults>
    {

        public ICommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public YesNoDialogViewModel( string message, string title ) : base( message, title )
        {
            YesCommand = new RelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);
        }


        public void Yes(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.Yes);
        }

        public void No(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.No);
        }

    }
}
