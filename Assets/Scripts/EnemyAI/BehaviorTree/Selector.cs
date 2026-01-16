using System.Collections.Generic;

namespace UnityKing.EnemyAI.BehaviorTree
{
    public class Selector : BTNode
    {
        private List<BTNode> children;

        public Selector(List<BTNode> nodes) => children = nodes;

        public override State Tick()
        {
            foreach (var node in children)
            {
                var result = node.Tick();
                if (result != State.Failure)
                    return result;
            }
            return State.Failure;
        }
    }
}
