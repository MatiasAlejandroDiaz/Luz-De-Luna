namespace PlayerLDL
{
    public interface IActions
    {
        string Name { get; }
        public ParameterAction Parametros { get; }
        abstract void UpdateActions();
        abstract void StartAction();
        abstract void StopAction();
        abstract void OnEnableAction();
        abstract void OnDisableAction();
        abstract void OnDestroyAction();

    }
}