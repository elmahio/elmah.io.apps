using System;

namespace Elmah.Io.Apps.Manifest
{
    public abstract class VariableBase : IVariable
    {
        protected VariableBase(VariableType type)
        {
            Type = type;
        }

        public VariableType Type { get; private set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Required { get; set; }
    }
}