public class PlayerShootState : IState, IPlayerState
{
    PlayerStateMachine MyPFSM = new PlayerStateMachine();
    PlayerScript MyPS = new PlayerScript();
    public void Enter()
    {
        EventManager.SubscribeToEvent(EventEnum.ON_MOVER, Swap1);
        EventManager.SubscribeToEvent(EventEnum.ON_MOVEL, Swap1);
        EventManager.SubscribeToEvent(EventEnum.ON_RUNR, Swap1);
        EventManager.SubscribeToEvent(EventEnum.ON_RUNL, Swap1);

    }
    public void Execute()
    {
        MyPS.Shoot();
    }
    public void Swap1()
    {
        MyPFSM.ChangePlayerState(new PlayerMoveRState());
    }
    public void Swap2()
    {
        MyPFSM.ChangePlayerState(new PlayerMoveLState());
    }
    public void Swap3()
    {
        MyPFSM.ChangePlayerState(new PlayerRunRState());
    }
    public void Swap4()
    {
        MyPFSM.ChangePlayerState(new PlayerRunLState());
    }

    public void Exit()
    {
        EventManager.RemoveListener(EventEnum.ON_MOVER, Swap1);
        EventManager.RemoveListener(EventEnum.ON_MOVEL, Swap1);
        EventManager.RemoveListener(EventEnum.ON_RUNR, Swap1);
        EventManager.RemoveListener(EventEnum.ON_RUNL, Swap1);
    }
}
