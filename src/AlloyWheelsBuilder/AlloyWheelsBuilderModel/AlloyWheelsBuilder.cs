using System;
using System.Collections.Generic;
using NXOpen;
using NXOpen.Annotations;
using NXOpen.Features;
using NXOpen.GeometricUtilities;

namespace AlloyWheelsBuilderModel
{
    /// <summary>
    /// Класс <see cref="AlloyWheelsBuilder"/> предназначен для 
    /// построения модели автомобильного диска
    /// </summary>
    public class AlloyWheelsBuilder
    {
        /// <summary>
        /// Имя эскиза автомобильного диска
        /// </summary>
        private const string SKETCH_NAME = "SKETCH_000";
        /// <summary>
        /// Имя эскиза автомобильного диска
        /// </summary>
        private const string SKETCH_FEATURE_NAME = "SKETCH(1)";
        
        /// <summary>
        /// Имя размера, задающего радиус диска
        /// </summary>
        private const string RADIUS_DIMENSION_NAME = "p4";
        /// <summary>
        /// Имя нижней дуги, от которой задается размер радиуса
        /// </summary>
        private const string RADIUS_BOTTOM_ARC_NAME = "Curve Arc35";
        /// <summary>
        /// Имя верхней дуги, от которой задается размер радиуса
        /// </summary>
        private const string RADIUS_TOP_ARC_NAME = "Curve Arc44";

        /// <summary>
        /// Имя размера, задающего посадочную ширину диска
        /// </summary>
        private const string WIDTH_DIMENSION_NAME = "p5";
        /// <summary>
        /// Имя левой дуги, от которой задается размер посадочной ширины
        /// </summary>
        private const string WIDTH_LEFT_ARC_NAME = "Curve Arc3";
        /// <summary>
        /// Имя правой дуги, от которой задается размер посадочной ширины
        /// </summary>
        private const string WIDTH_RIGHT_ARC_NAME = "Curve Arc16";

        /// <summary>
        /// Имя дуги привалочной поверхности диска
        /// </summary>
        private const string WHEELS_MATING_PLACE_ARC_NAME = "Curve Arc34";

        /// <summary>
        /// Имя дуги, внутренней поверхности диска
        /// </summary>
        private const string OFFSET_RIGHT_ARC_NAME = "Curve Arc32";
        /// <summary>
        /// Имя дуги, внешней поверхности диска
        /// </summary>
        private const string OFFSET_LEFT_ARC_NAME = "Curve Arc39";

        /// <summary>
        /// Имя объкта вращения
        /// </summary>
        private const string REVOLVED_NAME = "REVOLVED(2)";

        /// <summary>
        /// Имя дуги, на которой располагается сверловка
        /// </summary>
        private const string HOLE_ARC_NAME = "Curve Arc37";
        /// <summary>
        /// Имя отверстия
        /// </summary>
        private const string HOLE_NAME = "SIMPLE HOLE(3)";

        /// <summary>
        /// Имя внешней грани диска
        /// </summary>
        private const string REVOLVED_FACE_NAME = "FACE 7";

        /// <summary>
        /// Имя плоскости для создания эскиза рисунка
        /// </summary>
        private const string DATUM_PLANE_NAME = "DATUM_CSYS(0) YZ plane";

        /// <summary>
        /// Имя эскиза рисунка
        /// </summary>
        private const string PETAL_SKETCH_NAME = "SKETCH_001";

        /// <summary>
        /// Имя эскиза рисунка
        /// </summary>
        private const string PETAL_SKETCH_FEATURE_NAME = "SKETCH(5)";

        /// <summary>
        /// Возвращает индекс первой дуги в эскизе лепестка
        /// </summary>
        private const int MIN_PETAL_SKETCH_ARC_INDEX = 46;

        /// <summary>
        /// Возвращает индекс последней дуги в эскизе лепестка
        /// </summary>
        private const int MAX_PETAL_SKETCH_ARC_INDEX = 49;

        /// <summary>
        /// Имя нижней дуги эскиза рисунка
        /// </summary>
        private const string BOTTOM_PETAL_ARC = "Curve Arc49";

        /// <summary>
        /// Имя верхней дуги эскиза рисунка
        /// </summary>
        private const string TOP_PETAL_ARC = "Curve Arc46";

