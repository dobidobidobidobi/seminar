using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinesweeperMVVM.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _selectedDifficulty;
        public ObservableCollection<UIElement> Items { get; set; }
        public ObservableCollection<string> Difficulties { get; set; }

        public string SelectedDifficulty
        {
            get => _selectedDifficulty;
            set
            {
                if (_selectedDifficulty != value)
                {
                    _selectedDifficulty = value;
                    OnPropertyChanged();
                }
            }
        }

        

        public MainWindowViewModel()
        {
            Difficulties = new ObservableCollection<string> { "Lvl. 1 GOON", "Lvl. 100 Mafia Boss" };
            _selectedDifficulty = Difficulties[0];
            PropertyChanged = delegate { };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
