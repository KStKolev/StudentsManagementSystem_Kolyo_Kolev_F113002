namespace StudentsManagementSystem_Kolyo_Kolev_F113002
{
    internal static class Program
    {
        // The main entry point for the application.
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new StudentsSystem());
        }
    }
}