        /// <summary>
        /// Минимальный индекс, каторый может быть назначен размеру лепестка
        /// </summary>
        private const int MIN_PETAL_HEIGHT_DIMENSION_NAME_INDEX = 132;

        /// <summary>
        /// Возвращает имя размера лепестка
        /// </summary>
        private string PetalHeihgtDimensionName => "p" 
            + (MIN_PETAL_HEIGHT_DIMENSION_NAME_INDEX 
            + 5 * (_alloyWheelsData[AlloyWheelsParameterName.DrillingsCount].Value 
            - _alloyWheelsData[AlloyWheelsParameterName.DrillingsCount].GetMinValue(
                _alloyWheelsData.ParameterValues, 
                AlloyWheelsParameterName.DrillDiameter)));

        /// <summary>
        /// Имя оси для отражения эскиза лепестка
        /// </summary>
        private const string PETAL_MIRROR_AXIS_NAME = "DATUM_CSYS(0) Y axis";

        /// <summary>
        /// Имя дуги тела выдавливания. Необходимо для создания массива элементов
        /// </summary>
        private const string EXTRUDE_ARC_NAME = "Curve Arc52";

        /// <summary>
        /// Грань тела выдавливания. Необходимо для создания массива элементов
        /// </summary>
        private const string EXTRUDE_FACE_NAME = "FACE 45";

        /// <summary>
        /// Имя тела выдавливания
        /// </summary>
        private const string EXTRUDE_NAME = "EXTRUDE(6)";

        /// <summary>
        /// Хранит параметры модели диска
        /// </summary>
        private AlloyWheelsParameters _alloyWheelsData;

        /// <summary>
        /// Создает эскиз в среде задач
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="sketchName">Имя эскиза</param>
        /// <returns>Возвращает созданный эскиз</returns>
        private Sketch InitAlloyWheelsSketch(Session session, Part workPart, 
            string sketchName)
        {
            Sketch nullNxOpenSketch = null;
            SketchInPlaceBuilder sketchInPlaceBuilder = workPart.Sketches.
                CreateSketchInPlaceBuilder2(nullNxOpenSketch);

            Point3d origin = new Point3d(0.0, 0.0, 0.0);
            Vector3d normal = new Vector3d(0.0, 0.0, 1.0);
            Plane plane = workPart.Planes.CreatePlane(origin, normal, 
                SmartObject.UpdateOption.WithinModeling);
            sketchInPlaceBuilder.PlaneReference = plane;

            SketchAlongPathBuilder sketchAlongPathBuilder = workPart.
                Sketches.CreateSketchAlongPathBuilder(nullNxOpenSketch);

            NXObject nXObject = sketchInPlaceBuilder.Commit();

            Sketch sketch = (Sketch)nXObject;
            sketch.Activate(Sketch.ViewReorient.True);

            sketchInPlaceBuilder.Destroy();
            sketchAlongPathBuilder.Destroy();
            plane.DestroyPlane();

            session.ActiveSketch.SetName(sketchName);

            return sketch;
        }

        /// <summary>
        /// Создает эскиз из списка дуг
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="arcs">Список дуг</param>
        private void CreateSketch(Session session, Part workPart, 
            List<ArcData> arcs)
        {
            foreach (ArcData arcData in arcs)
            {
                Arc arc = workPart.Curves.CreateArc(arcData.StartPoint, 
                    arcData.PointOn, arcData.EndPoint, 
                    false, out bool value);
                session.ActiveSketch.AddGeometry(arc,
                    Sketch.InferConstraintsOption.InferNoConstraints);
            }
        }

        /// <summary>
        /// Завершает создание эскиза
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        private void FinishSketch(Session session)
        {
            session.ActiveSketch.Update();
            session.ActiveSketch.Deactivate(Sketch.ViewReorient.True,
                Sketch.UpdateLevel.Model);
        }

        /// <summary>
        /// Создает эскиз автомобильного диска
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        /// <param name="workPart">Рабочая часть</param>
        /// <returns>Возвращает эскиз автомобильного диска</returns>
        private Sketch CreateAlloyWheelsSketch(Session session, 
            Part workPart)
        {
            Sketch sketch = InitAlloyWheelsSketch(session, 
                workPart, SKETCH_NAME);
            CreateSketch(session, workPart, _alloyWheelsData.SketchArcs);
            ChangeDiameter(session, workPart);
            ChangeWidth(session, workPart);
            ChangeCentralHoleDiameter(session);
            ChangeOffset(session, workPart);
            FinishSketch(session);
            return sketch;
        }

