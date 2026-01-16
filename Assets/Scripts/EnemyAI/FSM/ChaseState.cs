using UnityKing.EnemyAI.FSM;

namespace UnityKing.EnemyAI
{
    public class ChaseState : IState
    {
        private EnemyAIController ai;

        public ChaseState(EnemyAIController ai) => this.ai = ai;

        public void Enter() { }

        public void Tick()
        {
            if (ai.blackboard.target == null)
                ai.ChangeState(new IdleState(ai));

            if (ai.blackboard.isInAttackRange)
                ai.ChangeState(new AttackState(ai));
        }

        public void Exit() { }
    }
}
