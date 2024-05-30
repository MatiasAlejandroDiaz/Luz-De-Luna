namespace PlayerLDL
{
    internal interface IPlayerInput
    {
        void ProcessInput();
        bool IsLeftShiftButtonDown { get; }
        bool IsFire1ButtonPressed { get; }
    }
}