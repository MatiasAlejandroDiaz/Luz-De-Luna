using AdapterLDL;
using PlayerLDL;
using UnityEngine.AI;
using UnityEngine.UI;

namespace UnitsLDL
{
    internal class Monster : IUnit
    {
        private int monID;
        private int npcNivel;
        private AGameObject aGameObject;
        private NavMeshAgent agent;
        private MonsterConfig configuracion;

        public Monster(int monID, int npcNivel, AGameObject aGameObject, NavMeshAgent agent, MonsterConfig configuracion):base(monID,aGameObject)
        {
            this.monID = monID;
            this.npcNivel = npcNivel;
            this.aGameObject = aGameObject;
            this.agent = agent;
            this.configuracion = configuracion;

            movement = new UnitMovement(agent, gameObject.Transform);
            unitAtributos = new MonsterAtributos(npcNivel);
            actions = new UnitActions();
        }
        //EL INICIALIZADOR GENERALMENTE ES USADO PARA INICIALIZAR SISTEMAS QUE EN EL AWAKE NO SE PERMITEN
        public void Initialize()
        {
            actions.Initialize(gameObject);
        }

    }
}