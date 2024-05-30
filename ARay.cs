using UnityEngine;

namespace AdapterLDL
{
    public class ARay
    {
        private Ray _ray;

        public ARay(AVector3 origin, AVector3 direction)
        {
            _ray = new Ray(origin.ToUnityVector3(), direction.ToUnityVector3());
        }

        public Ray ToUnityRay() => _ray;
    }
}
