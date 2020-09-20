public interface IPlayerState
{
    void Swap1();
    void Swap2();
}
public class PlayerStateMachine
{
    IState _currentPlayerState;
     //public static Dictionary<EventEnum, System.Action> stateMachineDic = new Dictionary<EventEnum, System.Action>();
    public void RunPlayerState()
    {
    //Een referentie naar deze funtie zetten in de gamemanager zodat het werkt.
        if (_currentPlayerState != null) _currentPlayerState.Execute();
    }

    public void ChangePlayerState(IState _newState)
    {
        if (_currentPlayerState != null)
        {
            _currentPlayerState.Exit();
        }
        _currentPlayerState = _newState;
        _currentPlayerState.Enter();
    }
}
