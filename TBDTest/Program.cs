namespace TBDTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the App.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize App configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}