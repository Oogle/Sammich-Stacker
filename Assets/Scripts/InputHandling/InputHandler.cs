using UnityEngine;

namespace InputHandling
{
    public class InputHandler
    {
        private static InputHandler instance;

        public static InputHandler Instance
        {
            get
            {
                instance ??= new InputHandler();
                return instance;
            }
        }

        private InputHandler()
        {
        }

        public bool Enabled { get; set; } = true;

        public delegate void OnMouseDown();

        public delegate void OnMouseUp();

        public OnMouseDown OnMouseDownEvents;
        public OnMouseUp OnMouseUpEvents;

        public void HandleInput()
        {
            if (!Enabled) return;

            if (Input.GetMouseButtonDown(0))
                OnMouseDownEvents();
            else if (Input.GetMouseButtonUp(0))
                OnMouseUpEvents();
        }
    }
}