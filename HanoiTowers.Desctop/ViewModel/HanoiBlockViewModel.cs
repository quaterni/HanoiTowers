using HanoiTowers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTowers.Desctop.ViewModel
{
    public class HanoiBlockViewModel : ViewModelBase
    {
        private HanoiBlock _hanoiBlock;

        public HanoiBlock HanoiBlock
        {
            get
            {
                return _hanoiBlock;
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
        }
    }
}
