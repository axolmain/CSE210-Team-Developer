using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool _isGameOver = false;
        private string _winning_message = "";
        private int _winner = 0;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            List<Actor> artifacts = cast.GetActors("artifacts");
            Actor hook = cast.GetFirstActor("hook");

            if (_isGameOver == false)
            {
                HandleFoodCollisions(cast);
                // HandleSegmentCollisions(cast);
                // HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleFoodCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            FishHook hook = (FishHook)cast.GetFirstActor("hook");
            FishHook hook2 = (FishHook)cast.GetActors("hook")[0];
            List<Actor> artifacts = cast.GetActors("artifacts");

            if (snake.GetHead().GetPosition().Equals(hook.GetPosition()))
            {
                Console.WriteLine("poop)");
            }

            foreach (Actor artifact in artifacts)
            {
                if (artifact.GetPosition().Equals(hook.GetPosition()))
                {
                    Console.WriteLine("true2");
                }
            }
            

            /// <summary>
            /// Sets the game over flag if the snake collides with one of its segments.
            /// </summary>
            /// <param name="cast">The cast of actors.</param>
            void HandleSegmentCollisions(Cast cast)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                Actor head = snake.GetHead();
                List<Actor> body = snake.GetBody();
                Snake snake2 = (Snake)cast.GetActors("snake")[1];
                Actor head2 = snake2.GetHead();
                List<Actor> body2 = snake2.GetBody();

                foreach (Actor segment in body)
                {
                    if (segment.GetPosition().Equals(head2.GetPosition()))
                    {
                        _isGameOver = true;
                        _winner = 1;

                    }
                }

                foreach (Actor segment2 in body2)
                {
                    if (segment2.GetPosition().Equals(head.GetPosition()))
                    {
                        _isGameOver = true;
                        _winner = 2;
                    }
                }
            }

            void HandleGameOver(Cast cast)
            {
                if (_isGameOver == true)
                {
                    Snake snake = (Snake)cast.GetFirstActor("snake");
                    Snake snake2 = (Snake)cast.GetActors("snake")[1];
                    Food food = (Food)cast.GetFirstActor("food");

                    // create a "game over" message
                    int x = Constants.MAX_X / 2;
                    int y = Constants.MAX_Y / 2;
                    Point position = new Point(x, y);

                    Actor message = new Actor();
                    message.SetText("Game Over!");
                    message.SetPosition(position);
                    cast.AddActor("messages", message);
                }

            }
        }
    }
}