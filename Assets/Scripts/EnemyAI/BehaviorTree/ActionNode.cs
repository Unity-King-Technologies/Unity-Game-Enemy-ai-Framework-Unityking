using System;

namespace UnityKing.EnemyAI.BehaviorTree
{
    public class ActionNode : BTNode
    {
        private Func<State> action;

        public ActionNode(Func<State> action)
        {
            this.action = action;
        }

        public override State Tick()
        {
            if (action == null)
                return State.Failure;

            return action.Invoke();
        }
    }
}
