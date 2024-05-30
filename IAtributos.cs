namespace UnitsLDL
{
    //CLASE BASE PARA CADA CONJUNTO DE STATS DENTRO DEL JUEGO
    // NOMBRE DE ATRIBUTOS
    // Vida , Energia , Experiencia
    public interface IAtributos
    {
        //private Dictionary<string, IStat> stats;
        public IStat GetStats(string name);
        public void AddStats(string name,IStat stat);
        public int GetLevel();
        public void SetLevel(int level);

    }
}

