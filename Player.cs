using AdapterLDL;

namespace PlayerLDL
{
    //CLASE EXCLUSIVA PARA UN JUGADOR QUE CONTIENE TODO LOS MODULOS PARA QUE EL JUGADOR INTERACTUE EN EL JUEGO
    //CABE RECALCAR QUE LOS RECURSOS IN GAME , COMO EL MODELO , ESTATS Y INFORMACION SON RESPONSABILIDAD DE OTRA CLASE
    public class Player : IPlayerComponent
    {
        //MODULOS DEL PLAYER
        private PlayerMovement playerMovement;
        private PlayerInput playerInput;
        private PlayerActions playerActions;
        private PlayerCamera playerCamera;

        //REFERENCIAS
        public PlayerMovement PlayerMovement { get => playerMovement; }
        public PlayerInput PlayerInput { get => playerInput; }
        public PlayerCamera PlayerCamera { get => playerCamera;}

        public void Initialize(ATransform playerTransform, PlayerCamera playerCamera,PlayerMovementConfig configuration)
        {
            playerMovement = new PlayerMovement(playerTransform, configuration);
            this.playerCamera = playerCamera;
            this.playerCamera.SensitivityY = configuration.SensivilidadCamara;
            playerActions = new PlayerActions();
            playerActions.Initialize(this,playerTransform);        
        }

        void IPlayerComponent.Start(ACharacterController controller)
        {
            playerMovement.SetController(controller);
            
            playerInput = new PlayerInput(playerActions, playerMovement);

            playerActions.Start();
        }

        void IPlayerComponent.Update()
        {
            playerInput.ProcessInput();
            playerMovement.ProcessMovement();
            playerCamera.ProcessCamera();
            playerActions.Update();
        }

        void IPlayerComponent.FreezePlayer() {
            playerMovement.Freeze = true;
            playerActions.Active = false;
            playerCamera.Active = false;
        }

        void IPlayerComponent.UnFreezePlayer() {
            playerMovement.Freeze = false; 
            playerActions.Active = true;
            playerCamera.Active = true;
        }

        void IPlayerComponent.OnDisable() => playerActions.OnDisable(); 
       
        void IPlayerComponent.OnDestroy() => playerActions.OnDestroy(); 
        
    }
}