using AdapterLDL;
using UnityEngine;

namespace PlayerLDL
{
    //Le Permite al Player Interactuar , Es un Player Action debido a que es una accion que el player realiza
    public class Interactuar : PlayerAction
    {
        public const string ACTIONNAME = "Interactuar";
        public const string PLAYERCAMNAME = "PlayerCamera";
        public const string MAXDISINTERACTNAME = "MaxDisInteract";
        public const string LASTINTERACTUABLENAME = "LastInteractuable";

        public Interactuar(ACamera playerCamera, float MaxdistanceInteract) : base(ACTIONNAME)
        {
            Parametros.AddParameter(PLAYERCAMNAME, playerCamera);
            Parametros.AddParameter(MAXDISINTERACTNAME, MaxdistanceInteract);
            Parametros.AddParameter(LASTINTERACTUABLENAME, null);
        }

        //FUNCION QUE INTERACTUA CON EL PLAYER
        public override void StartAction() => Parametros.GetParameter<Interactable>(LASTINTERACTUABLENAME)?.Interact(APlayer.GameObject);

        //ACTUALIZA CON QUE ESTA INTERACTUANDO Y EL VISOR TOOLTIP
        public override void UpdateActions()
        {          
            UpdateInteractable();
            UpdateToolTip();           
        }

        private void UpdateToolTip()
        {
            string tooltip = "";
            if (Parametros.GetParameter<Interactable>(LASTINTERACTUABLENAME) != null)
            {
                tooltip = Parametros.GetParameter<Interactable>(LASTINTERACTUABLENAME).GetToolTip();
            }
            MediatorUI.Instance.SetTextToolTipMira(tooltip);
        }

        // TODO Extraer Al Player
        private void UpdateInteractable()
        {
            ACamera camera = Parametros.GetParameter<ACamera>(PLAYERCAMNAME);
            AVector3 screenCenter = new AVector3(ScreenUtility.GetScreenWidth() / 2, ScreenUtility.GetScreenHeight() / 2, 0);
            ARay ray = camera.ScreenPointToRay(screenCenter);
            float maxDistance = Parametros.GetParameter<float>(MAXDISINTERACTNAME);

            if (RaycastUtility.Raycast(ray, maxDistance, out ARaycastHit hit))
            {
                Parametros.AddParameter(LASTINTERACTUABLENAME, hit.GetGameObject().GetComponent<Interactable>());
            }
            else
            {
                Parametros.AddParameter(LASTINTERACTUABLENAME, null);
            }

        }
    }
}