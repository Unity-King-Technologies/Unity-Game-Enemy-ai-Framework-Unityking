using UnityEngine;

namespace UnityKing.EnemyAI
{
    public class VisionSensor : MonoBehaviour
    {
        public float viewDistance = 10f;
        public LayerMask targetLayer;

        public Transform DetectedTarget { get; private set; }

        void Update()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, viewDistance, targetLayer);
            DetectedTarget = hits.Length > 0 ? hits[0].transform : null;
        }
    }
}
