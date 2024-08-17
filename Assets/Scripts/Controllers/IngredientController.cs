using Components;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(DragComponent))]
    [RequireComponent(typeof(Collider2D))]
    public class IngredientController: MonoBehaviour
    {
        private DragComponent dragComponent;

        private void Start()
        {
            dragComponent = GetComponent<DragComponent>();
        }

        [SerializeField]
        private LayerMask killDraggableMask;


        private void OnCollisionEnter2D(Collision2D other)
        {
            var otherLayer = other.gameObject.layer;
            var isinMask = killDraggableMask.value == (killDraggableMask.value | (1 << otherLayer));

            if (!isinMask) return;

            dragComponent.isDraggable = false;
        }
    }
}