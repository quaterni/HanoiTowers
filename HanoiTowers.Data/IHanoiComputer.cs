namespace HanoiTowers.Data
{
    public interface IHanoiComputer
    {
        void CumputeTower(int blockCount, HanoiTower tower, HanoiStackType from, HanoiStackType to);
    }
}