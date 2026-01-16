using UnityEngine;

namespace UnityKing.EnemyAI
{
    public class EnemyMovement : MonoBehaviour
    {
        public float speed = 3f;

        public void MoveTo(Vector3 target)
        {
            Vector3 dir = (target - transform.position).normalized;
            transform.position += dir * speed * Time.deltaTime;
        }
    }
}
