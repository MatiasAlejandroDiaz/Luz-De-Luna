using AdapterLDL;
using UnityEngine;

namespace PlayerLDL
{
    public class ACharacterController
    {
        private CharacterController characterController;

        public ACharacterController(CharacterController unityCharacterController)
        {
            characterController = unityCharacterController;
        }

        public bool IsGrounded
        {
            get { return characterController.isGrounded; }
        }

        public void Move(AVector3 motion)
        {
            characterController.Move(new Vector3(motion.X,motion.Y,motion.Z));
        }

        // Puedes agregar más propiedades o métodos según tus necesidades.
    }

    
}