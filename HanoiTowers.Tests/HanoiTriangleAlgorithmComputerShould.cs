using HanoiTowers.Data;

namespace HanoiTowers.Tests
{
    public class HanoiTriangleAlgorithmComputerShould
    {

        [Theory]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(2, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        public void ComputePyramidCorrectly(int enumNumberFrom, int enumNumberTo)
        {
            HanoiStackType from = (HanoiStackType)enumNumberFrom;
            HanoiStackType to = (HanoiStackType)enumNumberTo;

            HanoiTower hanoiTower = new HanoiTowerCreator().CreateHanoiTower(4, from);
            HanoiTriangleAlgorithmComputer hanoiComputer = new();
            hanoiComputer.CumputeTower(4, hanoiTower, from, to);
            bool result = true;
            foreach (var enumType in Enum.GetValues<HanoiStackType>())
            {
                int stackLength = hanoiTower[enumType].Count();
                if (enumType == to)
                {
                    result = stackLength == 4;
                    continue;
                }
                result = stackLength == 0;
            }

            Assert.True(result);
        }

        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(11)]
        public void ComputePyramidCorrectlyOnDifferentBlocks(int numberBlock)
        {
            HanoiStackType from = HanoiStackType.Left;
            HanoiStackType to = HanoiStackType.Center;

            HanoiTower hanoiTower = new HanoiTowerCreator().CreateHanoiTower(numberBlock, from);
            HanoiTriangleAlgorithmComputer hanoiComputer = new();
            hanoiComputer.CumputeTower(numberBlock, hanoiTower, from, to);
            bool result = true;
            foreach (var enumType in Enum.GetValues<HanoiStackType>())
            {
                int stackLength = hanoiTower[enumType].Count();
                if (enumType == to)
                {
                    result = stackLength == numberBlock;
                    continue;
                }
                result = stackLength == 0;
            }

            Assert.True(result);
        }
    }
}
