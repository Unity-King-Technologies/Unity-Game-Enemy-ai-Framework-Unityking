namespace UnityKing.EnemyAI.BehaviorTree
{
    public abstract class BTNode
    {
        public enum State { Success, Failure, Running }
        public abstract State Tick();
    }
}
