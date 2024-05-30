using AdapterLDL;

namespace PlayerLDL
{
    public interface ICamera
    {
        public int ID { get; }
        public ACamera Camera { get; set; }
        public bool Active { get; set; }
        public void Inicialize(ACamera camera, ATransform tCamera);

    }

}