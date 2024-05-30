using AdapterLDL;

namespace PlayerLDL
{
    //CLASE BASE PARA ARMAR LOS FUTUROS COMPONENTES DE UN JUGADOR EN EL JUEGO , SOLO CONTIENE LOS MODULOS NECESARIOS PARA QUE EL JUGADOR INTERACTUE CON EL JUEGO
    public interface IPlayerComponent
    {
        public PlayerCamera PlayerCamera { get; }
        public PlayerInput PlayerInput { get ;}
        public PlayerMovement PlayerMovement { get;}
        void Initialize(ATransform playerTransform, PlayerCamera playerCamera, PlayerMovementConfig configuration);
        void Start( ACharacterController controller);
        void Update();
        void OnDisable();
        void OnDestroy();
        void FreezePlayer();
        void UnFreezePlayer();

    }
}