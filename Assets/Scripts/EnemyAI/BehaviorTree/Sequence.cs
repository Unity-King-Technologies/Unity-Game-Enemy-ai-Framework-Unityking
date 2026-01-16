using System.Collections.Generic;

namespace UnityKing.EnemyAI.BehaviorTree
{
    public class Sequence : BTNode
    {
        private List<BTNode> children;

        public Sequence(List<BTNode> nodes) => children = nodes;

        public override State Tick()
        {
            foreach (var node in children)
            {
                var result = node.Tick();
                if (result != State.Success)
                    return result;
            }
            return State.Success;
        }
    }
}
