using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTowers.Data
{
    public class HanoiBlockMoveException : Exception
    {
        public HanoiBlock MovingBlock { get; }
        public HanoiBlock PyramidBlock { get; }

        public HanoiBlockMoveException(string? message, HanoiBlock movingBlock, HanoiBlock pyramidBlock) : base(message)
        {
            MovingBlock = movingBlock;
            PyramidBlock = pyramidBlock;
        }

        public HanoiBlockMoveException(string? message, Exception? innerException, HanoiBlock movingBlock, HanoiBlock pyramidBlock) : base(message, innerException)
        {
            MovingBlock = movingBlock;
            PyramidBlock = pyramidBlock;
        }
    }
}
