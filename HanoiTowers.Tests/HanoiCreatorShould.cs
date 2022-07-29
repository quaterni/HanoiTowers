using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HanoiTowers.Data;

namespace HanoiTowers.Tests
{
    public class HanoiCreatorShould
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void CreatePyramidCorrectly(int count)
        {

            HanoiTowerCreator creator = new HanoiTowerCreator();
            HanoiTower hanoiTower = creator.CreateHanoiTower(count);

            bool result = true;

            Stack<HanoiBlock> stackPyramid = hanoiTower[HanoiStackType.Left];
            for (int i = 1; i < count + 1; i++)
            {
                HanoiBlock block = stackPyramid.Pop();
                if(block.Weight != i)
                {
                    result = false;
                }
            }

            Assert.True(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void CreatePyramidInCorrectStack(int enumNumber)
        {
            HanoiStackType type = (HanoiStackType)enumNumber;
            HanoiTowerCreator creator = new HanoiTowerCreator();
            HanoiTower hanoiTower = creator.CreateHanoiTower(5, type);

            bool result = true;
            foreach(var enumType in Enum.GetValues<HanoiStackType>())
            {
                int stackLength = hanoiTower[enumType].Count();
                if(enumType == type)
                {
                    result = stackLength == 5;
                    continue;
                }
                result = stackLength == 0;
            }

            Assert.True(result);
        }
    }
}
