using System;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the fish hook.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the hook up or down.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService _keyboardService;
        private Point _direction = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Connects the hook movement with input from the keyboard.
        /// <summary>
        public void Execute(Cast cast, Script script)
        {
            FishHook hook = (FishHook)cast.GetFirstActor("hook");

            if (_keyboardService.IsKeyDown("up") & hook.GetPosition().GetY() > 0) 
            {
                hook.SetVelocity(new Point (0, -1 * Constants.CELL_SIZE));
            }
            else if (_keyboardService.IsKeyDown("down") & hook.GetPosition().GetY() < Constants.MAX_Y-50)
            {
                hook.SetVelocity(new Point (0, +1 * Constants.CELL_SIZE));
            }
            else
            {
                hook.SetVelocity(new Point(0, 0));
            }
        }
    }
}