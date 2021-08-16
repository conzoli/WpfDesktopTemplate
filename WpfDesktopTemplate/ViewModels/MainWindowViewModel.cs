using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDesktopTemplate.Models;

using WpfDesktopTemplate.Helper;
using System.Windows.Controls;

using WpfDesktopTemplate.Views;
using WpfDesktopTemplate.ViewModels;

namespace WpfDesktopTemplate.ViewModels
{
    public class MainWindowViewModel : NotifyObject
    {

        private readonly MainWindowModel _model;

        public MainWindowViewModel()
        {
            _model = new MainWindowModel();
        }

        public MainWindowViewModel( MainWindowModel mainWIndowModel)
        {
            this._model = mainWIndowModel;
        }


        private bool _navMenuEpandState = false;

        public Grid ContentGird { get; set; }


        public int WindowSizeHeight
        {
            get
            {
                return _model.windowsSizeHeight;
            }
            set
            {
                if(_model.windowsSizeHeight != value)
                {
                    _model.windowsSizeHeight = value;
                    RaisePropertyChanged(nameof(WindowSizeHeight));
                }
            }
        }

        public int WindowSizeWidth
        {
            get
            {
                return _model.windowsSizeWidth;
            }
            set
            {
                if(_model.windowsSizeWidth != value)
                {
                    _model.windowsSizeWidth = value;
                    RaisePropertyChanged(nameof(WindowSizeWidth));
                }
            }
        }

        public string WindowTitle
        {
            get
            {
                return _model.windowTitle;
            }
            set
            {
                if(_model.windowTitle != value)
                {
                    _model.windowTitle = value;
                    RaisePropertyChanged(nameof(WindowTitle));
                }
            }
        }



        public int NavMenuWidth
        {
            get
            {
                return _model.navMenuWidth;
            }
            set
            {
                if(_model.navMenuWidth != value)
                {
                    _model.navMenuWidth = value;
                    RaisePropertyChanged(nameof(NavMenuWidth));
                }
            }
        }



        public string HomeButtonClickedColor
        {
            get
            {
                return _model.HomeButtonClickedColor;
            }
            set
            {
                if (_model.HomeButtonClickedColor != value)
                {
                    _model.HomeButtonClickedColor = value;
                    RaisePropertyChanged(nameof(HomeButtonClickedColor));
                }
                
            }
        }
        public string SettingsButtonClickedColor
        {
            get
            {
                return _model.SettingsButtonClickedColor;
            }
            set
            {
                if(_model.SettingsButtonClickedColor != value)
                {
                    _model.SettingsButtonClickedColor = value;
                    RaisePropertyChanged(nameof(SettingsButtonClickedColor));
                }
            }
        }

        public string FavButtonClickedColor
        {
            get
            {
                return _model.FavButtonClickedColor;
            }
            set
            {
                if(_model.FavButtonClickedColor != value)
                {
                    _model.FavButtonClickedColor = value;
                    RaisePropertyChanged(nameof(FavButtonClickedColor));
                }
            }
        }



        //Views

        private HomeUserConstrol _HomeUserControl = null;
        private SettingsUserControl _SettingsUserControl = null;
        private FavUserControl _FavUserControl = null;


        // commands

        private bool CanNavMenuToggle()
        {
            return true;
        }

        private void DoNavMenuToggle()
        {

            if (_navMenuEpandState)
                _navMenuEpandState = false;
            else
                _navMenuEpandState = true;


            if (_navMenuEpandState)
            {
                NavMenuWidth = 250;
            }else
            {
                NavMenuWidth = 55;
            }
            
            
        }

        public ICommand NavMenuToggleCommand
        {
            get
            {
                return new RelayCommand(DoNavMenuToggle, CanNavMenuToggle);
            }
        }



        private bool CanCmdSettingsClick()
        {
            return true;
        }

        private void DoCmdSettingsClick()
        {

            this.ShowSettingsUserControl();

        }

        public ICommand CmdSettingsClickCommand
        {
            get
            {
                return new RelayCommand(DoCmdSettingsClick, CanCmdSettingsClick);
            }
        }



        private bool CanShowHomeClick()
        {
            return true;
        }

        private void DoShowHomeClick()
        {
            this.ShowHomeUserControl();
        }

        public ICommand CmdShowHomeClickCommand
        {
            get
            {
                return new RelayCommand(DoShowHomeClick, CanShowHomeClick);
            }
        }



        private bool CanShowFavClick()
        {
            return true;
        }

        private void DoShowFavClick()
        {
            ShowFavUserControl();
        }

        public ICommand ShowFavClickCommand
        {
            get
            {
                return new RelayCommand(DoShowFavClick, CanShowFavClick);
            }
        }



        private void DoExitProgramm()
        {
            ExitProgramm();
        }

        public ICommand ExitProgrammCommand
        {
            get
            {
                return new RelayCommand(DoExitProgramm);
            }
        }


        // Methods

        public void SetHomeUserControl(HomeUserConstrol homeUserControl)
        {
            this._HomeUserControl = homeUserControl;
        }

        private void ShowSettingsUserControl()
        {

            if (this._SettingsUserControl == null)
            {
                this._SettingsUserControl = new SettingsUserControl();

            }

            if (this.ContentGird != null)
            {
                this.ContentGird.Children.Clear();
                this.ContentGird.Children.Add(this._SettingsUserControl);


                ShowActiveUserControl("SettingsUserControl");

            }

        }

        private void ShowFavUserControl()
        {
            if(this._FavUserControl == null)
            {
                this._FavUserControl = new FavUserControl();
            }

            if( this.ContentGird != null )
            {
                this.ContentGird.Children.Clear();
                this.ContentGird.Children.Add(this._FavUserControl);

                ShowActiveUserControl("FavUserControl");
            }
        }

        private void ShowHomeUserControl()
        {

            if( this.ContentGird != null && this._HomeUserControl != null)
            {
                this.ContentGird.Children.Clear();
                this.ContentGird.Children.Add(this._HomeUserControl);


                ShowActiveUserControl("HomeUserControl");

            }

        }


        private void ShowActiveUserControl(string usercontrolName)
        {
            switch (usercontrolName)
            {
                case "SettingsUserControl":
                    HomeButtonClickedColor = _model.InactiveColor;
                    FavButtonClickedColor = _model.InactiveColor;
                    SettingsButtonClickedColor = _model.ActiveColor;
                    break;

                case "HomeUserControl":
                    HomeButtonClickedColor = _model.ActiveColor;
                    FavButtonClickedColor = _model.InactiveColor;
                    SettingsButtonClickedColor = _model.InactiveColor;
                    break;

                case "FavUserControl":
                    HomeButtonClickedColor = _model.InactiveColor;
                    FavButtonClickedColor = _model.ActiveColor;
                    SettingsButtonClickedColor = _model.InactiveColor;
                    break;
            }
        }


        private void ExitProgramm()
        {
            System.Windows.Application.Current.Shutdown();
        }

        
    }
}
