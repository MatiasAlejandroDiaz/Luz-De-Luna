using UnityEngine;

namespace PlayerLDL
{
    [CreateAssetMenu(fileName = "ConfiguracionDeMovimiento", menuName = "Luz De Luna/Player/Configuracion De Movimiento")]
    public class PlayerMovementConfig : ScriptableObject
    {
        [Header("GENERAL VARIABLES")]
        [Space(2f)]
        public float speed = 3f;
        public float gravity = -9.8f;
        public float rotateSpeed = 2f;
        public float SensivilidadCamara = 2f;
    }
}
