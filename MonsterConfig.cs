using UnityEngine;

namespace UnitsLDL
{
    [CreateAssetMenu(fileName = "ConfiguracionMonstruo", menuName = "Luz De Luna/Unidades/Monstruo/ConfiguracionMonstruo")]
    public class MonsterConfig : ScriptableObject
    {
        [Header("GENERAL VARIABLES")]
        [Space(2f)]
        public int MonID;
        public int MonNivel;
    }
}