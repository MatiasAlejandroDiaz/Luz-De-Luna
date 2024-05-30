using AdapterLDL;
using UnityEngine;
using UnityEngine.AI;

namespace UnitsLDL
{
    public class AMonster : MonoBehaviour
    {
        private Monster MonComponent;
        public MonsterConfig configuracion;
        public NavMeshAgent agent;

        private void Awake()
        {
            if (configuracion != null)
            {
                int MonsterId = configuracion.MonID;

                if (agent == null) { Debug.LogError("No tienes asignado el Componente NavMeshAgent"); return; }

                MonComponent = new Monster(MonsterId, configuracion.MonNivel, new AGameObject(gameObject), agent, configuracion);
            }
            else
            {
                Debug.Log("No se asigno la Configuracion del Monstruo"); return;
            }
        }

        #region UnityMethod
        private void Start()
        {
            MonComponent.Start();
            MonComponent.Initialize();
        }

        private void Update()
        {
            MonComponent.Update();
        }

        private void OnDisable()
        {
            MonComponent.OnDisable();
        }

        private void OnDestroy()
        {
            MonComponent.OnDestroy();
        }

        public void FreezePlayer()
        {
            MonComponent.Freeze();
        }

        public void UnFreezePlayer()
        {
            MonComponent.UnFreeze();
        }
        #endregion
    }
}

