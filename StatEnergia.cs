namespace UnitsLDL
{
    //CLASE CENTRAL PARA ARMAR UN STATS EN ESTE CASO EL STAT DE ENERGIA
    internal class StatEnergia : IStat
    {
        string name;
        float valueBase;
        IUpgrade statUpgrade;
        IStatModifier statModifier;
        public StatEnergia()
        {
            name = "Energia";
            valueBase = 10;
            statModifier = new NormalStatModifier(valueBase);
            statUpgrade = new EnergiaStatUpgrade();
        }

        public string Name { get => name; set => name = value; }
        public float ValueBase { get => valueBase; set => valueBase = value; }    
        public IUpgrade StatUpgrade => statUpgrade;
        public IStatModifier StatModifier => statModifier;
        public float ValueUpgrade => statUpgrade.GetValueUpgrade;
        public float ValueMax => ValueUpgrade + statModifier.ValueModifier;
    }
}