namespace Unit05.Game.Casting{
    /// <summary>
    /// <para>The fish.</para>
    /// <para>
    /// The responsibility of a fish is to provide a message about itself.
    /// </para>
    /// </summary>
    public class Artifact : Actor
    {
        private int _value = 0;
        
        /// <summary>
        /// Constructs a new instance of Artifact.
        /// </summary>
        public Artifact()
        {
            _value = 0;
        }


        public int GetValue()
        {
            return _value;
        }
        /// <summary>
        /// Gets the artifact's message.
        /// </summary>
        /// <returns>The message as a string.</returns>
        public int GetMessage(){
            return _value;
        }
    }
}