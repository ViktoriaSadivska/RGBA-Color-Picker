using exam.Infrastructure;
using exam.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace exam.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<MyColor> _colors;
        public ObservableCollection<MyColor> Colors
        {
            get
            {
                if(_colors == null)
                {
                    _colors = ColorRepository.AllColors;
                }
                return _colors;
            }
        }



        MyColor _currentColor;
        public MyColor CurrentColor
        {
            get
            {
                if(_currentColor == null)
                {
                    _currentColor = new MyColor();
                }
                return _currentColor;
            }
            set
            {
                _currentColor = value;
                OnPropertyChanged(nameof(CurrentColor));
            }
        }
        public int CurrentColorA
        {
            get
            {
                return CurrentColor.A;
            }
            set
            {
                CurrentColor.A = value;
                OnPropertyChanged(nameof(CurrentColor));
            }
        }
        public int CurrentColorR
        {
            get
            {
                return CurrentColor.R;
            }
            set
            {
                CurrentColor.R = value;
                OnPropertyChanged(nameof(CurrentColor));
            }
        }
        public int CurrentColorG
        {
            get
            {
                return CurrentColor.G;
            }
            set
            {
                CurrentColor.G = value;
                OnPropertyChanged(nameof(CurrentColor));
            }
        }
        public int CurrentColorB
        {
            get
            {
                return CurrentColor.B;
            }
            set
            {
                CurrentColor.B = value;
                OnPropertyChanged(nameof(CurrentColor));
            }
        }



        MyColor _selectedColor;
        public MyColor SelectedColor
        {
            get
            {
                if (_selectedColor == null)
                {
                    _selectedColor = new MyColor();
                }
                return _selectedColor;
            }
            set
            {
                _selectedColor = value;
                OnPropertyChanged(nameof(SelectedColor));
            }
        }


      
        RelayCommand _addColorCommand;
        public ICommand AddColorCommand
        {
            get
            {
                if(_addColorCommand == null)
                {
                    _addColorCommand = new RelayCommand(ExecuteAddColorCommand, CanExecuteAddColorCommand);
                }
                return _addColorCommand;
            }
        }

        public void ExecuteAddColorCommand(object parameter)
        {
            Colors.Add(CurrentColor);
            CurrentColor = new MyColor(CurrentColorA, CurrentColorR, CurrentColorG, CurrentColorB);
        }

        public bool CanExecuteAddColorCommand(object parameter)
        {
            if (Colors.Any(p => p.A == CurrentColorA && p.R == CurrentColorR && p.G == CurrentColorG && p.B == CurrentColorB))
                return false;
           
            return true;
        }



        RelayCommand _deleteColorCommand;
        public ICommand DeleteColorCommand
        {
            get
            {
                return _deleteColorCommand ??
                    (_deleteColorCommand = new RelayCommand(
                        parameter => Colors.RemoveAt((int)parameter),
                        parameter => Colors.Count != 0
                        ));
            }
        }


        protected override void OnDispose()
        {
            this.Colors.Clear();
        }


        RelayCommand _changeThemeCommand;
        public ICommand ChangeThemeCommand
        {
            get
            {
                return _changeThemeCommand ??
                   (_changeThemeCommand = new RelayCommand(
                       parameter => {
                           App.Current.MainWindow.Resources.Source = new Uri((string)parameter, UriKind.Relative);
                       },
                       parameter => ((string)parameter).EndsWith(".xaml")
                       ));
            }
        }
    }
}
