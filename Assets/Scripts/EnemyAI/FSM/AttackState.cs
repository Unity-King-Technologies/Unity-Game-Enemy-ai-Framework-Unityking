using UnityKing.EnemyAI.FSM;

namespace UnityKing.EnemyAI
{
    public class AttackState : IState
    {
        private EnemyAIController ai;

        public AttackState(EnemyAIController ai) => this.ai = ai;

        public void Enter() { }

        public void Tick()
        {
            if (!ai.blackboard.isInAttackRange)
                ai.ChangeState(new ChaseState(ai));
        }

        public void Exit() { }
    }
}
