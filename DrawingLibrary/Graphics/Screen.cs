using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using System.Runtime.InteropServices;

namespace DrawingLibrary.Graphics
{
    public class Screen : IScreen
    {
        public int Height { get; }
        public int Width { get; }
        private RenderTarget2D _renderTarget;
        private bool isScreenSet;


        public Screen(RenderTarget2D renderTarget2D)
        {
            _renderTarget = renderTarget2D;
            Height = _renderTarget.Height;
            Width = _renderTarget.Width;
            isScreenSet = false;

        }

        public void Present(ISpritesRenderer spritesRenderer, bool textureFiltering = true)
        {
            if (spritesRenderer == null)
            {
                throw new ArgumentNullException();
            }

            spritesRenderer.Begin(textureFiltering);
            spritesRenderer.Draw(_renderTarget, CalculateDestinationRectangle(), Color.White);
            spritesRenderer.End();
        }

        public void Set()
        {
            if (isScreenSet)
            {
                throw new Exception();
            }
            _renderTarget.GraphicsDevice.SetRenderTarget(_renderTarget);
            isScreenSet = true;
        }

        public void UnSet()
        {
            if (!isScreenSet)
            {
                throw new Exception();
            }
            _renderTarget.GraphicsDevice.SetRenderTarget(null);
            isScreenSet = false;
        }

        public Rectangle CalculateDestinationRectangle()
        {
            float  windowWidth = _renderTarget.GraphicsDevice.Viewport.Width;
            float windowHeight = _renderTarget.GraphicsDevice.Viewport.Height;
            float windowAspectRatio = windowWidth / windowHeight;

            float rectangleWidth = Width;
            float rectangleHeight = Height;

            float screenAspectRatio = rectangleWidth / rectangleHeight;

            float rectangleX = 0;
            float rectangleY = 0;

            if (windowAspectRatio >= screenAspectRatio)
            { 
                rectangleHeight = windowHeight;
                rectangleWidth = rectangleHeight * screenAspectRatio;
                rectangleX = (windowWidth / 2) - (rectangleWidth / 2);
            }

            else
            {
                rectangleWidth = windowWidth;
                rectangleHeight = rectangleWidth / screenAspectRatio;
                rectangleY = (windowHeight / 2) - (rectangleHeight / 2);
            }

            return new Rectangle((int) rectangleX, (int)rectangleY, (int)rectangleWidth, (int)rectangleHeight);
        }

        public void Dispose()
        {
            _renderTarget.Dispose();
        }
    }

}
