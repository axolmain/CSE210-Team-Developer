using System.Collections.Generic;
using Unit06.Game.Casting;


namespace Unit06.Game.Scripting
{
    // TODO: Implement the MoveActorsAction class here

    // 1) Add the class declaration. Use the allowing class comment. Make sure you
    //    inherit from the Action class.

    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of MoveActorsAction is to move all the actors.
    /// </para>
    /// </summary>
    public class MoveActorsAction : Action {

    
        int steps = 0;
        // 2) Create the class constructor. Use the following method comment.

        /// <summary>
        /// Constructs a new instance of MoveActorsAction.
        /// </summary>

        // 3) Override the Execute(Cast cast, Script script) method. Use the following 
        //    method comment. You custom implementation should do the following:
        //    a) get all the actors from the cast
        //    b) loop through all the actors
        //    c) call the MoveNext() method on each actor.
        public MoveActorsAction()
        {}
        public void Execute(Cast cast, Script script) {
            List<Actor> actors = cast.GetAllActors();
            foreach (Actor actor in actors)
            {
                actor.MoveNext();
                steps = steps + 1;
                
            }
            if (steps % 60 == 0) {
                foreach (Snake snake in cast.GetActors("snake") )
                {snake.GrowTail(1);}
                }
        }
    }

}