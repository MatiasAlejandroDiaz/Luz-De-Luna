using UnityEngine;
using AdapterLDL;

namespace PlayerLDL
{
    [RequireComponent(typeof(CharacterController))]
    public class APlayer : MonoBehaviour
    {
        private IPlayerComponent player;

        public ATransform Transform;
        public PlayerMovementConfig Configuration;
        public Camera Camera;
        public static AGameObject GameObject;
        public IPlayerComponent Player { get => player;}

        public Animator animator;
        private void Awake()
        {
            player = new Player();
            Transform = new ATransform(transform);
            GameObject = new AGameObject(gameObject);
            if (Camera == null) { Debug.LogWarning("Falta Asignar la camara al jugador"); Camera = Camera.main; }

            PlayerCamera playCam = new PlayerCamera();
            playCam.Inicialize(new ACamera(Camera), new ATransform(Camera.transform));

            player.Initialize(Transform,playCam,Configuration);
        }

        private void Start()
        {
            player.Start(new ACharacterController(GetComponent<CharacterController>()));
        }

        private void Update()
        {
            player.Update();

            if (animator.isInitialized)
            {
                animator.SetFloat("X", Input.GetAxis("Vertical"));
                animator.SetFloat("Z", Input.GetAxis("Horizontal"));
            }
           
        }

        private void OnDisable()
        {
            player.OnDisable();
        }

        private void OnDestroy()
        {
            player.OnDestroy(); 
        }

        public void FreezePlayer()
        {
            player.FreezePlayer();
        }

        public void UnFreezePlayer()
        {
            player.UnFreezePlayer();
        }
    }
}