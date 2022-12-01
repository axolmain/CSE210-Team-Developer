using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Boot is to move itself.</para>
    /// </summary>
    public class Boot : Actor
    {
        private List<Actor> _segments = new List<Actor>();
        private Color _colorH = Constants.YELLOW;
        private Color _colorB = Constants.GREEN;
        private int _startingY = Constants.MAX_Y/2;

        /// <summary>
        /// Constructs a new instance of a boot.
        /// </summary>
        public Boot()
        {
            PrepareBody();
        }
        public Boot(Color colorHe, Color colorBo,  int yStart)
        {
            _colorH = colorHe;
            _colorB = colorBo;
            _startingY = yStart;
            PrepareBody();
        }

        /// <summary>
        /// Gets the boot's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(_segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the boot's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return _segments[0];
        }

        /// <summary>
        /// Gets the boot's segments (including the head).
        /// </summary>
        /// <returns>A list of boot segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return _segments;
        }

        /// <summary>
        /// Grows the boot's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = _segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(_colorB);
                _segments.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in _segments)
            {
                segment.MoveNext();
            }

            for (int i = _segments.Count - 1; i > 0; i--)
            {
                Actor trailing = _segments[i];
                Actor previous = _segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }
        }

        /// <summary>
        /// Turns the head of the boot in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            _segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the boot body for moving.
        /// </summary>
        private void PrepareBody()
        {
            int x = Constants.CELL_SIZE * (Constants.SNAKE_LENGTH-1);
            int y = _startingY;

                Point position = new Point(x, y);
                Point velocity = new Point(0, 0);


            // for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            // {

            //     string text = i == 0 ? "8" : "#";
            //     Color color = i == 0 ? _colorH : _colorB;

            //     Actor segment = new Actor();
            //     segment.SetPosition(position);
            //     segment.SetVelocity(velocity);
            //     segment.SetText(text);
            //     segment.SetColor(color);
            //     _segments.Add(segment);
            // }
        }
    }
}