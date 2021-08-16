using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDesktopTemplate.Dialogs.Alert;
using WpfDesktopTemplate.Dialogs.Service;
using WpfDesktopTemplate.Dialogs.YesNo;
using WpfDesktopTemplate.Helper;

using WpfDesktopTemplate.Models;

namespace WpfDesktopTemplate.ViewModels
{


    public class FavUserControlViewModel : NotifyObject
    {

        readonly FavUserControlModel _model;

        private IDialogService _dialogService;

        public FavUserControlViewModel()
        {
            _model = new FavUserControlModel();
            _dialogService = new DialogService();

        }




        public List<string> ComboBoxSampleData
        {
            get
            {
                return _model.SampleComboBoxContent;
            }
            set
            {
                if(_model.SampleComboBoxContent != value)
                {
                    _model.SampleComboBoxContent = value;
                    RaisePropertyChanged(nameof(ComboBoxSampleData));
                }
            }
        }

        public string TestString
        {
            get
            {
                return _model.TestString;
            }
            set
            {
                if(_model.TestString != value)
                {
                    _model.TestString = value;
                    RaisePropertyChanged(nameof(TestString));
                }
            }
        }

        public int SliderValue
        {
            get
            {
                return _model.SliderValue;
            }
            set
            {
                if(_model.SliderValue != value)
                {
                    _model.SliderValue = value;
                    RaisePropertyChanged(nameof(SliderValue));
                }
            }
        }


        // commands

        public void DoDialogTestClick()
        {
            var dialog = new AlertDialogViewModel("Achtung!", "Das ist ein Alarm!");
            var result = _dialogService.OpenDialog(dialog);

            Console.WriteLine(result);
        }

        public ICommand DialogTestClick
        {
            get
            {
                return new RelayCommand(DoDialogTestClick);
            }
        }



        public void DoDialogYesNoTestClick()
        {
            var dialog = new YesNoDialogViewModel("Frage", "Ja oder Nein? Das ist hier die Frage");
            var result = _dialogService.OpenDialog(dialog);

            Console.WriteLine(result);

            if(result == Dialogs.DialogResults.Yes)
            {
                var infoDialog = new AlertDialogViewModel("Antwort", "Die Antwort war JA!");
                var r = _dialogService.OpenDialog(infoDialog);
            }

            if(result == Dialogs.DialogResults.No)
            {
                var infoDialog = new AlertDialogViewModel("Antwort", "Die Antwort war NEIN!");
                var r = _dialogService.OpenDialog(infoDialog);
            }

        }

        public ICommand DialogYesNoTestClickCommand
        {
            get
            {
                return new RelayCommand(DoDialogYesNoTestClick);
            }
        } 

    }
}
