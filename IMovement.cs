using AdapterLDL;

namespace PlayerLDL
{
    public interface IMovement
    {
        AVector3 Direction { get; }
        public void ProcessMovement();
        bool Freeze { get ; set ; }

    }
}