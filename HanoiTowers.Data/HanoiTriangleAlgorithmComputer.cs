using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTowers.Data
{
    public class HanoiTriangleAlgorithmComputer : IHanoiComputer
    {
        public void CumputeTower(int blockCount, HanoiTower tower, HanoiStackType from, HanoiStackType to)
        {
            HanoiStackType tmp = (HanoiStackType)(6 - (int)from - (int)to);
            if (blockCount % 2 == 0)
            {
                EvenAlgorithm(blockCount, tower, from, to, tmp);
                return;
            }
            OddAlgorithm(blockCount, tower, from, to, tmp);
        }

        private void EvenAlgorithm(int blockCount, HanoiTower tower, HanoiStackType from, HanoiStackType to, HanoiStackType tmp)
        {
            int stage = 1;
            while (tower[to].Count != blockCount)
            {
                if (stage == 1)
                {
                    MoveBlock(tower, from, tmp);
                    stage = 2;
                    continue;
                }
                if (stage == 2)
                {
                    MoveBlock(tower, from, to);
                    stage = 3;
                    continue;
                }
                if (stage == 3)
                {
                    MoveBlock(tower, tmp, to);
                    stage = 1;
                }
            }
        }

        private void OddAlgorithm(int blockCount, HanoiTower tower, HanoiStackType from, HanoiStackType to, HanoiStackType tmp)
        {
            int stage = 1;
            while (tower[to].Count != blockCount)
            {
                if (stage == 1)
                {
                    MoveBlock(tower, from, to);
                    stage = 2;
                    continue;
                }
                if (stage == 2)
                {
                    MoveBlock(tower, from, tmp);
                    stage = 3;
                    continue;
                }
                if (stage == 3)
                {
                    MoveBlock(tower, tmp, to);
                    stage = 1;
                }
            }
        }

        private void MoveBlock(HanoiTower tower, HanoiStackType from, HanoiStackType to)
        {
            if(tower[to].Count == 0)
            {
                tower.MoveBlock(from, to);
                return;
            }

            if (tower[from].Count == 0)
            {
                tower.MoveBlock(to, from);
                return;

            }

            if (tower[from].Peek().Weight < tower[to].Peek().Weight)
            {
                tower.MoveBlock(from, to);
            }
            else
            {
                tower.MoveBlock(to, from);
            }
        }
    }
}
