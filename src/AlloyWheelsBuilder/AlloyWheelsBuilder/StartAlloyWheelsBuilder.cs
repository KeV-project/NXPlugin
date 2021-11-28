using NXOpen;

namespace AlloyWheelsBuilder
{
    public class StartAlloyWheelsBuilder
    {
        public static void Main(string[] args)
        {
            AlloyWheelsBuilderWindow mainWindow = new AlloyWheelsBuilderWindow();
            mainWindow.ShowDialog();
        }

        public static int GetUnloadOption(string dummy)
        {
            return (int)Session.LibraryUnloadOption.Immediately;
        }
    }
}
