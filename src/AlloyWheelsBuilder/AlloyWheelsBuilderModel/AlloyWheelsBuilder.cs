using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using NXOpen.Annotations;
using NXOpen.Features;
using NXOpen.GeometricUtilities;

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

        private const string OFFSET_RIGHT_ARC_NAME = "Curve Arc32";

        private const string OFFSET_LEFT_ARC_NAME = "Curve Arc39";

        private const string SKETCH_FEATURE_NAME = "SKETCH(1)";

        private const string SKETCH_NAME = "SKETCH_000";

        private const string REVOLVED_NAME = "REVOLVED(2)";

        private const string HOLE_ARC_NAME = "Curve Arc37";

        private const string HOLE_NAME = "SIMPLE HOLE(3)";

        private const string LAST_ARC_NAME = "Curve Arc45";

        private AlloyWheelsData _alloyWheelsData;

        private Sketch InitSketch(Session session, Part workPart)
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

            return sketch;
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

        private double SetHorizontalLinearDimension(Part workPart, 
            string dimensionName, Arc leftArc, Arc rightArc)
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

            Point3d startPoint = new Point3d(0.0, 0.0, 0.0);

            Point3d leftPoint = new Point3d(leftArc.CenterPoint.X + leftArc.Radius
                * Math.Cos(leftArc.StartAngle), leftArc.CenterPoint.Y + leftArc.Radius
                * Math.Sin(leftArc.StartAngle), 0.0);
            sketchLinearDimensionBuilder.FirstAssociativity.SetValue(
                InferSnapType.SnapType.Start, leftArc,
                workPart.ModelingViews.WorkView, leftPoint, null,
                nullNxOpenView, startPoint);

            Point3d rightPoint = new Point3d(rightArc.CenterPoint.X + rightArc.Radius
                * Math.Cos(rightArc.StartAngle), rightArc.CenterPoint.Y + rightArc.Radius
                * Math.Sin(rightArc.StartAngle), 0.0);
            sketchLinearDimensionBuilder.SecondAssociativity.SetValue(
                InferSnapType.SnapType.End, rightArc, workPart.ModelingViews.WorkView,
                rightPoint, null, nullNxOpenView, startPoint);

            sketchLinearDimensionBuilder.Origin.SetInferRelativeToGeometry(true);

            sketchLinearDimensionBuilder.Commit();

            sketchLinearDimensionBuilder.Destroy();

            return rightPoint.X - leftPoint.X;
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
            double radius = SetVerticalLinearDimension(
                workPart, RADIUS_DIMENSION_NAME,
                (Arc)session.ActiveSketch.FindObject(RADIUS_BOTTOM_ARC_NAME),
                (Arc)session.ActiveSketch.FindObject(RADIUS_TOP_ARC_NAME));
            double newRadius = _alloyWheelsData.Diameter / 2;

            ChangeLinearDimension(session, workPart, RADIUS_DIMENSION_NAME, 
                radius, newRadius - _alloyWheelsData.CentralHoleDiameter / 2, 
                true);
        }

        private void ChangeWidth(Session session, Part workPart)
		{
            double width = SetHorizontalLinearDimension(
                workPart, WIDTH_DIMENSION_NAME,
                (Arc)session.ActiveSketch.FindObject(WIDTH_LEFT_ARC_NAME),
                (Arc)session.ActiveSketch.FindObject(WIDTH_RIGHT_ARC_NAME));
            ChangeLinearDimension(session, workPart, WIDTH_DIMENSION_NAME, 
                width, _alloyWheelsData.Width, false);
        }

        private void ChangeCentralHoleDiameter(Session session)
        {
            for (int i = 1; i <= _alloyWheelsData.SketchArcsCount; i++)
            {
                Arc arc = (Arc)session.ActiveSketch.FindObject(
                    "Curve Arc" + i);
                arc.SetParameters(arc.Radius, new Point3d(
                    arc.CenterPoint.X, arc.CenterPoint.Y 
                    + _alloyWheelsData.CentralHoleDiameter / 2, 
                    arc.CenterPoint.Z), arc.StartAngle, arc.EndAngle);

                const int geomsCount = 1;
                SmartObject[] geoms = new SmartObject[geomsCount];
                geoms[0] = arc;
                session.ActiveSketch.UpdateGeometryDisplay(geoms);
            }
        }

        private void MovePointOnArc(Session session, Part workPart, 
            string arcName, double dx)
		{
            Arc arc = (Arc)session.ActiveSketch.FindObject(arcName);
            AssociativeArcBuilder associativeArcBuilder = workPart.
                BaseFeatures.CreateAssociativeArcBuilder(arc);

            Unit unit = associativeArcBuilder.Radius.Units;

            Expression xExpression = workPart.Expressions.
                CreateSystemExpressionWithUnits((arc.CenterPoint.X 
                + arc.Radius * Math.Cos(arc.EndAngle)).ToString().
                Replace(',', '.'), unit);
            Expression yExpression = workPart.Expressions.
                CreateSystemExpressionWithUnits((arc.CenterPoint.Y 
                + arc.Radius * Math.Sin(arc.EndAngle)).ToString().
                Replace(',', '.'), unit);
            Expression zExpression = workPart.Expressions.
                CreateSystemExpressionWithUnits("0", unit);

            xExpression.RightHandSide = (arc.CenterPoint.X + arc.Radius 
                * Math.Cos(arc.EndAngle) + dx).ToString().Replace(',', '.');
            Scalar xScalar = workPart.Scalars.CreateScalarExpression(
                xExpression, Scalar.DimensionalityType.Length, 
                SmartObject.UpdateOption.WithinModeling);

            yExpression.RightHandSide = (arc.CenterPoint.Y + arc.Radius 
                * Math.Sin(arc.EndAngle)).ToString().Replace(',', '.');
            Scalar yScalar = workPart.Scalars.CreateScalarExpression(
                yExpression, Scalar.DimensionalityType.Length, 
                SmartObject.UpdateOption.WithinModeling);

            zExpression.RightHandSide = "0";
            Scalar zScalar = workPart.Scalars.CreateScalarExpression(
                zExpression, Scalar.DimensionalityType.Length, 
                SmartObject.UpdateOption.WithinModeling);

            Point3d origin = new Point3d(0.0, 0.0, 0.0);
            Vector3d xDirection = new Vector3d(1.0, 0.0, 0.0);
            Vector3d yDirection = new Vector3d(0.0, 1.0, 0.0);
            Xform xform = workPart.Xforms.CreateXform(origin, xDirection,
                yDirection, SmartObject.UpdateOption.WithinModeling, 1.0);

            CartesianCoordinateSystem cartesianCoordinateSystem = 
                workPart.CoordinateSystems.CreateCoordinateSystem(
                    xform, SmartObject.UpdateOption.WithinModeling);

            Point point = workPart.Points.CreatePoint(
                cartesianCoordinateSystem, xScalar, yScalar, zScalar, 
                SmartObject.UpdateOption.WithinModeling);

            associativeArcBuilder.EndPoint.Value = point;

            associativeArcBuilder.Commit();

            associativeArcBuilder.Destroy();

            session.ActiveSketch.Preferences.ContinuousAutoDimensioningSetting = false;

            session.ActiveSketch.Update();

            session.ActiveSketch.Preferences.ContinuousAutoDimensioningSetting = true;

            session.ActiveSketch.RunAutoDimension();
        }

        private void ChangeOffset(Session session, Part workPart)
        {
            // Находим X середины ширины диска
            Arc leftArc = (Arc)session.ActiveSketch.FindObject(
                WIDTH_LEFT_ARC_NAME);
            Arc rightArc = (Arc)session.ActiveSketch.FindObject(
                WIDTH_RIGHT_ARC_NAME);

            double leftX = leftArc.CenterPoint.X + leftArc.Radius
                * Math.Cos(leftArc.StartAngle);
            double rightX = rightArc.CenterPoint.X + rightArc.Radius
                * Math.Cos(rightArc.StartAngle);

            double centerX = leftX + ((rightX - leftX) / 2);

            //TODO: тут надо считать от центра дуги 
            Arc wheelsMatingPlaceArc = ((Arc)session.ActiveSketch.FindObject(
                WHEELS_MATING_PLACE_ARC_NAME));

            double dx = 0.0;
            if(_alloyWheelsData.OffSet < 0)
			{
                // одинаковый случай
                dx = centerX - (wheelsMatingPlaceArc.CenterPoint.X 
                    + wheelsMatingPlaceArc.Radius 
                    * Math.Cos(wheelsMatingPlaceArc.StartAngle)) 
                    - _alloyWheelsData.OffSet;
            }
            else if(_alloyWheelsData.OffSet > 0)
			{
                if(centerX - (wheelsMatingPlaceArc.CenterPoint.X
                    + wheelsMatingPlaceArc.Radius
                    * Math.Cos(wheelsMatingPlaceArc.StartAngle)) <
                    centerX - _alloyWheelsData.OffSet)
				{
                    dx = -1 * (_alloyWheelsData.OffSet - 
                        (centerX - (wheelsMatingPlaceArc.CenterPoint.X
                        + wheelsMatingPlaceArc.Radius
                        * Math.Cos(wheelsMatingPlaceArc.StartAngle))));
				}
                else if(centerX - (wheelsMatingPlaceArc.CenterPoint.X
                    + wheelsMatingPlaceArc.Radius
                    * Math.Cos(wheelsMatingPlaceArc.StartAngle)) >
                    centerX - _alloyWheelsData.OffSet)
				{
                    // Одинаковый случай
                    dx = centerX - _alloyWheelsData.OffSet - 
                        (wheelsMatingPlaceArc.CenterPoint.X
                        + wheelsMatingPlaceArc.Radius
                        * Math.Cos(wheelsMatingPlaceArc.StartAngle));
				}
			}
            else
			{
                dx = centerX - (wheelsMatingPlaceArc.CenterPoint.X
                    + wheelsMatingPlaceArc.Radius
                    * Math.Cos(wheelsMatingPlaceArc.StartAngle));
            }

            for (int i = 33; i <= 38; i++)
            {
                Arc arc = (Arc)session.ActiveSketch.FindObject(
                    "Curve Arc" + i);
                arc.SetParameters(arc.Radius, new Point3d(arc.CenterPoint.X 
                    + dx, arc.CenterPoint.Y, arc.CenterPoint.Z),
                    arc.StartAngle, arc.EndAngle);
            }

            MovePointOnArc(session, workPart, OFFSET_RIGHT_ARC_NAME, dx);
            MovePointOnArc(session, workPart, OFFSET_LEFT_ARC_NAME, dx);
        }

        private void Revolve(Part workPart, Sketch sketch, Section section, 
            string sketchName, string revolveArcName, Point3d helpPoint, 
            Direction direction)
		{
            Feature nullNxOpenFeaturesFeature = null;
            RevolveBuilder revolveBuilder = workPart.Features.
                CreateRevolveBuilder(nullNxOpenFeaturesFeature);

            revolveBuilder.Limits.StartExtend.Value.RightHandSide = "0";
            revolveBuilder.Limits.EndExtend.Value.RightHandSide = "360";

            // Определение объекта(секции) вращения
            revolveBuilder.Section = section;
            const int featuresCount = 1;
            Feature[] features = new Feature[featuresCount];
            SketchFeature sketchFeature = (SketchFeature)workPart.Features.
                FindObject(sketchName);
            features[0] = sketchFeature;
            CurveFeatureRule curveFeatureRule = workPart.ScRuleFactory.
                CreateRuleCurveFeature(features);
            section.AllowSelfIntersection(false);
            const int selectionIntentRuleCount = 1;
            SelectionIntentRule[] rules = new SelectionIntentRule[
                selectionIntentRuleCount];
            rules[0] = curveFeatureRule;
            Arc arc = (Arc)sketch.FindObject(revolveArcName);
            NXObject nullNxOpenNxObject = null;
            section.AddToSection(rules, arc, nullNxOpenNxObject,
                nullNxOpenNxObject, helpPoint, Section.Mode.Create, false);

            // Создание оси вращнеия 
            Point nullNxOpenPoint = null;
            Axis axis = workPart.Axes.CreateAxis(nullNxOpenPoint,
                direction, SmartObject.UpdateOption.WithinModeling);
            revolveBuilder.Axis = axis;

            // Врещение
            revolveBuilder.CommitFeature();

            revolveBuilder.Destroy();
        }

        private void RevolveSketch(Part workPart, Sketch sketch)
		{
            const double sectionX = 0.0094999999999999998;
            const double sectionY = 0.01;
            const double sectionZ = 0.5;
            Section section = workPart.Sections.CreateSection(
                sectionX, sectionY, sectionZ);

            const double helpX = 18.064839800768446;
            const double helpY = 24.907312265123721;
            const double helpZ = 0.0;
            Point3d helpPoint = new Point3d(helpX, helpY, helpZ);

            Point3d origin = new Point3d(0.0, 0.0, 0.0);
            Vector3d vector = new Vector3d(1.0, 0.0, 0.0);
            Direction direction = workPart.Directions.CreateDirection(
                origin, vector, SmartObject.UpdateOption.WithinModeling);

            Revolve(workPart, sketch, section, SKETCH_FEATURE_NAME, 
                OFFSET_RIGHT_ARC_NAME, helpPoint, direction);
		}

        private void CreateHole(Part workPart, string bodyName, 
            string sketchFeatureName, string sketchName, string holeArcName, 
            double scalarValue, double holeDiameter)
        {
            HolePackage nullNxOpenFeaturesHolePackage = null;
            HolePackageBuilder holePackageBuilder = workPart.Features.
                CreateHolePackageBuilder(nullNxOpenFeaturesHolePackage);

            holePackageBuilder.Tolerance = 0.01;

            const int targetBodiesCount = 1;
            Body[] targetBodies = new Body[targetBodiesCount];
            Body body = workPart.Bodies.FindObject(bodyName);
            targetBodies[0] = body;
            holePackageBuilder.BooleanOperation.SetTargetBodies(
                targetBodies);

            // Оверстие через тело
            holePackageBuilder.HoleDepthLimitOption = HolePackageBuilder.
                HoleDepthLimitOptions.ThroughBody;

            SketchFeature sketchFeature = (SketchFeature)workPart.
                Features.FindObject(sketchFeatureName);
            Sketch sketch = (Sketch)sketchFeature.FindObject(sketchName);
            
            Arc arc = (Arc)sketch.FindObject(holeArcName);
            Scalar scalar = workPart.Scalars.CreateScalar(scalarValue,
                Scalar.DimensionalityType.None,
                SmartObject.UpdateOption.WithinModeling);
            Point point = workPart.Points.CreatePoint(arc, scalar, 
                SmartObject.UpdateOption.WithinModeling);

            const int pointsCount = 1;
            Point[] points = new Point[pointsCount];
            points[0] = point;
            CurveDumbRule curveDumbRule = workPart.ScRuleFactory.
                CreateRuleCurveDumbFromPoints(points);

            const int rulesCount = 1;
            SelectionIntentRule[] rules = new SelectionIntentRule[
                rulesCount];
            rules[0] = curveDumbRule;
            NXObject nullNxOpenNXObject = null;
            Point3d helpPoint = new Point3d(0.0, 0.0, 0.0);
            holePackageBuilder.HolePosition.AddToSection(rules, 
                nullNxOpenNXObject, nullNxOpenNXObject, nullNxOpenNXObject, 
                helpPoint, Section.Mode.Create, false);

            holePackageBuilder.GeneralSimpleHoleDiameter.RightHandSide = 
                holeDiameter.ToString().Replace(',', '.');

            holePackageBuilder.Commit();
            holePackageBuilder.Destroy();
        }

        private void CreateElemetsArray(Part workPart, string arrayObjectName,
            string arrayPlaceName, int elementsCount)
        {
            Feature nullNxOpenFeaturesFeature = null;
            PatternFeatureBuilder patternFeatureBuilder = workPart.Features.
                CreatePatternFeatureBuilder(nullNxOpenFeaturesFeature);

            Point3d origin = new Point3d(0.0, 0.0, 0.0);
            Vector3d normal = new Vector3d(0.0, 0.0, 1.0);

            Plane plane = workPart.Planes.CreatePlane(origin, normal, 
                SmartObject.UpdateOption.WithinModeling);
            patternFeatureBuilder.PatternService.MirrorDefinition.
                NewPlane = plane;

            patternFeatureBuilder.PatternService.PatternType = 
                PatternDefinition.PatternEnum.Circular;
            patternFeatureBuilder.PatternService.CircularDefinition.
                AngularSpacing.SpaceType = PatternSpacing.SpacingType.Span;

            patternFeatureBuilder.PatternService.CircularDefinition.
                AngularSpacing.SpanAngle.RightHandSide = "360";

            patternFeatureBuilder.PatternMethod = PatternFeatureBuilder.
                PatternMethodOptions.Variational;

            Vector3d vector = new Vector3d(1.0, 0.0, 0.0);
            Direction direction = workPart.Directions.CreateDirection(
                origin, vector, SmartObject.UpdateOption.WithinModeling);

            Point nullNxOpenPoint = null;
            Axis axis = workPart.Axes.CreateAxis(nullNxOpenPoint, direction, 
                SmartObject.UpdateOption.WithinModeling);
            patternFeatureBuilder.PatternService.CircularDefinition.
                RotationAxis = axis;

            const int objectsCount = 1;
            Feature[] objects = new Feature[objectsCount];
            HolePackage holePackage = (HolePackage)workPart.Features.
                FindObject(arrayObjectName);
            objects[0] = holePackage;
            patternFeatureBuilder.FeatureList.Add(objects);

            Revolve revolve = (Revolve)workPart.Features.FindObject(
                arrayPlaceName);
            Edge edge = (Edge)revolve.FindObject("EDGE * 5 * 6 " +
                "{" 
                    + "(85.7231350896827,53.5038941198678,-30.8904876727989)" 
                    + "(85.7231350896827,0,61.7809753455978)" 
                    + "(85.7231350896827,-53.5038941198678,-30.8904876727989) " 
                    + "REVOLVED(2)" +
                "}");

            workPart.Xforms.CreateExtractXform(edge, SmartObject.UpdateOption.
                WithinModeling, false, out NXObject nXObject);

            Edge edge2 = (Edge)nXObject;
            Point point3 = workPart.Points.CreatePoint(edge2, 
                SmartObject.UpdateOption.WithinModeling);

            point3.RemoveViewDependency();

            axis.Point = point3;

            patternFeatureBuilder.PatternService.CircularDefinition.
                AngularSpacing.NCopies.RightHandSide = 
                elementsCount.ToString();

            patternFeatureBuilder.ParentFeatureInternal = false;

            patternFeatureBuilder.Commit();

            patternFeatureBuilder.Destroy();
        }

        private void InitPetalSketch(Session session, Part workPart)
		{
            session.BeginTaskEnvironment();

            Sketch nullNXOpen_Sketch = null;
            SketchInPlaceBuilder sketchInPlaceBuilder = workPart.Sketches.
                CreateSketchInPlaceBuilder2(nullNXOpen_Sketch);

            Point3d origin = new Point3d(0.0, 0.0, 0.0);
            Vector3d normal = new Vector3d(0.0, 0.0, 1.0);
            Plane plane = workPart.Planes.CreatePlane(origin, normal, 
                SmartObject.UpdateOption.WithinModeling);

            sketchInPlaceBuilder.PlaneReference = plane;

            SketchAlongPathBuilder sketchAlongPathBuilder = workPart.
                Sketches.CreateSketchAlongPathBuilder(nullNXOpen_Sketch);
            sketchInPlaceBuilder.PlaneOption = Sketch.PlaneOption.
                ExistingPlane;
            sketchAlongPathBuilder.PlaneLocation.Expression.
                RightHandSide = "0";

            Revolve revolve = (Revolve)workPart.Features.
                FindObject("REVOLVED(2)");
            Face face = (Face)revolve.FindObject("FACE 7");
            Line line = workPart.Lines.CreateFaceAxis(face, 
                SmartObject.UpdateOption.WithinModeling);

            plane.SetMethod(PlaneTypes.MethodType.Distance);

            DatumPlane datumPlane = (DatumPlane)workPart.Datums.
                FindObject("DATUM_CSYS(0) YZ plane");
            NXObject[] geom = new NXObject[1];
            geom[0] = datumPlane;
            plane.SetGeometry(geom);

            plane.Evaluate();

            TaggedObject[] objects = new TaggedObject[1];
            objects[0] = line;

            DatumAxis datumAxis = (DatumAxis)workPart.Datums.
                FindObject("DATUM_CSYS(0) Y axis");
            Direction direction = workPart.Directions.CreateDirection(
                datumAxis, Sense.Forward, 
                SmartObject.UpdateOption.WithinModeling);
            sketchInPlaceBuilder.AxisReference = direction;

            Edge edge = (Edge)revolve.FindObject("EDGE * 3 * 4 " +
                "{" 
                    + "(12.2937697235662,7.9122352397363,-4.5681311455534)" 
                    + "(12.2937697235662,0,9.1362622911068)" 
                    + "(12.2937697235662,-7.9122352397363,-4.5681311455534) " 
                    + "REVOLVED(2)" +
                "}");

            workPart.Xforms.CreateExtractXform(edge, SmartObject.
                UpdateOption.WithinModeling, false, out NXObject nXObject);

            Edge edge2 = (Edge)nXObject;
            Point point = workPart.Points.CreatePoint(edge2, 
                SmartObject.UpdateOption.WithinModeling);
            sketchInPlaceBuilder.SketchOrigin = point;

            Sketch sketch = (Sketch)sketchInPlaceBuilder.Commit();
            sketch.Activate(Sketch.ViewReorient.True);

            sketchInPlaceBuilder.Destroy();
            sketchAlongPathBuilder.Destroy();

            session.ActiveSketch.SetName("SKETCH_001");
        }

        private void CreatePetalSketch(Session session, Part workPart)
        {
            SketchFeature sketchFeature = (SketchFeature)workPart.
                Features.FindObject(SKETCH_FEATURE_NAME);
            Sketch sketch = (Sketch)sketchFeature.FindObject(SKETCH_NAME);
            Arc offsetRightArc = (Arc)sketch.FindObject(
                OFFSET_RIGHT_ARC_NAME);
            double offsetRightArcTopY = offsetRightArc.CenterPoint.Y 
                + offsetRightArc.Radius * Math.Sin(
                    offsetRightArc.StartAngle);
            double offsetRightArcBottomY = offsetRightArc.CenterPoint.Y
                + offsetRightArc.Radius * Math.Sin(
                    offsetRightArc.EndAngle);

            const int indentPercent = 10;
            double indent = (offsetRightArcTopY - offsetRightArcBottomY) 
                * indentPercent / 100;
            double startPointY = offsetRightArcTopY - indent;
            double endPointY = offsetRightArcBottomY + indent;

            Arc placeArc = (Arc)sketch.FindObject(LAST_ARC_NAME);
            double x = placeArc.CenterPoint.X + placeArc.Radius 
                * Math.Cos(placeArc.StartAngle);

            double z = 0.0;

            Point3d startPoint = new Point3d(x, startPointY, z);
            Point3d endPoint = new Point3d(x, endPointY, z);
            Line line = workPart.Curves.CreateLine(startPoint, endPoint);
            session.ActiveSketch.AddGeometry(line, Sketch.
                InferConstraintsOption.InferNoConstraints);

            session.ActiveSketch.Update();
        }

        private void Extrusion()
        {

        }

        public void Build()
		{
            Session session = Session.GetSession();
            Part workPart = session.Parts.Work;

			Sketch sketch = InitSketch(session, workPart);
			CreateSketch(session, workPart);
			ChangeDiameter(session, workPart);
			ChangeWidth(session, workPart);
			ChangeCentralHoleDiameter(session);
			ChangeOffset(session, workPart);
			FinishSketch(session);

			RevolveSketch(workPart, sketch);
			const double scalarValue = 0.5;
			CreateHole(workPart, REVOLVED_NAME, SKETCH_FEATURE_NAME,
				SKETCH_NAME, HOLE_ARC_NAME, scalarValue,
				_alloyWheelsData.DrillDiameter);
			CreateElemetsArray(workPart, HOLE_NAME, REVOLVED_NAME,
				 _alloyWheelsData.DrillingsCount);
			InitPetalSketch(session, workPart);
            //CreatePetalSketch(session, workPart);
        }

        public AlloyWheelsBuilder(AlloyWheelsData alloyWheelsData)
		{
            _alloyWheelsData = alloyWheelsData;
        }
    }
}
