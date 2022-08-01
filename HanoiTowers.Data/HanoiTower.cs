using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTowers.Data
{
    public class HanoiTower
    {
        private Stack<HanoiBlock> _leftStack;
        private Stack<HanoiBlock> _centerStack;
        private Stack<HanoiBlock> _rightStack;

        public HanoiTower(Stack<HanoiBlock> stack, HanoiStackType type)
        {
            foreach(var enumType in Enum.GetValues<HanoiStackType>())
            {
                if(enumType == type)
                {
                    this[type] = stack;
                    continue;
                }
                this[enumType] = new Stack<HanoiBlock>();
            }
        }

        public delegate void BlockMovedHandler(HanoiTower sender, BlockMovedEventArgs e);

        public event BlockMovedHandler? BlockMoved;

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
                return type switch
                {
                    HanoiStackType.Left => _leftStack,
                    HanoiStackType.Center => _centerStack,
                    HanoiStackType.Right => _rightStack,
                    _ => throw new Exception("Unknown Property Name"),
                };
            }
            private set
            {
                switch(type)
                {
                    case HanoiStackType.Left: 
                        _leftStack = value;
                        break;
                    case HanoiStackType.Center:
                        _centerStack = value;
                        break;
                    case HanoiStackType.Right:
                        _rightStack = value;
                        break;
                    default:
                        throw new Exception("Unknown Property Name");
                }
            }
        }

        public void MoveBlock(HanoiStackType from, HanoiStackType to)
        {
            HanoiBlock movingBlock = this[from].Pop();
            if(this[to].Count !=0 && movingBlock.Weight >= this[to].Peek().Weight)
            {
                throw new HanoiBlockMoveException("Moving block havier than pyramid block", movingBlock, this[to].Peek());
            }
            movingBlock.IsActive = true;
            this[to].Push(movingBlock);
            OnBlockMovedEvent(movingBlock, from, to);
            movingBlock.IsActive = false;
        }

        private void OnBlockMovedEvent(HanoiBlock movingBlock, HanoiStackType fromStack, HanoiStackType toStack)
        {
            BlockMovedEventArgs e = new(movingBlock, fromStack, toStack);
            BlockMoved?.Invoke(this, e);
        }
    }
}
