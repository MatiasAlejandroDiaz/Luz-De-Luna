using UnityEngine;

namespace AdapterLDL
{
    public class ATransform
    {
        private Transform transform;

        public ATransform(Transform unityTransform)
        {
            transform = unityTransform;
        }

        public AVector3 Position
        {
            get { return new AVector3(transform.position); }
            set { transform.position = value.ToUnityVector3(); }
        }

        public AVector3 Forward
        {
            get { return new AVector3(transform.forward); }
            set { transform.forward = value.ToUnityVector3(); }
        }

        public AVector3 Right
        {
            get { return new AVector3(transform.right); }
            set { transform.right = value.ToUnityVector3(); }
        }

        public AVector3 Up
        {
            get { return new AVector3(transform.up); }
            set { transform.up = value.ToUnityVector3(); }
        }

        public Quaternion LocalRotation { get => transform.localRotation; set => transform.localRotation = value ; }
        public void Rotate(AVector3 vector3)=> transform.Rotate(vector3.ToUnityVector3());
        public Quaternion Rotation { get => transform.rotation; set => transform.rotation = value; }
        
        
        // Puedes agregar más propiedades o métodos según tus necesidades.
    }

    
}