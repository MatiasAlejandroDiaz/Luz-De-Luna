using EDM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EDM
{
    [CreateAssetMenu(fileName = "NuevoEventoDeMiedoAparicion", menuName = "Luz De Luna /Evento de Miedo/Aparicion")]
    public class SO_EDM_Aparicion : EventoDeMiedo
    {
        public float velocidadAparicion;

        SO_EDM_Aparicion()
        {
            categoria = CategoriaEvento.Apariciones;
        }

    }

}