using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTowers.Data
{
    public class HanoiTower
    {
        private Stack<HanoiBlock> _leftStack { get; }
        private Stack<HanoiBlock> _centerStack { get; }
        private Stack<HanoiBlock> _rightStack { get; }

        public HanoiTower(Stack<HanoiBlock> leftStack, Stack<HanoiBlock> centerStack, Stack<HanoiBlock> rightStack)
        {
            _leftStack = leftStack;
            _centerStack = centerStack;
            _rightStack = rightStack;
        }

        public Stack<HanoiBlock> this[HanoiStackType type]
        {
            get
            {
                switch (type)
                {
                    case HanoiStackType.Left: return _leftStack;
                    case HanoiStackType.Center: return _centerStack;
                    case HanoiStackType.Right: return _rightStack;
                    default: throw new Exception("Unknown Property Name");
                }
            }
        }

        public void MoveBlock(HanoiStackType from, HanoiStackType to)
        {
            this[to].Push(this[from].Pop());
        }
    }
}
