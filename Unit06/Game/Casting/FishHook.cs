using System;
using System.Collections.Generic;


namespace Unit06.Game.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class FishHook : Actor
    {
        private static Random _random = new Random();

        private Actor _actor;
        private Image _image;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public FishHook(Actor actor, Image image, bool debug = false) : base(debug)
        {
            this._actor = actor;
            this._image = image;
        }

        /// <summary>
        /// Moves the hook vertically.
        /// </summary>
        public void MoveY()
        {
            Point velocity = _actor.GetVelocity();
            double rn = (_random.NextDouble() * (1.2 - 0.8) + 0.8);
            double vx = 50;
            double vy = velocity.GetY() * -1;
            Point newVelocity = new Point((int)vx, (int)vy);
            _actor.SetVelocity(newVelocity);
        }
        
        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Actor GetActor()
        {
            return _actor;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
        public Image GetImage()
        {
            return _image;
        }

        /// <summary>
        /// Gets the mouse

        /// <summary>
        /// Releases ball in random horizontal direction.
        /// </summary>
        public void Release()
        {
            Point velocity = _actor.GetVelocity();
            List<int> velocities = new List<int> {Constants.BALL_VELOCITY, Constants.BALL_VELOCITY};
            int index = _random.Next(velocities.Count);
            double vx = velocities[index];
            double vy = -Constants.BALL_VELOCITY;
            Point newVelocity = new Point((int)vx, (int)vy);
            _actor.SetVelocity(newVelocity);
        }
    }
}