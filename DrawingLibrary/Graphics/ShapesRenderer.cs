using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShapeLibrary;


namespace DrawingLibrary.Graphics
{
    public sealed class ShapesRenderer : IShapesRenderer
    {
        private bool _isDisposed;
        private GraphicsDevice _graphicsDevice;
        private BasicEffect _effect;

        private VertexPositionColor[] _vertices;
        private int[] _indices;

        private int _shapeCount;
        private int _vertexCount;
        private int _indexCount;

        private bool _isStarted;


        public ShapesRenderer(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice ?? throw new ArgumentNullException("graphicsDevice");

            _effect = new BasicEffect(_graphicsDevice);
            _effect.TextureEnabled = false;
            _effect.FogEnabled = false;
            _effect.LightingEnabled = false;
            _effect.VertexColorEnabled = true;
            _effect.World = Matrix.Identity;
            _effect.View = Matrix.Identity;
            _effect.Projection = Matrix.Identity;


            const int MaxVertexCount = 1024;
            const int MaxIndexCount = MaxVertexCount * 3;

            _vertices = new VertexPositionColor[MaxVertexCount];
            _indices = new int[MaxIndexCount];

            _shapeCount = 0;
            _vertexCount = 0;
            _indexCount = 0;

            _isStarted = false;


        }
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _effect?.Dispose();
            _isDisposed = true;
        }

        public void Begin()
        {
            if (_isStarted)
            {
                throw new Exception("batching is already started.");
            }


            Viewport vp = _graphicsDevice.Viewport;
            _effect.Projection = Matrix.CreateOrthographicOffCenter(0, vp.Width, vp.Height, 0, 0f, 1f);
            _effect.View = Matrix.Identity;


            _isStarted = true;
        }

        public void End()
        {
            Flush();
            _isStarted = false;
        }

        private void Flush()
        {
            if (_shapeCount == 0)
            {
                return;
            }

            EnsureStarted();

            foreach (EffectPass pass in _effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                _graphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                    PrimitiveType.TriangleList,
                    _vertices,
                    0,
                    _vertexCount,
                    _indices,
                    0,
                    _indexCount / 3);
            }

            _shapeCount = 0;
            _vertexCount = 0;
            _indexCount = 0;
        }

        private void EnsureStarted()
        {
            if (!_isStarted)
            {
                throw new Exception("batching was never started.");
            }
        }

        private void EnsureSpace(int shapeVertexCount, int shapeIndexCount)
        {
            if (shapeVertexCount > _vertices.Length)
            {
                throw new Exception("Maximum shape vertex count is: " + _vertices.Length);
            }

            if (shapeIndexCount > _indices.Length)
            {
                throw new Exception("Maximum shape index count is: " + _indices.Length);
            }

            if (_vertexCount + shapeVertexCount > _vertices.Length ||
                _indexCount + shapeIndexCount > _indices.Length)
            {
                Flush();
            }
        }
        //Draw shape method that takes an IShape
        public void DrawShape(IShape shape)
        {
           if(shape is ICircle)
                DrawCircle(shape as ICircle);
           else if(shape is IRectangle)
                DrawRectangle(shape as IRectangle);
        }
      
        private void DrawRectangle(IRectangle rectangle)
        {
            EnsureStarted();

            const int shapeVertexCount = 4;
            const int shapeIndexCount = 6;

            EnsureSpace(shapeVertexCount, shapeIndexCount);

            _indices[_indexCount++] = 0 + _vertexCount;
            _indices[_indexCount++] = 1 + _vertexCount;
            _indices[_indexCount++] = 2 + _vertexCount;
            _indices[_indexCount++] = 0 + _vertexCount;
            _indices[_indexCount++] = 2 + _vertexCount;
            _indices[_indexCount++] = 3 + _vertexCount;

            _vertices[_vertexCount++] = new VertexPositionColor(new Vector3(rectangle.Vertices[0].X, rectangle.Vertices[0].Y, 0f), new Color(rectangle.Colour.Red, rectangle.Colour.Green, rectangle.Colour.Blue));
            _vertices[_vertexCount++] = new VertexPositionColor(new Vector3(rectangle.Vertices[1].X, rectangle.Vertices[1].Y, 0f), new Color(rectangle.Colour.Red, rectangle.Colour.Green, rectangle.Colour.Blue));
            _vertices[_vertexCount++] = new VertexPositionColor(new Vector3(rectangle.Vertices[2].X, rectangle.Vertices[2].Y, 0f), new Color(rectangle.Colour.Red, rectangle.Colour.Green, rectangle.Colour.Blue));
            _vertices[_vertexCount++] = new VertexPositionColor(new Vector3(rectangle.Vertices[3].X, rectangle.Vertices[3].Y, 0f), new Color(rectangle.Colour.Red, rectangle.Colour.Green, rectangle.Colour.Blue));

            _shapeCount++;

        }
        private void DrawCircle(ICircle circle)
        {
            EnsureStarted();

            int shapeVertexCount = circle.Vertices.Length;
            int shapeTriangleCount = shapeVertexCount - 2;
            int shapeIndexCount = shapeTriangleCount * 3;

            EnsureSpace(shapeVertexCount, shapeIndexCount);

            int index = 1;

            for (int i = 0; i < shapeTriangleCount; i++)
            {
                _indices[_indexCount++] = 0 + _vertexCount;
                _indices[_indexCount++] = index + _vertexCount;
                _indices[_indexCount++] = index + 1 + _vertexCount;

                index++;
            }

            for (int i = 0; i < shapeVertexCount; i++)
            {
                _vertices[_vertexCount++] = new VertexPositionColor(new Vector3(circle.Vertices[i].X, circle.Vertices[i].Y, 0f), new Color(circle.Colour.Red, circle.Colour.Green, circle.Colour.Blue));
            }
            _shapeCount++;
        }
     
    }
}
