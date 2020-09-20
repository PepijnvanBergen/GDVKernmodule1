using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReverseState : IState, IPlayerState
{
    PlayerStateMachine MyPFSM = new PlayerStateMachine();
    PlayerScript MyPS = new PlayerScript();
    public void Enter()
    {
        EventManager.SubscribeToEvent(EventEnum.ON_RUN, Swap1);
        EventManager.SubscribeToEvent(EventEnum.ON_SHOOT, Swap2);
    }

    public void Execute()
    {
        MyPS.Move();
    }
    public void Swap1()
    {
        MyPFSM.ChangePlayerState(new PlayerRunState());
    }
    public void Swap2()
    {
        MyPFSM.ChangePlayerState(new PlayerShootState());
    }

    public void Exit()
    {
        EventManager.RemoveListener(EventEnum.ON_RUN, Swap1);
        EventManager.RemoveListener(EventEnum.ON_SHOOT, Swap2);
    }
}
