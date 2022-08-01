using System.ComponentModel;

namespace HanoiTowers.Data
{
    public class HanoiBlock : INotifyPropertyChanged
    {
        public HanoiBlock(int weight)
        {
            Weight = weight;
            IsActive = false;
        }

        public int Weight { get; }

        private bool _isActive;

        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}