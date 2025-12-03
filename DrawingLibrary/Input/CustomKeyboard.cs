using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Input
{
    public class CustomKeyboard : ICustomKeyboard
    {
        private KeyboardState _current;
        private KeyboardState _previous;
        private static CustomKeyboard _instance = null;

        public static CustomKeyboard Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomKeyboard();
                }
                return _instance;
            }
        }


        private CustomKeyboard()
        {
            _current = new KeyboardState();
            _previous = new KeyboardState();
        }

        public bool IsKeyClicked(Keys key)
        {
            bool keyPressed = _current.IsKeyDown(key) && _previous.IsKeyUp(key);
            return keyPressed;
        }

        public bool IsKeyDown(Keys key)
        {
            return _current.IsKeyDown(key);
        }

        public void Update()
        {
            _previous = _current;
            _current = Keyboard.GetState();
        }
    }
}
