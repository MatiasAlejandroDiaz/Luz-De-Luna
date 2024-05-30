using AdapterLDL;
using UnityEngine;
using UnityEngine.AI;

namespace PlayerLDL
{
    public class UnitMovement : IMovement
    {
        private NavMeshAgent navMeshAgent;

        private bool freezeMovement;
        public ATransform Transform { get; set; }

        public AVector3 Direction => new AVector3(navMeshAgent.velocity.normalized);
        public AVector3 Destino => new AVector3(navMeshAgent.destination);
        public bool Freeze { get => freezeMovement; set => freezeMovement = value; }

        public UnitMovement(NavMeshAgent navMesh, ATransform transform)
        {
            navMeshAgent = navMesh;
            Transform = transform;
        }

        public void ProcessMovement()
        {
            return;
        }

        public void MoveToPoint(AVector3 Position)
        {
            if (navMeshAgent != null)
            {
                navMeshAgent.SetDestination(Position.ToUnityVector3());
            }
        }

    }
}