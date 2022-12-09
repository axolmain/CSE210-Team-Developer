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
            if (_isGameOver == false)
            {
                // HandleFoodCollisions(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }
        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        // private void HandleFoodCollisions(Cast cast)
        // {
        //     Snake snake = (Snake)cast.GetFirstActor("snake");
        //     Score score = (Score)cast.GetFirstActor("score");
        //     Snake snake2 = (Snake)cast.GetActors("snake")[1];
        //     Score score2 = (Score)cast.GetFirstActor("score");
        //     Food food = (Food)cast.GetFirstActor("food");

        //     if (snake.GetHead().GetPosition().Equals(food.GetPosition()))
        //     {
        //         int points = food.GetPoints();
        //         snake.GrowTail(points);
        //         score.AddPoints(points);
        //         food.Reset();
        //     }

        //     if (snake2.GetHead().GetPosition().Equals(food.GetPosition()))
        //     {
        //         int points = food.GetPoints();
        //         snake2.GrowTail(points);
        //         score2.AddPoints2(points);
        //         food.Reset();
        //     }
        // // }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Actor hook = cast.GetFirstActor("hook");

            int yHook = hook.GetPosition().GetY();
            int xHook = hook.GetPosition().GetX();
            List<Actor> artifacts = cast.GetActors("artifacts");

            foreach (Actor actor in artifacts)
            {
                if ((actor.GetPosition().GetY().Equals(yHook)) && (actor.GetPosition().GetX().Equals(xHook)))
                {
                    _isGameOver = true;
                    _winner = 1;

                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (_isGameOver == true)
            {
                // Actor hook = cast.GetFirstActor("actor");
                // Food food = (Food)cast.GetFirstActor("food");
                List<Actor> artifacts = cast.GetActors("artifacts");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                if (_winner == 1)
                {
                    foreach (Actor actor in artifacts)
                    {
                        actor.SetColor(Constants.WHITE);
                        message.SetText("Fisherman Wins");
                        
                    }
                }
            }
        }

    }
}