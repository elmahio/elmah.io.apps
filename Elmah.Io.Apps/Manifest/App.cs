using System.Collections.Generic;

namespace Elmah.Io.Apps.Manifest
{
    public class App
    {
        public App()
        {
            Variables = new List<Variable>();
        }

        public List<Variable> Variables { get; set; }
        public Rule Rule { get; set; }
    }
}