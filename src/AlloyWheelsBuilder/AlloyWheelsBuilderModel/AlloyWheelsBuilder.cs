using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using NXOpen.Annotations;

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


        private AlloyWheelsData _alloyWheelsData;

        private void InitSketch(Session session, Part workPart)
        {
            Sketch nullNxOpenSketch = null;
            SketchInPlaceBuilder sketchInPlaceBuilder = workPart.Sketches.
                CreateSketchInPlaceBuilder2(nullNxOpenSketch);

            Point3d origin = new Point3d(0.0, 0.0, 0.0);
            Vector3d normal = new Vector3d(0.0, 0.0, 1.0);
            Plane plane = workPart.Planes.CreatePlane(origin, normal, 
                SmartObject.UpdateOption.WithinModeling);
            sketchInPlaceBuilder.PlaneReference = plane;

            SketchAlongPathBuilder sketchAlongPathBuilder = workPart.Sketches.
                CreateSketchAlongPathBuilder(nullNxOpenSketch);

            NXObject nXObject = sketchInPlaceBuilder.Commit();

            Sketch sketch = (Sketch)nXObject;
            sketch.Activate(Sketch.ViewReorient.True);

            sketchInPlaceBuilder.Destroy();
            sketchAlongPathBuilder.Destroy();
            plane.DestroyPlane();

            string sketchName = "SKETCH_000";
            session.ActiveSketch.SetName(sketchName);
        }

        private void CreateSketch(Session session, Part workPart)
        {
            foreach (ArcData arcData in _alloyWheelsData.SketchArcs)
            {
                Arc arc = workPart.Curves.CreateArc(arcData.StartPoint, 
                    arcData.PointOn, arcData.EndPoint, 
                    false, out bool value);
                session.ActiveSketch.AddGeometry(arc,
                    Sketch.InferConstraintsOption.InferNoConstraints);
            }
        }

        private void FinishSketch(Session session)
		{
            session.ActiveSketch.Update();

            session.ActiveSketch.Deactivate(Sketch.ViewReorient.True,
                Sketch.UpdateLevel.Model);
        }

        private double SetVerticalLinearDimension(string dimensionName,
            Arc arc, Point point)
        {
            return 0.0;
        }

        private double SetVerticalLinearDimension(Part workPart, 
            string dimensionName, Arc bottomArc, Arc topArc)
        {
           Dimension nullNxOpenAnnotationsDimension = null;
            SketchLinearDimensionBuilder sketchLinearDimensionBuilder =
                workPart.Sketches.CreateLinearDimensionBuilder(
                nullNxOpenAnnotationsDimension);

            sketchLinearDimensionBuilder.Driving.ExpressionName = dimensionName;

            Direction nullNxOpenDirection = null;
            sketchLinearDimensionBuilder.Measurement.Direction = nullNxOpenDirection;

            View nullNxOpenView = null;
            sketchLinearDimensionBuilder.Measurement.DirectionView = nullNxOpenView;

            Point3d startPoint = new Point3d(0.0, 0.0, 0.0);

            Point3d bottomPoint = new Point3d(bottomArc.CenterPoint.X + bottomArc.Radius
                * Math.Cos(bottomArc.StartAngle), bottomArc.CenterPoint.Y + bottomArc.Radius
                * Math.Sin(bottomArc.StartAngle), 0.0);
            sketchLinearDimensionBuilder.FirstAssociativity.SetValue(
                InferSnapType.SnapType.Start, bottomArc,
                workPart.ModelingViews.WorkView, bottomPoint, null,
                nullNxOpenView, startPoint);

            Point3d topPoint = new Point3d(topArc.CenterPoint.X + topArc.Radius
                * Math.Cos(topArc.EndAngle), topArc.CenterPoint.Y + topArc.Radius
                * Math.Sin(topArc.EndAngle), 0.0);
            sketchLinearDimensionBuilder.SecondAssociativity.SetValue(
                InferSnapType.SnapType.End, topArc, workPart.ModelingViews.WorkView,
                topPoint, null, nullNxOpenView, startPoint);

            sketchLinearDimensionBuilder.Origin.SetInferRelativeToGeometry(true);

            Point3d point3 = new Point3d(-16.425305624190489, 3.4224712283621521, 0.0);
            sketchLinearDimensionBuilder.Origin.Origin.SetValue(null, nullNxOpenView, point3);

            sketchLinearDimensionBuilder.Commit();

            sketchLinearDimensionBuilder.Destroy();

            return topPoint.Y - bottomPoint.Y;
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

        private void ChangeLinearDimension(Session session, Part workPart, 
            string dimensionName, double oldDimension, 
            double newDimension, bool isNeededScaling)
        {
            Dimension nullNxOpenAnnotationsDimension = null;
            SketchLinearDimensionBuilder sketchLinearDimensionBuilder =
                workPart.Sketches.CreateLinearDimensionBuilder(
                nullNxOpenAnnotationsDimension);

            sketchLinearDimensionBuilder.Driving.ExpressionName = 
                dimensionName;

            Direction nullNxOpenDirection = null;
            sketchLinearDimensionBuilder.Measurement.Direction = 
                nullNxOpenDirection;

            View nullNxOpenView = null;
            sketchLinearDimensionBuilder.Measurement.DirectionView = 
                nullNxOpenView;

            Expression expression = workPart.Expressions.FindObject(
                dimensionName);
            expression.RightHandSide = newDimension.ToString().
                Replace(',', '.');

            if (isNeededScaling)
            {
                session.ActiveSketch.Scale(newDimension / oldDimension);
            }

            session.ActiveSketch.LocalUpdate();

            sketchLinearDimensionBuilder.Destroy();
        }

        private void ChangeDiameter(Session session, Part workPart)
		{
            double radius = SetVerticalLinearDimension(workPart, 
                RADIUS_DIMENSION_NAME,
                (Arc)session.ActiveSketch.FindObject(RADIUS_BOTTOM_ARC_NAME),
                (Arc)session.ActiveSketch.FindObject(RADIUS_TOP_ARC_NAME));
            double newRadius = _alloyWheelsData.Diameter / 2;

            ChangeLinearDimension(session, workPart, RADIUS_DIMENSION_NAME, 
                radius, newRadius - _alloyWheelsData.CentralHoleDiameter / 2, 
                true);
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
            Session session = Session.GetSession();
            Part workPart = session.Parts.Work;

            InitSketch(session, workPart);
            CreateSketch(session, workPart);
            ChangeDiameter(session, workPart);
            FinishSketch(session);
        }

        public AlloyWheelsBuilder(AlloyWheelsData alloyWheelsData)
		{
            _alloyWheelsData = alloyWheelsData;
        }
    }
}
