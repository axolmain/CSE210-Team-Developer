using System;
using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;
using Unit05.Game;



namespace Unit05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            cast.AddActor("hook",new FishHook());
            cast.AddActor("score", new Score());
            Random random = new Random();
            for (int i = 0; i < Constants.FISHIES; i++)
            {
                string text = "><{{{0>";

                int x = random.Next(1, Constants.COLUMNS);
                int y = random.Next(10, Constants.ROWS);
                Point position = new Point(x, y);
                position = position.Scale(Constants.CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText(text);
                artifact.SetFontSize(Constants.FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                cast.AddActor("artifacts", artifact);
            }

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);

           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}