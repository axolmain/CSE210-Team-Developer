using System.Collections.Generic;
using System.Reflection.Metadata;
using Raylib_cs;
using Unit05.Game.Casting;



namespace Unit05.Game.Services
{
    /// <summary>
    /// <para>Outputs the game state.</para>
    /// <para>
    /// The responsibility of the class of objects is to draw the game state on the screen. 
    /// </para>
    /// </summary>
    public class VideoService
    {
        private bool _debug = false;
        private Raylib_cs.Texture2D _background;

        /// <summary>
        /// Constructs a new instance of KeyboardService using the given cell size.
        /// </summary>
        /// <param name="cellSize">The cell size (in pixels).</param>
        public VideoService(bool debug)
        {
            this._debug = debug;
        }

        /// <summary>
        /// Closes the window and releases all resources.
        /// </summary>
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        /// <summary>
        /// Clears the buffer in preparation for the next rendering. This method should be called at
        /// the beginning of the game's output phase.
        /// </summary>
        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.WHITE);
            Raylib.DrawTexture(_background, Constants.MAX_X/2 - _background.width/2, Constants.MAX_Y/2 - _background.height/2, Raylib_cs.Color.WHITE);
            if (_debug)
            {
                DrawGrid();
            }
        }

        /// <summary>
        /// Draws the given actor's text on the screen.
        /// </summary>
        /// <param name="actor">The actor to draw.</param>
        public void DrawActor(Actor actor)
        {
            string text = actor.GetText();
            int x = actor.GetPosition().GetX();
            int y = actor.GetPosition().GetY();
            int fontSize = actor.GetFontSize();
            Casting.Color c = actor.GetColor();
            Raylib_cs.Color color = ToRaylibColor(c);
            Raylib.DrawText(text, x, y, fontSize, color);
        }

        /// <summary>
        /// Draws the line to the fishhook.
        /// </summary>
        public void DrawLine(int startx, int starty, int endx, int endy)
        {
            Raylib.DrawLine(startx, starty, endx, endy, Raylib_cs.Color.WHITE);
        }

        /// <summary>
        /// Draws the given list of actors on the screen.
        /// </summary>
        /// <param name="actors">The list of actors to draw.</param>
        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                DrawActor(actor);
            }
        }
        
        /// <summary>
        /// Copies the buffer contents to the screen. This method should be called at the end of
        /// the game's output phase.
        /// </summary>
        public void FlushBuffer()
        {
            Raylib.EndDrawing();
        }

        /// <summary>
        /// Whether or not the window is still open.
        /// </summary>
        /// <returns>True if the window is open; false if otherwise.</returns>
        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        /// <summary>
        /// Opens a new window with the provided title and images.
        /// </summary>
        public void OpenWindow()
        {
            Raylib.InitAudioDevice();
            Raylib.InitWindow(Constants.MAX_X, Constants.MAX_Y, Constants.CAPTION);
            Raylib_cs.Image bgImage = Raylib.LoadImage("images/ocean.png");  
            _background = Raylib.LoadTextureFromImage(bgImage);
            Raylib.SetTargetFPS(Constants.FRAME_RATE);
            Raylib_cs.Sound song = Raylib.LoadSound("images/themesong.mp3");
            Raylib.PlaySound(song);
        }


        public void unloadImage()
        {

        }

        /// <summary>
        /// Draws a grid on the screen.
        /// </summary>
        private void DrawGrid()
        {
            for (int x = 0; x < Constants.MAX_X; x += Constants.CELL_SIZE)
            {
                Raylib.DrawLine(x, 0, x, Constants.MAX_Y, Raylib_cs.Color.GRAY);
            }
            for (int y = 0; y < Constants.MAX_Y; y += Constants.CELL_SIZE)
            {
                Raylib.DrawLine(0, y, Constants.MAX_X, y, Raylib_cs.Color.GRAY);
            }
        }

        /// <summary>
        /// Converts the given color to it's Raylib equivalent.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>A Raylib color.</returns>
        private Raylib_cs.Color ToRaylibColor(Casting.Color color)
        {
            int r = color.GetRed();
            int g = color.GetGreen();
            int b = color.GetBlue();
            int a = color.GetAlpha();
            return new Raylib_cs.Color(r, g, b, a);
        }
    }
}