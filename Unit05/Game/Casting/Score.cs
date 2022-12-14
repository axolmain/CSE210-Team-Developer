using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        public int _points = 0;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Score()
        {          
            AddScore(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddScore(int points)
        {
            this._points += points;
            SetText($"Score: {this._points}");
            SetColor(Constants.RED);
            SetFontSize(50);
            Point position = new Point(15, 15);
            SetPosition(position);
        }

    }
}