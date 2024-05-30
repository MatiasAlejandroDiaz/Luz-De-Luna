using AdapterLDL;
using PlayerLDL;
using UnityEngine;
using UnityEngine.AI;

namespace UnitsLDL
{
    public class ANpc : MonoBehaviour
    {
        private Npc npcComponent;
        public NpcConfig configuracion;
        public NavMeshAgent agent;
        private void Awake()
        {
            if (configuracion != null)
            {
                int npcId = configuracion.NpcID;

                if (agent == null) { Debug.LogError("No tienes asignado el Componente NavMeshAgent"); return; }

                npcComponent = new Npc(npcId, configuracion.NpcNivel, new AGameObject(gameObject), agent, configuracion);
            }
            else
            {
                Debug.Log("No se asigno la Configuracion del NPC"); return;
            }
        }
        #region UnityMethod
        private void Start()
        {
            npcComponent.Start();
            npcComponent.Initialize();
        }

        private void Update()
        {
            npcComponent.Update();
        }

        private void OnDisable()
        {
            npcComponent.OnDisable();
        }

        private void OnDestroy()
        {
            npcComponent.OnDestroy();
        }

        public void FreezePlayer()
        {
            npcComponent.Freeze();
        }

        public void UnFreezePlayer()
        {
            npcComponent.UnFreeze();
        }
        #endregion

        public void Ir(AVector3 destino)
        {
            if (npcComponent != null)
                npcComponent.Movimiento.MoveToPoint(destino);
            else
                Debug.LogError("No se puede Mover el NPC por que no se encuentra asignado el Npc Component Correctamente.");
        }

        public UnitActions GetActions { get => npcComponent.Acciones; }
    }
}

