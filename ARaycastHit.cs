using UnityEngine;

namespace AdapterLDL
{
    public class ARaycastHit
    {
        private RaycastHit _hit;

        public ARaycastHit(RaycastHit hit)
        {
            _hit = hit;
        }

        public AGameObject GetGameObject()
        {
            return new AGameObject(_hit.collider.gameObject);
        }

        public AVector3 Point => new AVector3(_hit.point);
        public AVector3 Normal => new AVector3(_hit.normal);
        public float Distance => _hit.distance;
    }
}
