namespace UnityKing.EnemyAI.FSM
{
    public class StateMachine
    {
        private IState currentState;

        public void Initialize(IState startState)
        {
            currentState = startState;
            currentState.Enter();
        }

        public void ChangeState(IState newState)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }

        public void Update()
        {
            currentState?.Tick();
        }
    }
}
