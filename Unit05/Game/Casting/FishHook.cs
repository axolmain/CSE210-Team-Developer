using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Unit05.Game.Services;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A fish hook.</para>
    /// </summary>
    public class FishHook : Actor
    {
        private Image _image;
        private Actor _hook;
        private int _startingY = Constants.MAX_Y / 2;

        /// <summary>
        /// Constructs a new instance of Fishhook.
        /// </summary>
        public FishHook()
        {
            int x = 495;
            int y = _startingY;

            Point position = new Point(x, y);
            //Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
            string text = "J";
            Color color = Constants.WHITE;
            SetPosition(position);
            //SetVelocity(velocity);
            SetText(text);
            SetColor(color);
        }

        /// <summary>
        /// Gets the actor.
        /// </summary>
        /// <returns>The actor.</returns>

        public Actor GetActor()
        {
            return this;
        }


        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
        public Image GetImage()
        {
            return _image;
        }
    }
}
