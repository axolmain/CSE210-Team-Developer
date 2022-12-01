using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// </summary>
    public class FishHook : Actor
    {
        private Image _image;
        private Actor _actor;
        private Mouse _mouse;
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
        /// Gets the mouse.
        /// <summary>
        public void GetMouse()
        {
            return _mouse;
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
