using AdapterLDL;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLDL
{
    public class InteractuarUnidad : UnitAction
    {
        public const string ACTIONNAME = "InteractuarUnidad";
        public const string AGAMEOBJECTNAME = "AGAMEOBJECTUNIT";
        public const string INTEMAXDIST = "INTMAXDIST";

        private const float updateInterval = 1.0f; // Intervalo de actualización en segundos
        private float timer = 0.0f;

        // ES INDISPENSABLE PARA QUE ESTA ACCION FUNCIONE ACTUALIZAR EL PARAMENTRO INTERACTUABLE ID EXTERNAMENTE
        public const string INTERACTUABLEID = "InteractuableID";
        public const string LASTINTERACTUABLENAME = "LASTINTERACTUABLE";
        public InteractuarUnidad(AGameObject UnidadObject, float InteraccionDistance) : base(ACTIONNAME)
        {
            Parametros.AddParameter(AGAMEOBJECTNAME, UnidadObject);
            Parametros.AddParameter(INTEMAXDIST, InteraccionDistance);
            Parametros.AddParameter(INTERACTUABLEID, -1);
        }
        //FUNCION QUE INTERACTUA CON EL PLAYER
        public override void StartAction()
        {
            Interactable interComp = Parametros.GetParameter<Interactable>(LASTINTERACTUABLENAME);
            AGameObject interactor = Parametros.GetParameter<AGameObject>(AGAMEOBJECTNAME);

            if (interComp != null)
                interComp.Interact(interactor);
            else
                Debug.LogError("No se Posee el Interactuable indicado con el ID: "+Parametros.GetParameter<int>(INTERACTUABLEID)+" cerca.");
            
        }

        //ACTUALIZA CON QUE ESTA INTERACTUANDO Y EL VISOR TOOLTIP
        public override void UpdateActions()
        {
            timer += Time.deltaTime;
            if (timer >= updateInterval)
            {
                UpdateInteractable();
                timer = 0.0f;
            }
        }

        private void UpdateInteractable()
        {
            AGameObject playerObject = Parametros.GetParameter<AGameObject>(AGAMEOBJECTNAME);
            float maxDistance = Parametros.GetParameter<float>(INTEMAXDIST);
            int targetInteractableID = Parametros.GetParameter<int>(INTERACTUABLEID);

            List<AGameObject> objectsInDistance = RaycastUtility.GetObjectsInSphere(playerObject.Transform.Position, maxDistance, LayerMask.GetMask("Entidades"));

            if (objectsInDistance != null)
            {
                foreach (AGameObject obj in objectsInDistance)
                {
                    Interactable objInterComp = obj.GetComponent<Interactable>();

                    if (objInterComp != null && objInterComp.interactableID == targetInteractableID)
                    {
                        Parametros.AddParameter(LASTINTERACTUABLENAME, objInterComp);
                        return;
                    }
                }
            }

            // Si no se encuentra un objeto interactuable, establecer a null
            Parametros.AddParameter(LASTINTERACTUABLENAME, null);
        }
    }
}
