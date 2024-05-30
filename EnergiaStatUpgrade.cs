namespace UnitsLDL
{
    internal class EnergiaStatUpgrade : IUpgrade
    {
        private int statLevel;
        private float statValueUpgrade;
        public float GetValueUpgrade => statValueUpgrade;
        public int GetStatLevel => statLevel;

        public EnergiaStatUpgrade()
        {
            statLevel = 1;
        }

        public void UpgradeStat(int level, IStat stat)
        {
            if (level == stat.StatUpgrade.GetStatLevel) return;
            //ENERGIA FORMULA
            statValueUpgrade = stat.ValueBase + 10 * level;
        }
    }
}

