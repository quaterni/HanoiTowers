namespace HanoiTowers.Data
{
    public class HanoiBlock
    {
        public HanoiBlock(int weight)
        {
            Weight = weight;
            Status = BlockStatus.Done;
        }

        public int Weight { get; }
        public BlockStatus Status { get; set; }
    }
}