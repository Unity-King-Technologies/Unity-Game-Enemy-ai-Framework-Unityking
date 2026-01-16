using UnityEngine;

namespace UnityKing.EnemyAI
{
    [System.Serializable]
    public class EnemyBlackboard
    {
        public Transform target;
        public float distanceToTarget;
        public bool canSeeTarget;
        public bool isInAttackRange;
    }
}
