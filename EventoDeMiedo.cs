using UnityEngine;

namespace EDM
{
    //[CreateAssetMenu(fileName = "NuevoEventoDeMiedo", menuName = "Evento de Miedo")]
    public class EventoDeMiedo : ScriptableObject
    {
        public string nombre;
        public string descripcion;
        protected CategoriaEvento categoria;
        public GameObject prefabActor;
        // Agrega m�s variables seg�n tus necesidades, como condiciones de activaci�n, duraci�n, etc.
    }

    

    public enum CategoriaEvento
    {
        Apariciones,
        MovimientoObjetos,
        CambiosIluminacion,
        // Agrega m�s categor�as seg�n tus necesidades
    }
}