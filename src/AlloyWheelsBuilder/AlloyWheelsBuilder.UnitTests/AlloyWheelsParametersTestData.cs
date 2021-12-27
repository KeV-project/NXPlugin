using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlloyWheelsBuilderModel;

namespace AlloyWheelsBuilder.UnitTests
{
	public static class AlloyWheelsParametersTestData
	{
		public static AlloyWheelsParameter AlloyWheelsParameter =>
			new AlloyWheelsParameter(AlloyWheelsParameterName.Width,
				"Посадочная ширина Lп",
				AlloyWheelsParameterName.CentralHoleDiameter,
				"Диаметр ЦО ØDIA", (Dictionary<AlloyWheelsParameterName,
				double> parameterValues) => { return 0.0; },
				(Dictionary<AlloyWheelsParameterName,
				double> parameterValues) => { return 0.0; }, "мм");

		public static AlloyWheelsParameters AlloyWheelsParameters =>
			new AlloyWheelsParameters();
	}
}
