namespace UOGumpEditor
{
    internal static class Program
    {
        private static readonly SessionEntity _Session = new(new UOGumpEditorUI());

        internal static SessionEntity Session { get { return _Session; } }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(Session.MainUI);
        }
    }
}