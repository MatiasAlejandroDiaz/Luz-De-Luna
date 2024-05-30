using PlayerLDL;
using UnityEngine;

namespace AdapterLDL
{
    public class ACamera
    {
        private Camera unityCamera;
        public int ID => this.GetHashCode();
        public Camera UnityComponent { get => unityCamera; private set => unityCamera = value; }

        public ACamera(Camera camera)
        {
            unityCamera = camera;
        }

        public ARay ScreenPointToRay(AVector3 screenPoint)
        {
            return new ARay(new AVector3(unityCamera.ScreenPointToRay(screenPoint.ToUnityVector3()).origin),
                            new AVector3(unityCamera.ScreenPointToRay(screenPoint.ToUnityVector3()).direction));
        }
    }

}