public class PlayerMoveRState : IState , IPlayerState
{
    PlayerStateMachine MyPFSM = new PlayerStateMachine();
    PlayerScript MyPS = new PlayerScript();
    public void Enter()
    {
        EventManager.SubscribeToEvent(EventEnum.ON_MOVEL, Swap1);
        EventManager.SubscribeToEvent(EventEnum.ON_RUNR, Swap2);
        EventManager.SubscribeToEvent(EventEnum.ON_RUNL, Swap3);
        EventManager.SubscribeToEvent(EventEnum.ON_SHOOT, Swap4);
    }

    public void Execute()
    {
        MyPS.MoveR();
    }
    public void Swap1()
    {
        MyPFSM.ChangePlayerState(new PlayerMoveLState());
    }
    public void Swap2()
    {
        MyPFSM.ChangePlayerState(new PlayerRunRState());
    }
    public void Swap3()
    {
        MyPFSM.ChangePlayerState(new PlayerRunLState());
    }
    public void Swap4()
    {
        MyPFSM.ChangePlayerState(new PlayerShootState());
    }

    public void Exit()
    {
        EventManager.RemoveListener(EventEnum.ON_MOVEL, Swap1);
        EventManager.RemoveListener(EventEnum.ON_RUNR, Swap2);
        EventManager.RemoveListener(EventEnum.ON_RUNL, Swap3);
        EventManager.RemoveListener(EventEnum.ON_SHOOT, Swap4);
    }
}

public class PlayerMoveLState : IState, IPlayerState
{
    PlayerStateMachine MyPFSM = new PlayerStateMachine();
    PlayerScript MyPS = new PlayerScript();
    public void Enter()
    {
        EventManager.SubscribeToEvent(EventEnum.ON_MOVER, Swap1);
        EventManager.SubscribeToEvent(EventEnum.ON_RUNR, Swap1);
        EventManager.SubscribeToEvent(EventEnum.ON_RUNL, Swap2);
        EventManager.SubscribeToEvent(EventEnum.ON_SHOOT, Swap2);
    }

    public void Execute()
    {
        MyPS.MoveL();
    }
    public void Swap1()
    {
        MyPFSM.ChangePlayerState(new PlayerMoveRState());
    }
    public void Swap2()
    {
        MyPFSM.ChangePlayerState(new PlayerRunRState());
    }
    public void Swap3()
    {
        MyPFSM.ChangePlayerState(new PlayerRunLState());
    }
    public void Swap4()
    {
        MyPFSM.ChangePlayerState(new PlayerShootState());
    }
    public void Exit()
    {
        EventManager.RemoveListener(EventEnum.ON_MOVER, Swap1);
        EventManager.RemoveListener(EventEnum.ON_RUNR, Swap1);
        EventManager.RemoveListener(EventEnum.ON_RUNL, Swap2);
        EventManager.RemoveListener(EventEnum.ON_SHOOT, Swap2);
    }
}
