using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HanoiTowers.Data;
using HanoiTowers.Desctop.Commands;
using HanoiTowers.Desctop.Service;

namespace HanoiTowers.Desctop.ViewModel
{
    public class HanoiTowerViewModel : ViewModelBase
    {
        private HanoiTower _currentHanoiTower;

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
                EvaluateTower();
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
            LeftStack = new();
            CenterStack = new();
            RightStack = new();
        }

        private void EvaluateTower()
        {
            TowerEvaluatorSevice evaluator = new();

            LeftStack.Clear(); 
            CenterStack.Clear();
            RightStack.Clear();
            foreach(HanoiBlockViewModel item in evaluator.EvaluateTower(CurrentHanoiTower[HanoiStackType.Left]))
            {
                LeftStack.Add(item);
            }
        }


    }
}
