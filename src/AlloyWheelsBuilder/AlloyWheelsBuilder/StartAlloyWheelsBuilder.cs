using NXOpen;

namespace AlloyWheelsBuilderView
{
    /// <summary>
    /// Класс <see cref="StartAlloyWheelsBuilder"/> предназначен для 
    /// выполнения запуска окна для ввода параметров модели
    /// </summary>
    public class StartAlloyWheelsBuilder
    {
        /// <summary>
        /// Вызывает окно для ввода параметров модели
        /// </summary>
        /// <param name="args">Внешние параметры</param>
        public static void Main(string[] args)
        {
            AlloyWheelsBuilderWindow mainWindow = new AlloyWheelsBuilderWindow();
            mainWindow.ShowDialog();
        }

        /// <summary>
        /// Завершает процесс NX
        /// </summary>
        public static int GetUnloadOption(string dummy)
        {
            return (int)Session.LibraryUnloadOption.Immediately;
        }
    }
}
