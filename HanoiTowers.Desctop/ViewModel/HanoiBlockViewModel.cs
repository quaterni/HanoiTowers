using HanoiTowers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HanoiTowers.Desctop.ViewModel
{
    public class HanoiBlockViewModel : ViewModelBase
    {
        private HanoiBlock _hanoiBlock;

        public HanoiBlock HanoiBlock
        {
            get { return _hanoiBlock; }
        }

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


        private double _blockWidth;

        public double BlockWidth
        {
            get
            {
                return _blockWidth; 
            }
            set
            {
                _blockWidth = value; 
                OnPropertyChanged(nameof(BlockWidth));
            }
        }

        public HanoiBlockViewModel(HanoiBlock hanoiBlock, double blockWidth)
        {
            _hanoiBlock = hanoiBlock;
            _blockWidth = blockWidth;
            _hanoiBlock.PropertyChanged += OnActivityChanged;
        }

        private void OnActivityChanged(object? sender, PropertyChangedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() => IsActive = _hanoiBlock.IsActive);
            Task.Delay(400).Wait();
        }
    }
}
