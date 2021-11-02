using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;

namespace AlloyWheelsBuilderModel
{
    public class AlloyWheelsBuilder
    {
        private const string RADIUS_DIMENSION_NAME = "p4";

        private const string RADIUS_BOTTOM_ARC_NAME = "Curve Arc35";

        private const string RADIUS_TOP_ARC_NAME = "Curve Arc44";

        private const string WIDTH_DIMENSION_NAME = "p5";

        private const string WIDTH_LEFT_ARC_NAME = "Curve Arc3";

        private const string WIDTH_RIGHT_ARC_NAME = "Curve Arc16";

        private const string WHEELS_MATING_PLACE_ARC_NAME = "Curve Arc34";

        private Session _session;

        private Part _workPart;

        private AlloyWheelsData _alloyWheelsData;

        private void InitSketch()
        {

        }

        private void CreateSketch()
        {

        }

        private double SetVerticalLinearDimension(string dimensionName,
            Arc arc, Point point)
        {
            return 0.0;
        }

        private double SetVerticalLinearDimension(string dimensionName,
            Arc bottomArc, Arc topArc)
        {
            return 0.0;
        }

        private double SetHorizontalLinearDimension(string dimensionName,
            Arc arc, Point point)
        {
            return 0.0;
        }

        private double SetHorizontalLinearDimension(string dimensionName,
            Arc leftArc, Arc rightArc)
        {
            return 0.0;
        }

        private void ChangeLinearDimension(string dimensionName,
            double oldDimension, double newDimension, bool isNeededScaling)
        {

        }

        private void ChangeCentralHoleDiameter()
        {

        }

        private double GetCenterFullWidthX()
        {
            return 0.0;
        }

        private void ChangeOffset()
        {

        }

        private void CreateHole()
        {

        }

        private bool IsHolesIntersect()
		{
            return false;
		}

        private void CreateElemetsArray()
        {

        }

        private void CreatePetalSketch()
        {

        }

        private void Extrusion()
        {

        }

        public void Build()
		{
            _session = Session.GetSession();

            _workPart = _session.Parts.Work;
        }

        public AlloyWheelsBuilder(AlloyWheelsData alloyWheelsData)
		{
            _alloyWheelsData = alloyWheelsData;
        }
    }
}
