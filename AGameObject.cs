using UnityEngine;

namespace AdapterLDL
{
    public class AGameObject
    {
        private GameObject gameObject;
        private ATransform GameObjTrasform;
        public ATransform Transform { get => GameObjTrasform; }
        public GameObject GameObject { get => gameObject; }

        public AGameObject ( GameObject gameObject ) {
            this.gameObject = gameObject;
            this.GameObjTrasform = new ATransform(gameObject.transform);
        }

        public void SetActive( bool active )
        {
            GameObject.SetActive( active );
        }

        public GameObject ToUnityGameObject() => gameObject;

        public T GetComponent<T>() where T : class
        {
            var component = gameObject.GetComponent(typeof(T));
            return component as T;
        }

    }

    
}