        /// <summary>
        /// Устанавнивает линейный размер на эскизе
        /// </summary>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="dimensionName">Имя размера</param>
        /// <param name="bottomArc">Нижняя дуги, 
        /// от которой задается размер</param>
        /// <param name="topArc">Верхняя дуга, 
        /// от которой задается размер</param>
        private void SetLinearDimension(Part workPart, Arc bottomArc, 
            Arc topArc, string dimensionName)
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

            double bottomPointX = bottomArc.CenterPoint.X + bottomArc.Radius
                * Math.Cos(bottomArc.StartAngle);
            double bottomPointY = bottomArc.CenterPoint.Y + bottomArc.Radius
                * Math.Sin(bottomArc.StartAngle);
            const double bottomPointZ = 0.0;
            Point3d bottomPoint = new Point3d(bottomPointX, bottomPointY, 
                bottomPointZ);
            sketchLinearDimensionBuilder.FirstAssociativity.SetValue(
                InferSnapType.SnapType.Start, bottomArc,
                workPart.ModelingViews.WorkView, bottomPoint, null,
                nullNxOpenView, startPoint);

            double topPointX = topArc.CenterPoint.X + topArc.Radius
                * Math.Cos(topArc.EndAngle);
            double topPointY = topArc.CenterPoint.Y + topArc.Radius
                * Math.Sin(topArc.EndAngle);
            const double topPointZ = 0.0;
            Point3d topPoint = new Point3d(topPointX, topPointY, topPointZ);
            sketchLinearDimensionBuilder.SecondAssociativity.SetValue(
                InferSnapType.SnapType.End, topArc, 
                workPart.ModelingViews.WorkView,
                topPoint, null, nullNxOpenView, startPoint);

            sketchLinearDimensionBuilder.Origin.
                SetInferRelativeToGeometry(true);

            // Для выравнивания размера
            const double originPointX = -16.425305624190489;
            const double originPointY = 3.4224712283621521;
            const double originPointZ = 0.0;
            Point3d point = new Point3d(originPointX, 
                originPointY, originPointZ);
            sketchLinearDimensionBuilder.Origin.Origin.SetValue(null, 
                nullNxOpenView, point);

            sketchLinearDimensionBuilder.Commit();

            sketchLinearDimensionBuilder.Destroy();
        }

