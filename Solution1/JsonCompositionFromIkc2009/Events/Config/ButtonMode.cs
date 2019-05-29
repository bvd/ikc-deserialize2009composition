namespace JsonCompositionFromIkc2009.Events.Config
{
    public enum ButtonMode
    {
        None,
        Button,
        Toggle,
        Img
    }

    public class ButtonModeTransformer
    {
        public static ButtonMode Transform(string value)
        {
            switch (value)
            {
                case "button":
                    return ButtonMode.Button;

                case "img":
                    return ButtonMode.Img;

                case "toggle":
                    return ButtonMode.Toggle;

                default:
                    return ButtonMode.None;
            }
        }
    }
}
