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
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            List<Actor> segments = snake.GetSegments();
            Snake snake2 = (Snake)cast.GetActors("snake")[1];
            List<Actor> segments2 = snake2.GetSegments();
            Actor score = cast.GetFirstActor("score");
            Actor food = cast.GetFirstActor("food");
            List<Actor> messages = cast.GetActors("messages");
            Actor hook = cast.GetFirstActor("hook");
            List<Actor> artifacts = cast.GetActors("artifacts");
            int y = hook.GetPosition().GetY();
            
            _videoService.ClearBuffer();
            _videoService.DrawActors(segments);
            _videoService.DrawActors(segments2);
            _videoService.DrawActor(score);
            _videoService.DrawActor(food);
            _videoService.DrawActors(messages);
            _videoService.DrawActor(hook);
            _videoService.DrawLine(500, 0, 500, y);
            _videoService.DrawActors(artifacts);

            _videoService.FlushBuffer();
            
        }
    }
}