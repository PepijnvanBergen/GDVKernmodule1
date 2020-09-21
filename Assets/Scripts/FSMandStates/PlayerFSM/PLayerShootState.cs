public class PlayerShootState : IState, IPlayerState
{
    PlayerStateMachine MyPFSM = new PlayerStateMachine();
    PlayerScript MyPS = new PlayerScript();
    public void Enter()
    {
        EventManager.SubscribeToEvent(EventEnum.ON_MOVER, Swap1);
        EventManager.SubscribeToEvent(EventEnum.ON_MOVEL, Swap2);
        EventManager.SubscribeToEvent(EventEnum.ON_RUNR, Swap3);
        EventManager.SubscribeToEvent(EventEnum.ON_RUNL, Swap4);
        EventManager.SubscribeToEvent(EventEnum.ON_IDLE, Swap5);
    }
    public void Execute()
    {
        MyPS.Shoot();
        EventManager.RaiseEvent(EventEnum.ON_SHOOT);
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
    public void Swap5()
    {
        MyPFSM.ChangePlayerState(new PlayerIdleState());
    }

    public void Exit()
    {
        EventManager.RemoveListener(EventEnum.ON_MOVER, Swap1);
        EventManager.RemoveListener(EventEnum.ON_MOVEL, Swap2);
        EventManager.RemoveListener(EventEnum.ON_RUNR, Swap3);
        EventManager.RemoveListener(EventEnum.ON_RUNL, Swap4);
        EventManager.RemoveListener(EventEnum.ON_IDLE, Swap5);
    }
}
