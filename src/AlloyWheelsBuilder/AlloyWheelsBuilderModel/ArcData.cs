using NXOpen;

namespace AlloyWheelsBuilderModel
{
	public class ArcData
	{
		public Point3d StartPoint { get; set; }

		public Point3d PointOn { get; set; }

		public Point3d EndPoint { get; set; }

		public ArcData(Point3d startPoint, Point3d pointOn, Point3d endPoint)
		{
			StartPoint = startPoint;
			PointOn = pointOn;
			EndPoint = endPoint;
		}
	}
}
