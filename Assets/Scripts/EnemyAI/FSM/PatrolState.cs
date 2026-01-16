using UnityKing.EnemyAI.FSM;

namespace UnityKing.EnemyAI
{
    public class PatrolState : IState
    {
        private EnemyAIController ai;

        public PatrolState(EnemyAIController ai) => this.ai = ai;

        public void Enter() { }

        public void Tick()
        {
            if (ai.blackboard.target != null)
                ai.ChangeState(new ChaseState(ai));
        }

        public void Exit() { }
    }
}
