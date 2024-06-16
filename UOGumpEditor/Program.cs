namespace UOGumpEditor
{
    internal static class Program
    {
        internal static SessionEntity Session { get; private set; } = new SessionEntity(new UOGumpEditorUI());

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(Session.MainUI);
        }
    }
}