namespace UnitsLDL
{
    //CLASE CENTRAL QUE IMPLEMENTA EL COMPORTAMIENTO DE INCREMENTO POR NIVEL DE UN STATS
    // ACA SE ENCUENTRA EL NIVEL DE STAT Y EL VALOR CON ESE NIVEL DEL STATS
    internal class VidaStatUpgrade : IUpgrade
    {
        int statLevel;
        float statValueUpgrade;

        public VidaStatUpgrade() {
            statLevel = 1;
        }

        public int StatLevel => statLevel;

        public float GetValueUpgrade => statValueUpgrade;

        public int GetStatLevel => statLevel;

        public void UpgradeStat(int newLevel, IStat statToUpgrade)
        {
           if(newLevel == statToUpgrade.StatUpgrade.GetStatLevel) { return; }
           //la vida crezca en 50 por nivel , pero ademas este numero crezca en un 10% cada 2 niveles.
           statValueUpgrade = statToUpgrade.ValueBase + 50f * newLevel * (1f + 0.1f * (newLevel / 2f));
        }
    }
}

