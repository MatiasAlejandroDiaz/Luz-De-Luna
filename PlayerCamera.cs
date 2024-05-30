using AdapterLDL;
using UnityEngine;

namespace PlayerLDL
{
    public class PlayerCamera : ICamera
    {
        public int ID => this.GetHashCode();

        private ACamera aCamera;
        private ATransform aTransform;
        private bool _active;
        private float sensitivityY = 2f;

        private float rotationX = 0;
        private const float MINROTVERT = -90.0f;
        private const float MAXROTVERT = 90.0f;
        
        public ACamera Camera { get => aCamera; set => aCamera = value; }
        public ATransform Transform { get => aTransform; set => aTransform = value; }
        public float SensitivityY { get => sensitivityY; set => sensitivityY = value; }
        public bool Active { get => _active; set => _active = value; }

        public void Inicialize(ACamera aCamera , ATransform tCamera)
        {
           this.aCamera = aCamera;
           aTransform = tCamera;
           ACursor.LockState = CursorLockMode.Locked;
           ACursor.Visible = false;
           _active = true;
        }

        public void ProcessCamera()
        {
            if (_active)
                RotCamVerWAxisAndSpeed(AInput.MouseY, sensitivityY);
        }

        private void RotCamVerWAxisAndSpeed(float AxisValue, float sensitivity)
        {
            if (AxisValue == 0) return;
            
            // Rotar la cámara en el eje X (vertical) limitando el ángulo.
            rotationX -= AxisValue * sensitivity;
            rotationX = Mathf.Clamp(rotationX, MINROTVERT, MAXROTVERT);

            // Aplicar la rotación a la cámara usando el adaptador.
            aTransform.LocalRotation = Quaternion.Euler(rotationX, 0, 0);
        }
    }
}