namespace Elmah.Io.Apps.Manifest
{
    public class ButtonControl : IControl
    {
        public ButtonControl()
        {
            Type = ControlType.Button;
        }

        public ControlType Type { get; private set; }

        public string Text { get; set; }

        public string Url { get; set; }
    }
}