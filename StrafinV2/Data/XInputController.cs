using SharpDX.XInput;

namespace StrafinV2.Data
{
    public static class XInputController
    {
        static XInputController()
        {
            controller = new Controller(UserIndex.One);
            connected = controller.IsConnected;
        }

        public static Controller controller;
        public static Gamepad gamepad;
        public static int deadband = 3200;
        public static bool connected = false;
        public static float left_x = 0;
        public static float left_y = 0;
        public static float right_x = 0;
        public static float right_y = 0;

        public static void Update()
        {
            if (!connected)
                return;

            gamepad = controller.GetState().Gamepad;

            left_x = (Math.Abs((float)gamepad.LeftThumbX) < deadband) ? 0 : (float)gamepad.LeftThumbX / short.MaxValue * 100;
            left_y = (Math.Abs((float)gamepad.LeftThumbY) < deadband) ? 0 : (float)gamepad.LeftThumbY / short.MaxValue * 100;

            right_x = (Math.Abs((float)gamepad.RightThumbX) < deadband) ? 0 : (float)gamepad.RightThumbX / short.MaxValue * 100;
            right_y = (Math.Abs((float)gamepad.RightThumbY) < deadband) ? 0 : (float)gamepad.RightThumbY / short.MaxValue * 100;
            return;
        }
    }
}
