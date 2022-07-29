using HanoiTowers.Data;

namespace HanoiTowers.Tests
{
    public class HanoiTowerShould
    {
        [Theory]
        [InlineData(1,2)]
        [InlineData(1,3)]
        [InlineData(2,1)]
        [InlineData(2,3)]
        [InlineData(3,1)]
        [InlineData(3,2)]
        public void MoveHanoiBlocksCorrectly(int enumNumberFrom, int enumNumberTo)
        {
            HanoiStackType from = (HanoiStackType)enumNumberFrom;
            HanoiStackType to = (HanoiStackType)enumNumberTo;

            HanoiTower hanoiTower = new HanoiTowerCreator().CreateHanoiTower(1, from);

            hanoiTower.MoveBlock(from, to);

            bool result = true;

            foreach (var enumType in Enum.GetValues<HanoiStackType>())
            {
                int stackLength = hanoiTower[enumType].Count();
                if (enumType == to)
                {
                    result = stackLength == 1;
                    continue;
                }
                result = stackLength == 0;
            }

            Assert.True(result);
        }

        [Fact]
        public void ThrowExceptionIfMovingBlockHeavier()
        {
            Stack<HanoiBlock> leftStack = new Stack<HanoiBlock>();
            leftStack.Push(new HanoiBlock(2));
            Stack<HanoiBlock> centerStack = new Stack<HanoiBlock>();
            centerStack.Push(new HanoiBlock(1));
            HanoiTower hanoiTower = new HanoiTower(leftStack, centerStack, new Stack<HanoiBlock>());
            Assert.Throws<HanoiBlockMoveException>(() => hanoiTower.MoveBlock(HanoiStackType.Left, HanoiStackType.Center));
        }
    }
}