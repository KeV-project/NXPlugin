using NXOpen;

namespace AlloyWheelsBuilderModel
{
	/// <summary>
	/// Класс <see cref="ArcData"/> предназначен для хранения 
	/// данных для построения дуги
	/// </summary>
	public class ArcData
	{
		/// <summary>
		/// Устанавливает и возвращает значение начальной точки дуги
		/// </summary>
		public Point3d StartPoint { get; set; }

		/// <summary>
		/// Устанавливает и возвращает значение центральной точки дуги
		/// </summary>
		public Point3d PointOn { get; set; }

		/// <summary>
		/// Устанавливает и возвращает значение конечной точки дуги
		/// </summary>
		public Point3d EndPoint { get; set; }

		/// <summary>
		/// Инициализирует объект класса <see cref="ArcData"/>
		/// </summary>
		/// <param name="startPoint">Начальная точка дуги</param>
		/// <param name="pointOn">Точка, лежащая на дуге</param>
		/// <param name="endPoint">Конечная точка дуги</param>
		public ArcData(Point3d startPoint, Point3d pointOn, Point3d endPoint)
		{
			StartPoint = startPoint;
			PointOn = pointOn;
			EndPoint = endPoint;
		}
	}
}
