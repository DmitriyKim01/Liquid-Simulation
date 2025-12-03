using DrawingLibrary.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace DrawingLibrary.Input
{
    public class CustomMouse : ICustomMouse
    {
        private static CustomMouse _instance;
        private MouseState _current;
        private MouseState _previous;
        public Point WindowPosition
        {
            get
            {
                return _current.Position;
            }
        }

        public static CustomMouse Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomMouse();
                }
                return _instance;
            }
        }
        private CustomMouse()
        {
            _current = new MouseState();
            _previous = new MouseState();
        }

        public Vector2? GetScreenPosition(IScreen screen)
        {
            Rectangle rectangle = screen.CalculateDestinationRectangle();

            if (_current.X < rectangle.X ||
                _current.X > rectangle.X + rectangle.Width ||
                _current.Y < rectangle.Y ||
                _current.Y > rectangle.Y + rectangle.Height
                )
            {
                return null;
            }

            float scaledPointX = _current.X - rectangle.X;
            float scaledPointY = _current.Y - rectangle.Y;

            float pointX = screen.Width / (float)rectangle.Width * scaledPointX;
            float pointY = screen.Height / (float)rectangle.Height * scaledPointY;

            return new Vector2(pointX, pointY);
        }

        public bool IsLeftButtonClicked()
        {
            bool mouseClicked = _current.LeftButton == ButtonState.Pressed && _previous.LeftButton == ButtonState.Released;
            return mouseClicked;
        }

        public bool IsLeftButtonDown()
        {
            bool mouseClicked = _current.LeftButton == ButtonState.Pressed;
            return mouseClicked;
        }

        public bool IsLeftButtonUp()
        {
            bool mouseClicked = _current.LeftButton == ButtonState.Released;
            return mouseClicked;
        }

        public bool IsMiddleButtonClicked()
        {
            bool mouseClicked = _current.MiddleButton == ButtonState.Pressed && _previous.MiddleButton == ButtonState.Released;
            return mouseClicked;
        }

        public bool IsMiddleButtonDown()
        {
            bool mouseClicked = _current.MiddleButton == ButtonState.Pressed;
            return mouseClicked;
        }

        public bool IsRightButtonClicked()
        {
            bool mouseClicked = _current.RightButton == ButtonState.Pressed && _previous.RightButton == ButtonState.Released;
            return mouseClicked;
        }

        public bool IsRightButtonDown()
        {
            bool mouseClicked = _current.RightButton == ButtonState.Pressed;
            return mouseClicked;
        }


        public void Update()
        {
            _previous = _current;
            _current = Mouse.GetState();
        }

    }
}
