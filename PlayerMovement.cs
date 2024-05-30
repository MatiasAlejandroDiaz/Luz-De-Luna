using AdapterLDL;

namespace PlayerLDL
{
    public class PlayerMovement : IMovement
    {
        internal ATransform playerTransform;
        private ACharacterController controller;
        private AVector3 playerVelocity;
        private AVector3 move;

        //TODO VAR PLAYER CONFIG
        private float rotateSpeed;
        private float speed;


        private float gravity;
        private bool freezeMovement;

        public AVector3 Direction => AVector3.Normalized(move);
        public AVector3 Position { get => playerTransform.Position; set => playerTransform.Position = value; }
        public bool Freeze { get => freezeMovement; set => freezeMovement = value; }

        public PlayerMovement(ATransform transform, PlayerMovementConfig config)
        {
            playerTransform = transform;
            this.speed = config.speed;
            this.gravity = config.gravity;
            this.freezeMovement = false;
            this.rotateSpeed = config.rotateSpeed;
            this.playerVelocity = AVector3.Zero();
        }

        //
        #region MOVER
        public void MoveInAxis(float horizontal , float vertical)
        {
            // Mover al jugador en la dirección calculada.
            move = CalularDireccionDeMovimiento(horizontal, vertical);
            AVector3 movement = AVector3.Prod(move , UnityEngine.Time.deltaTime * speed);

            if (!freezeMovement)
                controller.Move(movement);

            playerVelocity.Y += gravity * UnityEngine.Time.deltaTime;
            controller.Move(AVector3.Prod(playerVelocity , UnityEngine.Time.deltaTime));
        }
        /// <summary>
        /// Calcula la direccion en donde el player esta por moverse dependiento los valores horizontales y verticales del Input de movimiento.
        /// </summary>
        private AVector3 CalularDireccionDeMovimiento(float horizontal, float vertical)
        {
            AVector3 forward = playerTransform.Forward;
            forward.Y = 0f;
            forward = AVector3.Normalize(forward);

            AVector3 right = playerTransform.Right;
            right.Y = 0f;
            right = AVector3.Normalize(right);

            AVector3 moveDirection = AVector3.Sum(AVector3.Prod(forward , vertical), AVector3.Prod(right , horizontal));
            moveDirection = AVector3.Normalize(moveDirection);
            return moveDirection;
        }
        #endregion
        //
        //Mueve un frame en una direccion , respeta solo la gravedad, lo demas nada
        public void MoveInDirection(AVector3 playerDirection)
        {
            controller.Move(playerDirection);
        }

        public void SetController(ACharacterController controller) => this.controller = controller;

        internal void RotateInXAxis(float mouseX)
        {
            playerTransform.Rotate(AVector3.Prod(AVector3.up , mouseX));
        }

        public void ProcessMovement()
        {
            if (freezeMovement || controller == null) return;

            MoveInAxis(AInput.Horizontal, AInput.Vertical);
            RotateInXAxis(AInput.MouseX * rotateSpeed);
        }
    }

    
}