using System;
using System.Collections.Generic;
using System.Linq;
using Unit05.Game.Services;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A fish hook.</para>
    /// </summary>
    // MouseService mouseservice = new MouseService();
    public class FishHook : Actor
    {
        private Image _image;
        private Actor _actor;
        private MouseService _mouse;
        private int _startingY = Constants.MAX_Y/2;
        private static Random _random = new Random();

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public FishHook(Actor actor, Image image, int _startingY)
        {
            this._actor = actor;
            this._image = image;
            this._startingY = 10;
        }
        
        /// <summary>
        /// Gets the actor.
        /// </summary>
        /// <returns>The actor.</returns>
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
        /// Moves the hook vertically based on the mouse input.
        /// </summary>
        public void FollowMouse()
        {
            Point velocity = _actor.GetVelocity();
            double rn = (_random.NextDouble() * (1.2 - 0.8) + 0.8);
            double vx = 50;
            double vy = velocity.GetY() * -1;
            Point newVelocity = new Point((int)vx, (int)vy);
            _actor.SetVelocity(newVelocity);
        }
    }
}
