using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HanoiTowers.Data;
using HanoiTowers.Desctop;
using HanoiTowers.Desctop.ViewModel;

namespace HanoiTowers.Desctop.Commands
{
    public class MoveTowerCommand : AsyncCommandBase
    {
        private HanoiTowerViewModel _viewModel;

        private IHanoiComputer _computer;

        public MoveTowerCommand(HanoiTowerViewModel viewModel)
        {
            _viewModel = viewModel;
            _computer = new HanoiTriangleAlgorithmComputer();
        }

        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter);
        }

        public async override Task ExecuteAsunc(object? parameter)
        {
            if(!int.TryParse((string)parameter, out int numberStack))
            {
                throw new Exception("Not number");
            }
            HanoiStackType towerLocation = _viewModel.TowerLocation;

            HanoiStackType type = (HanoiStackType)numberStack;

            if(towerLocation != type)
            {
                int blockCount = _viewModel.CurrentHanoiTower[towerLocation].Count;
                _viewModel.IsBusy = true;

                await Task.Run(() => _computer.CumputeTower(blockCount, _viewModel.CurrentHanoiTower, towerLocation, type));
            }
        }

        public override void OnExeption(Exception ex)
        {
            base.OnExeption(ex);
        }

        public override void OnFinally()
        {
            base.OnFinally();
            _viewModel.IsBusy = false;
        }
    }
}
