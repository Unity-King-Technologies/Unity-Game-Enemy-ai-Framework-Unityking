using UnityEngine;

namespace UnityKing.EnemyAI
{
    public class EnemyPerception : MonoBehaviour
    {
        public VisionSensor vision;
        public Transform CurrentTarget { get; private set; }

        void Update()
        {
            CurrentTarget = vision.DetectedTarget;
        }
    }
}
