using AdapterLDL;
using PlayerLDL;
using UnityEngine.AI;

namespace UnitsLDL
{
    public class Npc : IUnit
    {
        public Npc(int unitId,int NpcNivel, AGameObject gameObject,NavMeshAgent navegacion,NpcConfig npcConfig):base(unitId,gameObject)
        {
            movement = new UnitMovement(navegacion, gameObject.Transform);
            unitAtributos = new NpcAtributos(NpcNivel);
            actions = new UnitActions();
        }
        //EL INICIALIZADOR GENERALMENTE ES USADO PARA INICIALIZAR SISTEMAS QUE EN EL AWAKE NO SE PERMITEN
        public void Initialize()
        {
            actions.Initialize(gameObject);
        }

        public UnitMovement Movimiento => movement as UnitMovement;
        public UnitActions Acciones => actions;
    }
}

