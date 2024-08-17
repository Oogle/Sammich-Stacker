namespace Input
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
    }
}