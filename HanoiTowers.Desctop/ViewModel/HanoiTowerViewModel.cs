using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HanoiTowers.Data;
using HanoiTowers.Desctop.Commands;
using HanoiTowers.Desctop.Service;

namespace HanoiTowers.Desctop.ViewModel
{
    public class HanoiTowerViewModel : ViewModelBase
    {
        private HanoiTower _currentHanoiTower;

        private List<HanoiBlockViewModel> _blocks;

        public HanoiTower CurrentHanoiTower
        {
            get
            {
                return _currentHanoiTower;
            }
            set
            {
                _currentHanoiTower = value;
                OnPropertyChanged(nameof(CurrentHanoiTower));
            }
        }

        private HanoiTowerViewModelState _state;

        public HanoiTowerViewModelState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }

        private bool _isBusy = false;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set 
            { 
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public HanoiStackType TowerLocation
        {
            get 
            {
                if(LeftStack.Count != 0)
                {
                    return HanoiStackType.Left;
                }

                if (CenterStack.Count != 0)
                {
                    return HanoiStackType.Center;
                }

                return HanoiStackType.Right;
            }

        }


        private ObservableCollection<HanoiBlockViewModel> _leftStack;

        public ObservableCollection<HanoiBlockViewModel> LeftStack
        {
            get
            {
                return _leftStack;
            }
            set
            {
                _leftStack = value;
                OnPropertyChanged(nameof(LeftStack));
            }
        }

        private ObservableCollection<HanoiBlockViewModel> _centerStack;

        public ObservableCollection<HanoiBlockViewModel> CenterStack
        {
            get
            {
                return _centerStack;
            }
            set
            {
                _centerStack = value;
                OnPropertyChanged(nameof(_centerStack));
            }
        }

        private ObservableCollection<HanoiBlockViewModel> _rightStack;

        public ObservableCollection<HanoiBlockViewModel> RightStack
        {
            get
            {
                return _rightStack;
            }
            set
            {
                _rightStack = value;
                OnPropertyChanged(nameof(_rightStack));
            }
        }

        public ICommand CreateTowerCommand { get; set; }

        public ICommand MoveTowerCommand { get; set; }


        public HanoiTowerViewModel()
        {
            CreateTowerCommand = new CreateTowerCommand(this);
            MoveTowerCommand = new MoveTowerCommand(this);
            LeftStack = new();
            CenterStack = new();
            RightStack = new();
            _blocks = new();
            State = HanoiTowerViewModelState.Creation;
        }

        public void SetTower(int blockCount)
        {
            HanoiTower hanoiTower = new HanoiTowerCreator().CreateHanoiTower(blockCount);
            this.CurrentHanoiTower = hanoiTower;
            hanoiTower.BlockMoved += this.OnBlockMoved;
            EvaluateTower();
            State = HanoiTowerViewModelState.Readiness;
        }

        private void EvaluateTower()
        {
            TowerEvaluatorSevice evaluator = new();

            _blocks.Clear();

            LeftStack.Clear(); 
            CenterStack.Clear();
            RightStack.Clear();
            foreach(HanoiBlockViewModel item in evaluator.EvaluateTower(CurrentHanoiTower[HanoiStackType.Left]))
            {
                LeftStack.Add(item);
                _blocks.Add(item);
            }
        }

        private void Update()
        {
            // Надо иметь ссылку на все блоки HanoiBlockViewModel чтобы не пересоздавать их
            LeftStack.Clear();
            CenterStack.Clear();
            RightStack.Clear();

            foreach(var item in _currentHanoiTower[HanoiStackType.Left])
            {
                var itemViewModel = _blocks.Find((t) => t.HanoiBlock == item);
                if (itemViewModel != null)
                {
                    LeftStack.Add(itemViewModel);
                }
            }

            foreach (var item in _currentHanoiTower[HanoiStackType.Center])
            {
                var itemViewModel = _blocks.Find((t) => t.HanoiBlock == item);
                if (itemViewModel != null)
                {
                    CenterStack.Add(itemViewModel);
                }
            }

            foreach (var item in _currentHanoiTower[HanoiStackType.Right])
            {
                var itemViewModel = _blocks.Find((t) => t.HanoiBlock == item);
                if(itemViewModel != null)
                {
                    RightStack.Add(itemViewModel);
                }
            }
        }

        public void OnBlockMoved(HanoiTower sender, BlockMovedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() => Update());
            Task.Delay(500).Wait();
        }
    }
}
