using System;

namespace AlloyWheelsBuilderModel
{
	public static class Сalculator
	{
		public static bool IsCirclesIntersect(double centerX, double centerY,
			double radius, double circlesRadius, int circlesCount)
		{
			// Длина окружности, на которой располагаются отверстия
			double circumference = 2 * Math.PI * radius;
			// Длина дуги окружности между соседними отверстиями 
			double arcLength = circumference / circlesCount;
			// Угол между соседними отверстиями в градусах
			double angle = 360 * arcLength / circumference;
			// Угол на окружности, на котором располагается левой отверстие в градусах
			double leftAngle = 90;
			// Угол на окружности, на котором располагается правое отверстие в градусах
			double rightAngle = leftAngle - angle;
			// Угол на окружности, на котором располагается левое отверстие в радианах
			leftAngle = leftAngle * Math.PI / 180;
			// Угол на окружности, на котором располагается вравое отверстие в радианах
			rightAngle = rightAngle * Math.PI / 180;
			// Координаты центра левого отверстия
			double x1 = centerX + radius * Math.Cos(leftAngle);
			double y1 = centerY + radius * Math.Sin(leftAngle);
			// Координаты центра правого отверстия
			double x2 = centerX + radius * Math.Cos(rightAngle);
			double y2 = centerY + radius * Math.Sin(rightAngle);
			// Расстояние между окружностями
			double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y1 - y2, 2));
			return circlesRadius - circlesRadius <= distance 
				&& distance <= circlesRadius + circlesRadius;
		}
	}
}
