public class PlayerShootState : IState, IPlayerState
{
    PlayerStateMachine MyPFSM = new PlayerStateMachine();
    PlayerScript MyPS = new PlayerScript();
    public void Enter()
    {
        EventManager.SubscribeToEvent(EventEnum.ON_MOVE, Swap1);
        EventManager.SubscribeToEvent(EventEnum.ON_SHOOT, Swap2);
    }
    public void Execute()
    {
        MyPS.Shoot();
    }
    public void Swap1()
    {
        MyPFSM.ChangePlayerState(new PlayerMoveState());
    }
    public void Swap2()
    {
        MyPFSM.ChangePlayerState(new PlayerShootState());
    }

    public void Exit()
    {
        EventManager.RemoveListener(EventEnum.ON_MOVE, Swap1);
        EventManager.RemoveListener(EventEnum.ON_SHOOT, Swap2);
    }
}
