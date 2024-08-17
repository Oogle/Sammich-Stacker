
using Components;
using InputHandling;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private InputHandler inputHandler;
        private new Camera camera;
        private int ingredientLayerMask;
        private DragComponent draggedComponent;

        [Header("Dragging parameters")]
        [Range(0.0f, 100.0f)]
        public float dampingRatio = 1.0f;

        [Range(0.0f, 100.0f)]
        public float oscillationFrequency = 5.0f;

        private void Start()
        {
            ingredientLayerMask = LayerMask.GetMask("Ingredient");
            inputHandler = InputHandler.Instance;
            inputHandler.OnMouseDownEvents += OnMouseDown;
            inputHandler.OnMouseUpEvents += OnMouseUp;

            camera = Camera.main;
            // ReSharper disable once InvertIf
            if (camera == null)
            {
                Debug.LogError("No camera found");
                Application.Quit();
            }
        }

        public void Update()
        {
            inputHandler.HandleInput();
            
            var worldPoint = camera.ScreenToWorldPoint(Input.mousePosition);
            
            draggedComponent?.UpdateDrag(worldPoint);
        }

        private void OnMouseDown()
        {
            var worldPoint = camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(
                worldPoint, 
                Vector2.zero, 
                int.MaxValue, 
                ingredientLayerMask
            );

            var hitGameObject = hit.collider?.gameObject;
            if (hitGameObject == null) return;

            draggedComponent = hitGameObject.GetComponent<DragComponent>();
            draggedComponent?.StartDrag(worldPoint, dampingRatio, oscillationFrequency);
            
        }

        private void OnMouseUp()
        {
            Debug.Log("OnMouseUp");
            draggedComponent?.EndDrag();
        }
    }
}