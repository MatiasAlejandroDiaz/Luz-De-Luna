using System.Collections.Generic;

namespace UnitsLDL
{
    public class NpcAtributos : IAtributos
    {
        private Dictionary<string,IStat> sStats;
        private int sLevel;

        public NpcAtributos(int nivel)
        {
            sLevel = nivel;
            IStat sVida = new StatVida();
            IStat sEnergia = new StatEnergia();
            sStats = new Dictionary<string, IStat>
            {
                { sVida.Name, sVida },
                { sEnergia.Name, sEnergia }
            };
            UpgradeAllStats();
        }

        private void UpgradeAllStats()
        {
            foreach(var stat in sStats.Values)
            {
                stat.StatUpgrade.UpgradeStat(sLevel, stat);
            }
        }
        public void AddStats(string name, IStat stat)
        {
            sStats.Add(name, stat);
        }

        public int GetLevel()
        {
           return sLevel;
        }

        public IStat GetStats(string name)
        {
            sStats.TryGetValue(name, out IStat stat);
            return stat;
        }

        public void SetLevel(int level)
        {
            sLevel = level;
        }
    }
}

