using HanoiTowers.Data;
using HanoiTowers.Desctop.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTowers.Desctop.Service
{
    public class TowerEvaluatorSevice
    {
        public const int BlockMaxWidth = 120;
        public const int BlockMinWidth = 15;

        public ObservableCollection<HanoiBlockViewModel> EvaluateTower(Stack<HanoiBlock> hanoiBlocks)
        {
            ObservableCollection<HanoiBlockViewModel> result = new();
            int blockCount = hanoiBlocks.Count; 
            HanoiBlock[] stackCopy = new HanoiBlock[blockCount];
            hanoiBlocks.CopyTo(stackCopy, 0);
            
            for(int i = 0; i< blockCount; i++)
            {
                HanoiBlockViewModel hanoiBlockViewModel = new(stackCopy[ i], BlockMaxWidth - ((BlockMaxWidth - BlockMinWidth) / (double)blockCount)*(blockCount-i-1));
                result.Add(hanoiBlockViewModel);
            }
            return result;
        }
    }
}
