namespace UnitsLDL
{
    public interface IUpgrade
    {
        public float GetValueUpgrade { get; }
        public int GetStatLevel {  get; }
        void UpgradeStat(int level , IStat stat);
    }
}

