namespace HanoiTowers.Data
{
    public interface IHanoiComputer
    {
        void CumputeTower(int pyramidWeight, HanoiTower tower, HanoiStackType from, HanoiStackType to);
    }
}