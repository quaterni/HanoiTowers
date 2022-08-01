using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTowers.Data
{
    public class BlockMovedEventArgs
    {
        private HanoiBlock _movingBlock;

        public HanoiBlock MovingBlock
        {
            get { return _movingBlock; }
        }

        private HanoiStackType _fromStack;

        public HanoiStackType FromStack
        {
            get { return _fromStack; }
        }

        private HanoiStackType _toStack;

        public HanoiStackType ToStack
        {
            get { return _toStack; }
        }

        public BlockMovedEventArgs(HanoiBlock movingBlock, HanoiStackType fromStack, HanoiStackType toStack)
        {
            _movingBlock = movingBlock;
            _fromStack = fromStack;
            _toStack = toStack;
        }
    }
}
