using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTowers.Data
{
    public class HanoiTowerCreator
    {
        public HanoiTower CreateHanoiTower(int blockCounts, HanoiStackType stackType = HanoiStackType.Left)
        {
            int counter = blockCounts;
            Stack<HanoiBlock> stack = new();
            for(; counter > 0; counter--)
            {
                HanoiBlock block = new(counter);
                stack.Push(block);
            }
            return new HanoiTower(stack, stackType);
        }
    }
}
