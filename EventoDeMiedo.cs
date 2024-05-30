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
        // Agrega más variables según tus necesidades, como condiciones de activación, duración, etc.
    }

    

    public enum CategoriaEvento
    {
        Apariciones,
        MovimientoObjetos,
        CambiosIluminacion,
        // Agrega más categorías según tus necesidades
    }
}