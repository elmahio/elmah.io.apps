namespace Elmah.Io.Apps.Manifest
{
    public class Variable
    {
        public Variable()
        {
            Type = VariableType.Text;
        }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Example { get; set; }

        public string Description { get; set; }

        public VariableType Type { get; set; }

        /// <summary>
        /// To limit the possible values of this variable, add one or more values to the Values property.
        /// The type of objects added to the Values property needs to be the same as the Type of the variable.
        /// If user are allowed to input anything within the bounds of the type, leave the Values property null or empty.
        /// </summary>
        public object[] Values { get; set; }

        public bool Required { get; set; }
    }
}