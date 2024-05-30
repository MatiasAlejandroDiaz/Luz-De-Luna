using AdapterLDL;

namespace PlayerLDL
{
    public class PlayerInput : IPlayerInput
    {
        private readonly PlayerActions playerActions;
        private readonly PlayerMovement playerMovement;

        public PlayerInput(PlayerActions playerActions , PlayerMovement playerMovement)
        {
            this.playerActions = playerActions;
            this.playerMovement = playerMovement;

        }

        public void ProcessInput()
        {          

            if (IsLeftShiftButtonDown)
            {
                //Dash
                EjecutarDash();
            }

            if (IsEButtonPressed())
            {
                //Interactuar Con El Entorno
                EjecutarInteractuar();
            }

            if (IsFire1ButtonPressed)
            {
                //Accion Principal de El Objeto De La Mano
                

            }

            if (IsFire2ButtonPressed)
            {
                //Accion Secundaria de El Objeto De La Mano


            }


        }

        private void EjecutarInteractuar()
        {
            playerActions.PerformActionByName("Interactuar");
        }

        private void EjecutarDash()
        {
            playerActions.SetParameterValueForAction("Dash", "Direction", playerMovement.Direction);
            playerActions.SetParameterValueForAction("Dash", "dashColdown", 1);
            playerActions.SetParameterValueForAction("Dash", "dashDuration", 0.2f);
            playerActions.SetParameterValueForAction("Dash", "dashDistance", 5f);
            playerActions.PerformActionByName("Dash");
        }

        #region Comprobacion de Botones

        private bool IsEButtonPressed() => AInput.GetKeyDown(UnityEngine.KeyCode.E);
        public bool IsFire1ButtonPressed => AInput.GetButton("Fire1");
        public bool IsFire2ButtonPressed => AInput.GetButton("Fire2");
        public bool IsLeftShiftButtonDown => AInput.GetKeyDown(UnityEngine.KeyCode.LeftShift);

        #endregion


    }
}