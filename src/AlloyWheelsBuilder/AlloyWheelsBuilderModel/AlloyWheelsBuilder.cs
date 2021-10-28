using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;

namespace AlloyWheelsBuilderModel
{
    public static class AlloyWheelsBuilder
    {
        private const string RADIUS_DIMENSION_NAME = "p4";

        private const string RADIUS_BOTTOM_ARC_NAME = "Curve Arc35";

        private const string RADIUS_TOP_ARC_NAME = "Curve Arc44";

        private const string WIDTH_DIMENSION_NAME = "p5";

        private const string WIDTH_LEFT_ARC_NAME = "Curve Arc3";

        private const string WIDTH_RIGHT_ARC_NAME = "Curve Arc16";

        private const string WHEELS_MATING_PLACE_ARC_NAME = "Curve Arc34";

        private static Session _session;

        private static Part _workPart;

        private static AlloyWheelsData _alloyWheelsData;

        private static void InitSketch()
        {

        }

        private static void CreateSketch()
        {

        }

        private static double SetVerticalLinearDimension(string dimensionName,
            Arc arc, Point point)
        {
            return 0.0;
        }

        private static double SetVerticalLinearDimension(string dimensionName,
            Arc bottomArc, Arc topArc)
        {
            return 0.0;
        }

        private static double SetHorizontalLinearDimension(string dimensionName,
            Arc arc, Point point)
        {
            return 0.0;
        }

        private static double SetHorizontalLinearDimension(string dimensionName,
            Arc leftArc, Arc rightArc)
        {
            return 0.0;
        }

        private static void ChangeLinearDimension(string dimensionName,
            double oldDimension, double newDimension, bool isNeededScaling)
        {

        }

        private static void ChangeCentralHoleDiameter()
        {

        }

        private static double GetCenterFullWidthX()
        {
            return 0.0;
        }

        private static void ChangeOffset()
        {

        }

        private static void CreateHole()
        {

        }

        private static bool IsHolesIntersect()
		{
            return false;
		}

        private static void CreateElemetsArray()
        {

        }

        private static void CreatePetalSketch()
        {

        }

        private static void Extrusion()
        {

        }

        public static void Build(AlloyWheelsData alloyWheelsData)
		{
            _session = Session.GetSession();

            _workPart = _session.Parts.Work;

            _alloyWheelsData = alloyWheelsData;
        }
    }
}
