namespace UnityKing.EnemyAI.FSM
{
    public interface IState
    {
        void Enter();
        void Tick();
        void Exit();
    }
}
