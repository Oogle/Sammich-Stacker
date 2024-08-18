using Components;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(DragComponent))]
    [RequireComponent(typeof(Collider2D))]
    public class IngredientController: MonoBehaviour
    {
        private DragComponent dragComponent;
        private GameArea gameArea;
        private bool onSandwich;
        private void Start()
        {
            dragComponent = GetComponent<DragComponent>();
            gameArea = GameObject.FindGameObjectWithTag("PlayArea").GetComponent<GameArea>();
        }

        [SerializeField]
        private LayerMask killDraggableMask;


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (onSandwich) return;
            var otherLayer = other.gameObject.layer;
            var isinMask = killDraggableMask.value == (killDraggableMask.value | (1 << otherLayer));

            if (!isinMask) return;

            dragComponent.isDraggable = false;
            gameArea.UpdateIngredients(gameObject);
            onSandwich = true;
        }
    }
}