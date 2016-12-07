﻿using System.Collections.Generic;

namespace Elmah.Io.Apps.Manifest
{
    public class App
    {
        public App()
        {
            Variables = new List<IVariable>();
        }

        public List<IVariable> Variables { get; set; }
        public Rule Rule { get; set; }
    }
}