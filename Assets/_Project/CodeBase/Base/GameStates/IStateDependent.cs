namespace CodeBase.Base.GameStates
{
    public interface IStateDependent
    {
        public void StateChanged(GameStateTypes previouslyState, GameStateTypes currentState);
        public void Restart();
    }
}
