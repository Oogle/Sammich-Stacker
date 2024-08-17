using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DragComponent : MonoBehaviour
    {

        private TargetJoint2D targetJoint;
        public bool isDraggable { get; set; } = true;
        private new Rigidbody2D rigidbody;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }
        
        public void StartDrag(Vector2 targetPosition, float dampingRatio, float frequency)
        {
            if(!isDraggable) return;
            
            targetJoint = rigidbody.gameObject.AddComponent<TargetJoint2D>();
            targetJoint.dampingRatio = dampingRatio;
            targetJoint.frequency = frequency;

            // Attach the anchor to the local-point where we clicked.
            targetJoint.anchor = targetJoint.transform.InverseTransformPoint(targetPosition);
        }

        public void EndDrag()
        {
            Destroy(targetJoint);
            targetJoint = null;
        }

        public void UpdateDrag(Vector2 targetPosition)
        {
            if (!targetJoint) return;
            targetJoint.target = targetPosition;
            Debug.DrawLine(targetJoint.transform.TransformPoint(targetJoint.anchor), targetPosition,  Color.cyan);
        }
    }
}
