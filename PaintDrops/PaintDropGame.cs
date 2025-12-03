using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DrawingLibrary.Graphics;
using DrawingLibrary.Input;
using ShapeLibrary;
using System.Collections.Generic;
using PaintDropSimulation;
using System;
namespace PaintDrops;
using PatternGenerationLib;

public class PaintDropGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Screen _screen;
    private RenderTarget2D _renderTarget;
    private SpritesRenderer _spriteRenderer;
    private ShapesRenderer _shapesRenderer;
    private ISurface _paintSurface;
    private const int SCREEN_WIDTH = 800;
    private const int SCREEN_HEIGHT = 420;
    private const float PAINT_RADIUS = 10;
    private Random _random;
    private IPatternGenerator _patternGenerator;
    private bool _isPatternGenerated;
    private int _currentPaintDrop;
    private List<Colour> _colorsStorage;
    private Colour _currentColour;
    private bool _isPreferenceMode;
    private IRectangle _colourWindow;

    private bool _isPhyllotaxis;

    public PaintDropGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    private void HandleNewPaintDrop(IPaintDrop drop)
    {
        _colorsStorage.Add(drop.Circle.Colour);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _renderTarget = new RenderTarget2D(GraphicsDevice, SCREEN_WIDTH, SCREEN_HEIGHT);
        _paintSurface = PaintDropSimulationFactory.CreateSurface(SCREEN_WIDTH, SCREEN_HEIGHT);
        _random = new Random();
        _screen = new Screen(_renderTarget);
        _isPatternGenerated = false;
        Window.AllowUserResizing = true;
        _currentPaintDrop = 0;
        _colorsStorage = new List<Colour>();
        _isPreferenceMode = false;
        _currentColour = new Colour(0, 255, 0);
        _colourWindow = ShapesFactory.CreateRectangle(15, 15, 50, 50, _currentColour);
        _paintSurface.AddPaintDropEvent += HandleNewPaintDrop;
        // Pattern Generation
        _isPhyllotaxis = true;
        _patternGenerator = PatternGenerationFactory.CreatePhyllotaxis();
        _paintSurface.PatternGeneration += _patternGenerator.CalculatePatternPoint;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _spriteRenderer = new SpritesRenderer(_graphics.GraphicsDevice);
        _shapesRenderer = new ShapesRenderer(_graphics.GraphicsDevice);
        GraphicsDevice.Clear(Color.CornflowerBlue);

    }

    protected override void Update(GameTime gameTime)
    {

        CustomKeyboard.Instance.Update();
        CustomMouse.Instance.Update();
        // Exit the program
        if (CustomKeyboard.Instance.IsKeyClicked(Keys.Escape))
        {
            Exit();
        }
        // Stop pattern generation
        if (CustomKeyboard.Instance.IsKeyClicked(Keys.E))
        {
            if (_isPreferenceMode)
            {
                return;
            }
            _isPatternGenerated = false;
        }
        // Start pattern generation
        else if (CustomKeyboard.Instance.IsKeyClicked(Keys.M))
        {
            if (_isPreferenceMode)
            {
                return;
            }
            _isPatternGenerated = true;
        }
        else if (CustomKeyboard.Instance.IsKeyClicked(Keys.P))
        {
            _isPhyllotaxis = !_isPhyllotaxis;
            if (_isPreferenceMode)
            {
                return;
            }
            _paintSurface.PatternGeneration -= _patternGenerator.CalculatePatternPoint;
            if (_isPhyllotaxis)
            {
                _patternGenerator = PatternGenerationFactory.CreatePhyllotaxis();
            }
            else
            {
                _patternGenerator = PatternGenerationFactory.CreateSpirograph();
            }
            _paintSurface.PatternGeneration += _patternGenerator.CalculatePatternPoint;
        }
        // Create new paint drops when pattern mode is active
        if (_isPatternGenerated)
        {
            int red = _random.Next(256);
            int green = _random.Next(256);
            int blue = _random.Next(256);
            _paintSurface.GeneratePaintDropPattern(PAINT_RADIUS, new Colour(red, green, blue));
        }
        // Generate a random color
        if (CustomKeyboard.Instance.IsKeyClicked(Keys.R))
        {
            if (!_isPreferenceMode)
            {
                return;
            }
            int red = _random.Next(256);
            int green = _random.Next(256);
            int blue = _random.Next(256);
            _currentColour = new Colour(red, green, blue);
            _colourWindow.Colour = _currentColour;
        }

        Vector2? mousePosition = CustomMouse.Instance.GetScreenPosition(_screen);
        if (mousePosition.HasValue)
        {
            // Add new paint drop on click
            if (CustomMouse.Instance.IsLeftButtonClicked())
            {
                if (_isPreferenceMode)
                {
                    return;
                }
                int red = _random.Next(256);
                int green = _random.Next(256);
                int blue = _random.Next(256);
                _currentColour = new Colour(red, green, blue);
                _colourWindow.Colour = _currentColour;
                ICircle circle = ShapesFactory.CreateCircle(mousePosition.Value.X, mousePosition.Value.Y, PAINT_RADIUS + 30, _currentColour);
                IPaintDrop paintDrop = PaintDropSimulationFactory.CreatePaintDrop(circle);
                _paintSurface.AddPaintDrop(paintDrop);

            }
            // Clear the paint drops
            if (CustomMouse.Instance.IsRightButtonClicked())
            {
                if (_isPreferenceMode)
                {
                    return;
                }
                _isPreferenceMode = false;
                _currentPaintDrop = 0;
                _paintSurface.Drops.Clear();
                _colorsStorage.Clear();
            }
        }
        // Preference mode
        if (CustomKeyboard.Instance.IsKeyClicked(Keys.Q))
        {
            if (_isPatternGenerated || _paintSurface.Drops.Count == 0)
            {
                return;
            }
            _isPreferenceMode = !_isPreferenceMode;
            if (_isPreferenceMode)
            {
                for (int i = 0; i < _paintSurface.Drops.Count; i++)
                {
                    if (i == _currentPaintDrop)
                    {
                        _paintSurface.Drops[i].Circle.Colour = new Colour(0, 255, 0);
                    }
                    else
                    {
                        _paintSurface.Drops[i].Circle.Colour = new Colour(255, 0, 0);
                    }
                }
            }
            else
            {
                for (int i = 0; i < _paintSurface.Drops.Count; i++)
                {
                    _paintSurface.Drops[i].Circle.Colour = _colorsStorage[i];
                }
            }
        }
        // Move to the next paintdrop
        if (CustomKeyboard.Instance.IsKeyClicked(Keys.N))
        {
            if (!_isPreferenceMode || _paintSurface.Drops.Count == 0)
            {
                return;
            }
            if (_paintSurface.Drops[_currentPaintDrop].Circle.Colour == new Colour(0, 255, 0))
            {
                _paintSurface.Drops[_currentPaintDrop].Circle.Colour = new Colour(255, 0, 0);
            }
            if (_currentPaintDrop >= _paintSurface.Drops.Count - 1)
            {
                _currentPaintDrop = 0;
            }
            else
            {
                _currentPaintDrop++;
            }
            _paintSurface.Drops[_currentPaintDrop].Circle.Colour = new Colour(0, 255, 0);
        }
        // Apply the color to a paint drop
        if (CustomKeyboard.Instance.IsKeyClicked(Keys.A))
        {
            if (!_isPreferenceMode)
            {
                return;
            }
            _paintSurface.Drops[_currentPaintDrop].Circle.Colour = _currentColour;
            _colorsStorage[_currentPaintDrop] = _currentColour;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _screen.Set();
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _shapesRenderer.Begin();

        foreach (var drop in _paintSurface.Drops)
        {
            _shapesRenderer.DrawShape(drop.Circle);
        }
        if (_isPreferenceMode)
        {
            _shapesRenderer.DrawShape(_colourWindow);
        }

        _shapesRenderer.End();
        _screen.UnSet();
        _screen.Present(_spriteRenderer);
        base.Draw(gameTime);
    }
}
