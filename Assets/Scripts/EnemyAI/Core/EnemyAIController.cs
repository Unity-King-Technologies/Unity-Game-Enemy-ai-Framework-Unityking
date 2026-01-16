using UnityEngine;
using UnityKing.EnemyAI.FSM;

namespace UnityKing.EnemyAI
{
    [RequireComponent(typeof(EnemyPerception))]
    [RequireComponent(typeof(EnemyMovement))]
    public class EnemyAIController : MonoBehaviour
    {
        public StateMachine stateMachine;
        public EnemyBlackboard blackboard;

        private EnemyPerception perception;

        void Awake()
        {
            blackboard = new EnemyBlackboard();
            perception = GetComponent<EnemyPerception>();

            stateMachine = new StateMachine();
            stateMachine.Initialize(new IdleState(this));
        }

        void Update()
        {
            blackboard.target = perception.CurrentTarget;
            stateMachine.Update();
        }

        public void ChangeState(IState newState)
        {
            stateMachine.ChangeState(newState);
        }
    }
}
