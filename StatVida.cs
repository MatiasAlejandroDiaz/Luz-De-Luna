using System;
using System.Data;

namespace UnitsLDL
{
    //CLASE CENTRAL PARA ARMAR UN STATS EN ESTE CASO EL STAT DE VIDA
    public class StatVida : IStat
    {
        string name;
        //VALOR BASE DEL STATS, NO DEPENDE DEL NIVEL, NI DE LOS MODIFICADORES
        float valueBase;
        IUpgrade statUpgrade;
        IStatModifier statModifier;
        public StatVida()
        {
            name = "Vida";
            valueBase = 100;
            //AHORA SE LE APLICA LOS MODIFICADORES DE VIDA
            statModifier = new NormalStatModifier(valueBase);
            //AHORA SE LE APLICA EL INCREMENTO AL STATS , DEPENDIENDO EL NIVEL DEL STAT QUE POSEE
            statUpgrade = new VidaStatUpgrade();
        }

        public string Name { get => name; set => name = value; }
        public float ValueBase { get => valueBase; set => valueBase = value; }
        public float ValueUpgrade => statUpgrade.GetValueUpgrade;
        public IUpgrade StatUpgrade { get => statUpgrade; }
        public IStatModifier StatModifier => statModifier;
        public float ValueMax => ValueUpgrade + statModifier.ValueModifier;


        public void UpdateStat()
        {
            statModifier.CalculeModifier();
        }
    }
}

