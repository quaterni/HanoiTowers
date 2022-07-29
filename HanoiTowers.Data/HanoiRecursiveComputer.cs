using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTowers.Data
{
    public class HanoiRecursiveComputer : IHanoiComputer
    {
        public void CumputeTower(int pyramidWeight, HanoiTower tower, HanoiStackType from, HanoiStackType to)
        {
            if (pyramidWeight == 1)
            {
                tower.MoveBlock(from, to);
                return;
            }
            HanoiStackType tmp = (HanoiStackType)(6 - (int)from - (int)to);
            CumputeTower(pyramidWeight - 1, tower, from, tmp);
            tower.MoveBlock(from, to);
            CumputeTower(pyramidWeight - 1, tower, tmp, to);
        }
    }
}
