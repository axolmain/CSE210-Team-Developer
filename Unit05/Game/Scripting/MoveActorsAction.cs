using System;
using System.Collections.Generic;
using Unit05.Game.Casting;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of MoveActorsAction is to move all the actors.
    /// </para>
    /// </summary>
    public class MoveActorsAction : Action {

    
        int steps = 0;

        /// <summary>
        /// Constructs a new instance of MoveActorsAction.
        /// </summary>
        public MoveActorsAction()
        {}
        public void Execute(Cast cast, Script script) {
            FishHook hook = (FishHook)cast.GetFirstActor("hook");
            hook.MoveNext();
            List<Actor> artifacts = cast.GetActors("artifacts");
            foreach (Artifact actor in artifacts)
            {
                Point direction = new Point(1, 0);
                direction = direction.Scale(5);
                actor.SetVelocity(direction);
                actor.MoveNext();
            
                Random random = new Random();
            }
        }
    }
}