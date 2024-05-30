using UnityEngine;

namespace PlayerLDL
{
    [CreateAssetMenu(fileName = "ConfiguracionNPC", menuName = "Luz De Luna/Unidades/NPC/ConfiguracionNPC")]
    public class NpcConfig : ScriptableObject
    {
        [Header("GENERAL VARIABLES")]
        [Space(2f)]
        public int NpcID;
        public int NpcNivel = 1;
        public string NpcName ="Nuevo Npc";
        [Header("ATRIBUTOS")]
        [Space(2f)]
        public int Nivel = 1;
        public int Velocidad = 7;
        public int Aceleracion = 3;
        public int AngularVelocidad = 120;
    }
}
