using HanoiTowers.Data;
using HanoiTowers.Desctop.View;
using HanoiTowers.Desctop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTowers.Desctop.Commands
{
    public class CreateTowerCommand : CommandBase
    {

        private HanoiTowerViewModel _viewModel;


        public CreateTowerCommand(HanoiTowerViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            DialogView dialogView = new DialogView();

            dialogView.ShowDialog();
            if (((DialogViewModel)dialogView.DataContext).IsCorrectInput && dialogView.DialogResult == true)
            {
                int blockCount = ((DialogViewModel)dialogView.DataContext).Result;
                HanoiTower hanoiTower = new HanoiTowerCreator().CreateHanoiTower(blockCount);
                _viewModel.CurrentHanoiTower = hanoiTower;
                hanoiTower.BlockMoved += _viewModel.OnBlockMoved;
            }
        }
    }
}
