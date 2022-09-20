namespace CustomComponent.Models
{
    public class ApplicationState
    {
        private ApplicationState()
        {
            LabelMessage = new LabelM() { MText = "", MColor = Colors.Transparent };
        }
        public LabelM LabelMessage { get; set; }
        private static ApplicationState instance;
        public static ApplicationState GetInstance()
        {
            if (instance == null)
            {
                instance = new ApplicationState();
            }
            return instance;
        }
    }
}
