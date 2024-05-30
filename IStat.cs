namespace UnitsLDL
{
    //INTERFACE PARA ARMAR LOS DIFERENTES STATS DEL JUEGO
    public interface IStat
    {
        //IDENTIFICADOR UNICO DEL STAT
        string Name{ get; set; }
        //VALOR BASE QUE POSEE EL STAT
        float ValueBase { get; set; }
        //CLASE PARA INCREMENTAR EL VALOR BASE DEPENDIENTO EL NIVEL
        IUpgrade StatUpgrade { get; }
        //VALOR CON EL INCREMENTO DEL NIVEL DEL STAT
        float ValueUpgrade { get; }
        //CLASE PARA ALMACENAR TODOS LOS MODIFICADORES QUE SE EL PUEDEN APLICAR AL STATS
        IStatModifier StatModifier { get; }
        //VALOR FINAL CON LOS MODIFICADORES APLICADOS
        float ValueMax { get; }

    }
}

