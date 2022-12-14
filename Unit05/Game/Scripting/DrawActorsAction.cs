using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given Videoservice.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Adds each actor to the cast then draws the actors.
        /// <summary>
        public void Execute(Cast cast, Script script)
        {
            Actor score = cast.GetFirstActor("score");
            Actor hook = cast.GetFirstActor("hook");
            List<Actor> artifacts = cast.GetActors("artifacts");
            int y = hook.GetPosition().GetY();

            _videoService.ClearBuffer();
            _videoService.DrawActor(score);
            _videoService.DrawActor(hook);
            _videoService.DrawLine(500, 0, 500, y);
            
            _videoService.DrawActors(artifacts);
            _videoService.FlushBuffer();
            
        }
    }
}