        /// <summary>
        /// Изменяет линейный размер
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="dimensionName">Имя размера</param>
        /// <param name="oldDimension">Старый размер</param>
        /// <param name="newDimension">Новый размер</param>
        /// <param name="isNeededScaling">Нужно ли масштабирование</param>
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
                session.ActiveSketch.Scale(Math.Abs(
                    newDimension / oldDimension));
            }

            session.ActiveSketch.LocalUpdate();

            sketchLinearDimensionBuilder.Destroy();
        }

        /// <summary>
        /// Изменяет диаметр диска
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        /// <param name="workPart">Рабочая часть</param>
        private void ChangeDiameter(Session session, Part workPart)
        {
            Arc bottomArc = (Arc)session.ActiveSketch.FindObject(
                RADIUS_BOTTOM_ARC_NAME);
            Arc topArc = (Arc)session.ActiveSketch.FindObject(
                RADIUS_TOP_ARC_NAME);
            SetLinearDimension(workPart, bottomArc, topArc, 
                RADIUS_DIMENSION_NAME);

            double bottomPointY = bottomArc.CenterPoint.Y + bottomArc.Radius
                * Math.Sin(bottomArc.StartAngle);
            double topPointY = topArc.CenterPoint.Y + topArc.Radius
                * Math.Sin(topArc.EndAngle);
            double radius = topPointY - bottomPointY;

            double newRadius = _alloyWheelsData[AlloyWheelsParameterName.Diameter].Value / 2;

            ChangeLinearDimension(session, workPart, RADIUS_DIMENSION_NAME,
                radius, newRadius - _alloyWheelsData[AlloyWheelsParameterName.CentralHoleDiameter].Value / 2,
                true);
        }

        /// <summary>
        /// Изменяет посадочную ширину диска
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        /// <param name="workPart">Рабочая часть</param>
        private void ChangeWidth(Session session, Part workPart)
        {
            Arc leftArc = (Arc)session.ActiveSketch.FindObject(
                WIDTH_LEFT_ARC_NAME);
            Arc rightArc = (Arc)session.ActiveSketch.FindObject(
                WIDTH_RIGHT_ARC_NAME);

            SetLinearDimension(workPart, leftArc, rightArc, 
                WIDTH_DIMENSION_NAME);
            
            double leftPointX = leftArc.CenterPoint.X + leftArc.Radius
                * Math.Cos(leftArc.StartAngle);
            double rightPointX = rightArc.CenterPoint.X + rightArc.Radius
                * Math.Cos(rightArc.EndAngle);
            double width = rightPointX - leftPointX;

            ChangeLinearDimension(session, workPart, WIDTH_DIMENSION_NAME, 
                width, _alloyWheelsData[AlloyWheelsParameterName.Width].Value, false);
        }

        /// <summary>
        /// Изменяет диаметр центрального отверстия
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        private void ChangeCentralHoleDiameter(Session session)
        {
            for (int i = 1; i <= _alloyWheelsData.SketchArcsCount; i++)
            {
                Arc arc = (Arc)session.ActiveSketch.FindObject(
                    "Curve Arc" + i);
                arc.SetParameters(arc.Radius, new Point3d(
                    arc.CenterPoint.X, arc.CenterPoint.Y 
                    + _alloyWheelsData[AlloyWheelsParameterName.CentralHoleDiameter].Value / 2, 
                    arc.CenterPoint.Z), arc.StartAngle, arc.EndAngle);

                const int geomsCount = 1;
                SmartObject[] geoms = new SmartObject[geomsCount];
                geoms[0] = arc;
                session.ActiveSketch.UpdateGeometryDisplay(geoms);
            }
        }

        /// <summary>
        /// Перемещает точку дуги
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="arcName">Имя дуги</param>
        /// <param name="dx">Смещение</param>
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

            session.ActiveSketch.Preferences.
                ContinuousAutoDimensioningSetting = false;

            session.ActiveSketch.Update();

            session.ActiveSketch.Preferences.
                ContinuousAutoDimensioningSetting = true;

            session.ActiveSketch.RunAutoDimension();
        }

        /// <summary>
        /// Изменяет вылет диска
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        /// <param name="workPart">Рабочая часть</param>
        private void ChangeOffset(Session session, Part workPart)
        {
            Arc leftArc = (Arc)session.ActiveSketch.FindObject(
                WIDTH_LEFT_ARC_NAME);
            Arc rightArc = (Arc)session.ActiveSketch.FindObject(
                WIDTH_RIGHT_ARC_NAME);

            double leftX = leftArc.CenterPoint.X + leftArc.Radius
                * Math.Cos(leftArc.StartAngle);
            double rightX = rightArc.CenterPoint.X + rightArc.Radius
                * Math.Cos(rightArc.StartAngle);

            double centerX = leftX + ((rightX - leftX) / 2);

            Arc wheelsMatingPlaceArc = ((Arc)session.ActiveSketch.FindObject(
                WHEELS_MATING_PLACE_ARC_NAME));

            double dx = 0.0;
            if(_alloyWheelsData[AlloyWheelsParameterName.OffSet].Value < 0)
            {
                dx = centerX - (wheelsMatingPlaceArc.CenterPoint.X 
                    + wheelsMatingPlaceArc.Radius 
                    * Math.Cos(wheelsMatingPlaceArc.StartAngle)) 
                    - _alloyWheelsData[AlloyWheelsParameterName.OffSet].Value;
            }
            else if(_alloyWheelsData[AlloyWheelsParameterName.OffSet].Value > 0)
            {
                if(centerX - (wheelsMatingPlaceArc.CenterPoint.X
                    + wheelsMatingPlaceArc.Radius
                    * Math.Cos(wheelsMatingPlaceArc.StartAngle)) <
                    centerX - _alloyWheelsData[AlloyWheelsParameterName.OffSet].Value)
                {
                    dx = -1 * (_alloyWheelsData[AlloyWheelsParameterName.OffSet].Value - 
                        (centerX - (wheelsMatingPlaceArc.CenterPoint.X
                        + wheelsMatingPlaceArc.Radius
                        * Math.Cos(wheelsMatingPlaceArc.StartAngle))));
                }
                else if(centerX - (wheelsMatingPlaceArc.CenterPoint.X
                    + wheelsMatingPlaceArc.Radius
                    * Math.Cos(wheelsMatingPlaceArc.StartAngle)) >
                    centerX - _alloyWheelsData[AlloyWheelsParameterName.OffSet].Value)
                {
                    dx = centerX - _alloyWheelsData[AlloyWheelsParameterName.OffSet].Value - 
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

            const int startArcIndex = 33;
            const int endArcIndex = 38;
            for (int i = startArcIndex; i <= endArcIndex; i++)
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

        /// <summary>
        /// Выполняет вращение
        /// </summary>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="sketch">Объект вращение</param>
        /// <param name="section">Сессия</param>
        /// <param name="sketchName">Имя эскиза</param>
        /// <param name="revolveArcName">Дуга пращения</param>
        /// <param name="helpPoint">Вспомогательная точка</param>
        /// <param name="direction">Направление</param>
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

        /// <summary>
        /// Выполняе вращение эскиза диска
        /// </summary>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="sketch">Имя эскиза</param>
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

        /// <summary>
        /// Создает отверстие
        /// </summary>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="bodyName">Имя тела вращения</param>
        /// <param name="sketchFeatureName">Имя эскиза</param>
        /// <param name="sketchName">Имя эскиза</param>
        /// <param name="holeArcName">Дуга, 
        /// на которой будет располагаться отверстие</param>
        /// <param name="scalarValue">Скаляр</param>
        /// <param name="holeDiameter">Диаметр отверстия</param>
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

        /// <summary>
        /// Создает массив элементов
        /// </summary>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="arrayObjectName">Имя объекта</param>
        /// <param name="arrayPlaceName">Имя плоскости для 
        /// расположение массива</param>
        /// <param name="elementsCount">Количество элементов</param>
        private void CreateElemetsArray(Part workPart, 
            string featureName, string arrayPlaceName, int elementsCount)
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
            Feature feature = workPart.Features.FindObject(featureName);
            objects[0] = feature;
            patternFeatureBuilder.FeatureList.Add(objects);

            Revolve revolve = (Revolve)workPart.Features.FindObject(
                arrayPlaceName);
            Edge edge = (Edge)revolve.FindObject("EDGE * 5 * 6 " +
                "{"
                    + "(85.7231350896827,53.5038941198678,-30.8904876727989)"
                    + "(85.7231350896827,0,61.7809753455978)"
                    + "(85.7231350896827,-53.5038941198678,-30.8904876727989)"
                    + " " + REVOLVED_NAME +
                "}");

            workPart.Xforms.CreateExtractXform(edge, 
                SmartObject.UpdateOption.WithinModeling, 
                false, out NXObject nXObject);

            Edge edge2 = (Edge)nXObject;
            Point point = workPart.Points.CreatePoint(edge2, 
                SmartObject.UpdateOption.WithinModeling);

            point.RemoveViewDependency();

            axis.Point = point;

            patternFeatureBuilder.PatternService.CircularDefinition.
                AngularSpacing.NCopies.RightHandSide = 
                elementsCount.ToString();

            patternFeatureBuilder.ParentFeatureInternal = false;

            patternFeatureBuilder.Commit();

            patternFeatureBuilder.Destroy();
        }

        /// <summary>
        /// Создает эскиз в среде задач 
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="sketchName">Имя эскиза</param>
        /// <returns>Эскиз</returns>
        private Sketch InitPetalSketch(Session session, Part workPart, 
            string sketchName)
        {
            Sketch nullNxOpenSketch = null;
            SketchInPlaceBuilder sketchInPlaceBuilder = workPart.Sketches.
                CreateSketchInPlaceBuilder2(nullNxOpenSketch);

            Point3d origin = new Point3d(0.0, 0.0, 0.0);
            Vector3d normal = new Vector3d(0.0, 0.0, 1.0);
            Plane plane = workPart.Planes.CreatePlane(origin, normal, 
                SmartObject.UpdateOption.WithinModeling);
            sketchInPlaceBuilder.PlaneReference = plane;

            Unit unit = workPart.UnitCollection.FindObject("MilliMeter");
            workPart.Expressions.CreateSystemExpressionWithUnits("0", unit);

            sketchInPlaceBuilder.OriginOption = OriginMethod.WorkPartOrigin;

            Vector3d vector = new Vector3d(0.0, 0.0, 1.0);
            Direction direction = workPart.Directions.CreateDirection(origin,
                vector, SmartObject.UpdateOption.WithinModeling);
            sketchInPlaceBuilder.AxisReference = direction;

            Revolve revolve = (Revolve)workPart.Features.FindObject(
                REVOLVED_NAME);
            Face face = (Face)revolve.FindObject(REVOLVED_FACE_NAME);
            Line line = workPart.Lines.CreateFaceAxis(face, SmartObject.
                UpdateOption.WithinModeling);
            line.SetVisibility(SmartObject.VisibilityOption.Visible);

            plane.SetMethod(PlaneTypes.MethodType.Distance);

            const int geomsCount = 1;
            NXObject[] geom = new NXObject[geomsCount];
            DatumPlane datumPlane = (DatumPlane)workPart.Datums.
                FindObject(DATUM_PLANE_NAME);
            geom[0] = datumPlane;
            plane.SetGeometry(geom);

            plane.Evaluate();

            NXObject nXObject = sketchInPlaceBuilder.Commit();

            Sketch sketch = (Sketch)nXObject;
            sketch.Activate(Sketch.ViewReorient.True);

            sketchInPlaceBuilder.Destroy();

            session.ActiveSketch.SetName(sketchName);

            return sketch;
        }

        /// <summary>
        /// Изменяет высоту эскиза лепестка
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="newPetalHeight">Новый размер</param>
        private void ChengePetalHeight(Session session, Part workPart, 
            double newPetalHeight)
        {
            SetLinearDimension(workPart, 
               (Arc)session.ActiveSketch.FindObject(BOTTOM_PETAL_ARC),
               (Arc)session.ActiveSketch.FindObject(TOP_PETAL_ARC),
               PetalHeihgtDimensionName);

            ChangeLinearDimension(session, workPart, PetalHeihgtDimensionName,
                _alloyWheelsData.PetalSketchHeight, newPetalHeight, true);
        }

        /// <summary>
        /// Перемещает эскиз лепестка по оси Y
        /// </summary>
        /// <param name="session">текущая сессия</param>
        /// <param name="dy">Смещение</param>
        private void MovePetal(Session session, double dy)
        {
            for (int i = MIN_PETAL_SKETCH_ARC_INDEX; 
                i <= MAX_PETAL_SKETCH_ARC_INDEX; i++)
            {
                Arc arc = (Arc)session.ActiveSketch.FindObject(
                    "Curve Arc" + i);
                arc.SetParameters(arc.Radius, new Point3d(arc.CenterPoint.X,
                    arc.CenterPoint.Y + dy, arc.CenterPoint.Z),
                    arc.StartAngle, arc.EndAngle);
            }
        }

        /// <summary>
        /// Создает зеркальную кривую
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="minArcIndgex">Первый индекс дуги эскиза</param>
        /// <param name="maxArcIndex">Последний индекс дуги эскиза</param>
        /// <param name="petalMirrorAxisName">Имя оси</param>
        private void CreateMirrorCurve(Session session, Part workPart, 
            int minArcIndgex, int maxArcIndex, string petalMirrorAxisName)
        {
            SketchPattern nullNxOpenSketchPattern = null;
            SketchMirrorPatternBuilder sketchMirrorPatternBuilder = workPart.
                Sketches.CreateSketchMirrorPatternBuilder(
                nullNxOpenSketchPattern);

            Section section = sketchMirrorPatternBuilder.Section;

            section.SetAllowedEntityTypes(Section.AllowTypes.CurvesAndPoints);

            for (int i = minArcIndgex; i <= maxArcIndex; i++)
            {
                const int curvesCount = 1;
                IBaseCurve[] curves = new IBaseCurve[curvesCount];
                Arc arc = (Arc)session.ActiveSketch.FindObject(
                    "Curve Arc" + i);
                curves[0] = arc;
                CurveDumbRule curveDumbRule = workPart.ScRuleFactory.
                    CreateRuleBaseCurveDumb(curves);
                section.AllowSelfIntersection(true);
                const int rulesCount = 1;
                SelectionIntentRule[] rules = new SelectionIntentRule[
                    rulesCount];
                rules[0] = curveDumbRule;
                NXObject nullNxOpenNxObject = null;
                const double helpPointCoordinate = 0.0;
                Point3d helpPoint = new NXOpen.Point3d(helpPointCoordinate, 
                    helpPointCoordinate, helpPointCoordinate);
                section.AddToSection(rules, arc, nullNxOpenNxObject, 
                    nullNxOpenNxObject, helpPoint, 
                    Section.Mode.Create, false);
            }

            DatumAxis datumAxis = (DatumAxis)workPart.Datums.FindObject(
                petalMirrorAxisName);
            sketchMirrorPatternBuilder.DirectionObject.Value = datumAxis;

            sketchMirrorPatternBuilder.Commit();

            sketchMirrorPatternBuilder.Destroy();
            section.Destroy();
        }

        /// <summary>
        /// Создает эскиз лепестка
        /// </summary>
        /// <param name="session">Текущая сессия</param>
        /// <param name="workPart">Рабочая часть</param>
        /// <returns>Эскиз</returns>
        private Sketch CreatePetalSketch(Session session, Part workPart)
        {
            Sketch petalSketch = InitPetalSketch(session, workPart,
               PETAL_SKETCH_NAME);
            CreateSketch(session, workPart, _alloyWheelsData.PetalSketchArcs);

            SketchFeature sketchFeature = (SketchFeature)workPart.
                    Features.FindObject(SKETCH_FEATURE_NAME);
            Sketch sketch = (Sketch)sketchFeature.FindObject(SKETCH_NAME);
            Arc offsetLeftArc = (Arc)sketch.FindObject(OFFSET_LEFT_ARC_NAME);
            double offsetLeftArcTopY = offsetLeftArc.CenterPoint.Y
                + offsetLeftArc.Radius * Math.Sin(offsetLeftArc.StartAngle);
            double offsetLeftArcBottomY = offsetLeftArc.CenterPoint.Y
                + offsetLeftArc.Radius * Math.Sin(offsetLeftArc.EndAngle);

            if(offsetLeftArcTopY < offsetLeftArcBottomY)
            {
                double y = offsetLeftArcTopY;
                offsetLeftArcTopY = offsetLeftArcBottomY;
                offsetLeftArcBottomY = y;
            }

            double offsetLeftArcHeight = offsetLeftArcTopY 
                - offsetLeftArcBottomY;

            const int indentPercent = 10;
            double indent = offsetLeftArcHeight * indentPercent / 100;

            double newPetalHeight = offsetLeftArcHeight - indent * 1.2;

            ChengePetalHeight(session, workPart, newPetalHeight);

            Arc bottomPetalArc = (Arc)petalSketch.FindObject(BOTTOM_PETAL_ARC);
            double petalBotoomY = bottomPetalArc.CenterPoint.Y
                + bottomPetalArc.Radius * Math.Sin(bottomPetalArc.StartAngle);

            double newPetalBottomY = offsetLeftArcBottomY + indent;
            double dy = newPetalBottomY - petalBotoomY;

            MovePetal(session, dy);

            CreateMirrorCurve(session, workPart, MIN_PETAL_SKETCH_ARC_INDEX, 
                MAX_PETAL_SKETCH_ARC_INDEX, PETAL_MIRROR_AXIS_NAME);

            FinishSketch(session);

            return petalSketch;
        }

        /// <summary>
        /// Выдавливание
        /// </summary>
        /// <param name="workPart">Рабочая часть</param>
        /// <param name="extrudeFromObjectName">Объект 
        /// из которого происходит выдавливание</param>
        /// <param name="petalSkecthFeatureName">Имя эскиза лепестка</param>
        /// <param name="petalSketchName">Имя эскиза детали</param>
        /// <param name="extrudeArcName">Дуга</param>
        /// <param name="extrudeFaceName">Поверхность, 
        /// до которой происходит выдавливание</param>
        private void Extrude(Part workPart, string extrudeFromObjectName, 
            string petalSkecthFeatureName, string petalSketchName, 
            string extrudeArcName, string extrudeFaceName)
        {
            Feature nullNxOpenFeaturesFeature = null;
            ExtrudeBuilder extrudeBuilder = workPart.Features.
                CreateExtrudeBuilder(nullNxOpenFeaturesFeature);

            const double sectionCoordinate = 0.0;
            Section section = workPart.Sections.CreateSection(
                sectionCoordinate, sectionCoordinate, sectionCoordinate);
            extrudeBuilder.Section = section;

            extrudeBuilder.BooleanOperation.Type = BooleanOperation.
                BooleanType.Subtract;

            const int targetBodiesCount = 1;
            Body[] targetBodies = new Body[targetBodiesCount];
            Body body = (Body)workPart.Bodies.FindObject(
                extrudeFromObjectName);
            targetBodies[0] = body;
            extrudeBuilder.BooleanOperation.SetTargetBodies(targetBodies);

            const int featuesCount = 1;
            Feature[] features = new Feature[featuesCount];
            SketchFeature sketchFeature = (SketchFeature)workPart.
                Features.FindObject(petalSkecthFeatureName);
            features[0] = sketchFeature;
            CurveFeatureRule curveFeatureRule = workPart.ScRuleFactory.
                CreateRuleCurveFeature(features);

            const int rulesCount = 1;
            SelectionIntentRule[] rules = new SelectionIntentRule[
                rulesCount];
            rules[0] = curveFeatureRule;
            Sketch sketch = (Sketch)sketchFeature.FindObject(
                petalSketchName);
            Arc arc = (Arc)sketch.FindObject(extrudeArcName);
            NXObject nullNxOpenNxObject = null;
            Point3d helpPoint = new Point3d(0.0, 0.0, 0.0);
            section.AddToSection(rules, arc, nullNxOpenNxObject, 
                nullNxOpenNxObject, helpPoint, Section.Mode.Create, false);

            Direction direction = workPart.Directions.CreateDirection(
                sketch, Sense.Forward, 
                SmartObject.UpdateOption.WithinModeling);

            extrudeBuilder.Direction = direction;

            extrudeBuilder.Limits.EndExtend.TrimType = Extend.
                ExtendType.UntilSelected;

            Revolve revolve = (Revolve)workPart.Features.FindObject(
                extrudeFromObjectName);
            Face face = (Face)revolve.FindObject(extrudeFaceName);
            extrudeBuilder.Limits.EndExtend.Target = face;

            extrudeBuilder.CommitFeature();
            extrudeBuilder.Destroy();
        }

        /// <summary>
        /// Создает модель автомобильного диска
        /// </summary>
        public void Build()
        {
            Session session = Session.GetSession();
            Part workPart = session.Parts.Work;

            Sketch alloyWheelsSketch = CreateAlloyWheelsSketch(session,
                workPart);

            RevolveSketch(workPart, alloyWheelsSketch);

            const double scalarValue = 0.5;
            CreateHole(workPart, REVOLVED_NAME, SKETCH_FEATURE_NAME,
                SKETCH_NAME, HOLE_ARC_NAME, scalarValue,
                _alloyWheelsData[AlloyWheelsParameterName.DrillDiameter].Value);
            CreateElemetsArray(workPart, HOLE_NAME, REVOLVED_NAME,
                 (int)_alloyWheelsData[AlloyWheelsParameterName.DrillingsCount].Value);

            Sketch petalSketch = CreatePetalSketch(session, workPart);
            Extrude(workPart, REVOLVED_NAME, PETAL_SKETCH_FEATURE_NAME,
                PETAL_SKETCH_NAME, EXTRUDE_ARC_NAME, EXTRUDE_FACE_NAME);
            CreateElemetsArray(workPart, EXTRUDE_NAME, REVOLVED_NAME,
                 (int)_alloyWheelsData[AlloyWheelsParameterName.SpokesCount].Value);
        }

        /// <summary>
        /// Инициализирует объект класса <see cref="AlloyWheelsBuilder"/>
        /// </summary>
        /// <param name="alloyWheelsData">Параметры модели</param>
        public AlloyWheelsBuilder(AlloyWheelsParameters alloyWheelsData)
        {
            _alloyWheelsData = alloyWheelsData;
        }
    }
}
