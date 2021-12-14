using System;
using System.Collections.Generic;
using NXOpen;

namespace AlloyWheelsBuilderModel
{
    /// <summary>
    /// Класс <see cref="AlloyWheelsData"/> предназначен для хранения данных, 
    /// необходимых для построения модели автомобильного диска
    /// </summary>
    public class AlloyWheelsData
    {
        /// <summary>
        /// Возвращает количество дуг эскиза автомобильного диска
        /// </summary>
        public int SketchArcsCount => 45;

        /// <summary>
        /// Возвращает список дуг эскиза автомобильного диска
        /// </summary>
        public List<ArcData> SketchArcs
        {
            get => new List<ArcData>()
            {
                new ArcData(new Point3d(15.44323363559, 92.43285152947, 0.00000000000),
                    new Point3d(17.60996477529, 92.55690331473, 0.00000000000),
                    new Point3d(19.77669591499, 92.43285152947, 0.00000000000)),
                new ArcData(new Point3d(19.77669591499, 92.43285152947, 0.00000000000),
                    new Point3d(23.55528849074, 90.67939696317, 0.00000000000),
                    new Point3d(25.53823099100, 87.01602368023, 0.00000000000)),
                new ArcData(new Point3d(25.53823099100, 87.01602368023, 0.00000000000),
                    new Point3d(27.17454523816, 83.85873231365, 0.00000000000),
                    new Point3d(30.31488827624, 82.19012250545, 0.00000000000)),
                new ArcData(new Point3d(30.31488827624, 82.19012250545, 0.00000000000),
                    new Point3d(33.56375925018, 82.10282645413, 0.00000000000),
                    new Point3d(36.67623414550, 83.03839218236, 0.00000000000)),
                new ArcData(new Point3d(36.67623414550, 83.03839218236, 0.00000000000),
                    new Point3d(38.33517611971, 83.18427403455, 0.00000000000),
                    new Point3d(39.67122728857, 82.19012250545, 0.00000000000)),
                new ArcData(new Point3d(39.67122728857, 82.19012250545, 0.00000000000),
                    new Point3d(40.56414904539, 80.83409095227, 0.00000000000),
                    new Point3d(41.49719071266, 79.5053456478, 0.00000000000)),
                new ArcData(new Point3d(41.49719071266, 79.5053456478, 0.00000000000),
                    new Point3d(42.78681697037, 78.45407714785, 0.00000000000),
                    new Point3d(44.42818701799, 78.18166989701, 0.00000000000)),
                new ArcData(new Point3d(44.42818701799, 78.18166989701, 0.00000000000),
                    new Point3d(53.58361096100, 77.98150676627, 0.00000000000),
                    new Point3d(62.73903490401, 78.18166989701, 0.00000000000)),
                new ArcData(new Point3d(62.73903490401, 78.18166989701, 0.00000000000),
                    new Point3d(73.66231678350, 79.36874173704, 0.00000000000),
                    new Point3d(84.54816870285, 80.8605374879, 0.00000000000)),
                new ArcData(new Point3d(84.54816870285, 80.8605374879, 0.00000000000),
                    new Point3d(85.52865954895, 81.11173765126, 0.00000000000),
                    new Point3d(86.43913406113, 81.55389145261, 0.00000000000)),
                new ArcData(new Point3d(86.43913406113, 81.55389145261, 0.00000000000),
                    new Point3d(87.21242782586, 82.12029624435, 0.00000000000),
                    new Point3d(87.88635288200, 82.80192858907, 0.00000000000)),
                new ArcData(new Point3d(87.88635288200, 82.80192858907, 0.00000000000),
                    new Point3d(89.14699645419, 83.38814382466, 0.00000000000),
                    new Point3d(90.40764002637, 82.80192858907, 0.00000000000)),
                new ArcData(new Point3d(90.40764002637, 82.80192858907, 0.00000000000),
                    new Point3d(91.00489456033, 82.34726834978, 0.00000000000),
                    new Point3d(91.73887963860, 82.19012250545, 0.00000000000)),
                new ArcData(new Point3d(91.73887963860, 82.19012250545, 0.00000000000),
                    new Point3d(93.92735687980, 82.19992512608, 0.00000000000),
                    new Point3d(96.11583412100, 82.19012250544, 0.00000000000)),
                new ArcData(new Point3d(96.11583412100, 82.19012250544, 0.00000000000),
                    new Point3d(97.46124390208, 82.67177439829, 0.00000000000),
                    new Point3d(98.17320443105, 83.91081767038, 0.00000000000)),
                new ArcData(new Point3d(98.17320443001, 83.91081767038, 0.00000000000),
                    new Point3d(98.55646038662, 85.59273051192, 0.00000000000),
                    new Point3d(99.12283685729, 87.22212721925, 0.00000000000)),
                new ArcData(new Point3d(99.12283685729, 87.22212721925, 0.00000000000),
                    new Point3d(99.86542646009, 88.77913608826, 0.00000000000),
                    new Point3d(100.77517276404, 90.24476823926, 0.00000000000)),
                new ArcData(new Point3d(100.77517276404, 90.24476823926, 0.00000000000),
                    new Point3d(102.20059825326, 91.58416471626, 0.00000000000),
                    new Point3d(104.04276090315, 92.24162765761, 0.00000000000)),
                new ArcData(new Point3d(104.04276090315, 92.24162765761, 0.00000000000),
                    new Point3d(106.62455893899, 92.4188396, 0.00000000000),
                    new Point3d(109.20635697483, 92.24162765761, 0.00000000000)),
                new ArcData(new Point3d(109.20635697483, 92.24162765761, 0.00000000000),
                    new Point3d(109.38766428380, 90.33553457646, 0.00000000000),
                    new Point3d(109.20635697483, 88.42944149531, 0.00000000000)),
                new ArcData(new Point3d(109.20635697483, 88.42944149531, 0.00000000000),
                    new Point3d(107.64113094296, 88.35641754421, 0.00000000000),
                    new Point3d(106.07590491109, 88.42944149531, 0.00000000000)),
                new ArcData(new Point3d(106.07590491109, 88.42944149531, 0.00000000000),
                    new Point3d(104.83539052828, 88.04817677016, 0.00000000000),
                    new Point3d(104.04276090315, 87.02056935388, 0.00000000000)),
                new ArcData(new Point3d(104.04276090315, 87.02056935388, 0.00000000000),
                    new Point3d(103.27480666706, 84.78942780707, 0.00000000000),
                    new Point3d(102.58639017882, 82.53247653392, 0.00000000000)),
                new ArcData(new Point3d(102.58639017882, 82.53247653392, 0.00000000000),
                    new Point3d(101.86511563389, 80.77269834792, 0.00000000000),
                    new Point3d(100.77517276404, 79.21414749103, 0.00000000000)),
                new ArcData(new Point3d(100.77517276404, 79.21414749103, 0.00000000000),
                    new Point3d(99.37189304457, 78.68481475187, 0.00000000000),
                    new Point3d(97.87981522137, 78.53285788531, 0.00000000000)),
                new ArcData(new Point3d(97.87981522137, 78.53285788531, 0.00000000000),
                    new Point3d(93.92926082081, 78.58839666299, 0.00000000000),
                    new Point3d(89.97870642026, 78.5328578853, 0.00000000000)),
                new ArcData(new Point3d(89.97870642026, 78.5328578853, 0.00000000000),
                    new Point3d(89.30879064420, 78.4093443311, 0.00000000000),
                    new Point3d(88.70797769904, 78.08830453601, 0.00000000000)),
                new ArcData(new Point3d(88.70797769904, 78.08830453601, 0.00000000000),
                    new Point3d(87.73521573312, 77.56679015178, 0.00000000000),
                    new Point3d(86.65060738924, 77.36217383843, 0.00000000000)),
                new ArcData(new Point3d(86.65060738924, 77.36217383843, 0.00000000000),
                    new Point3d(76.90213931146, 76.63400952691, 0.00000000000),
                    new Point3d(67.24583604330, 75.11129474026, 0.00000000000)),
                new ArcData(new Point3d(67.24583604330, 75.11129474026, 0.00000000000),
                    new Point3d(54.77728321221, 74.7130256015, 0.00000000000),
                    new Point3d(42.30873038112, 75.11129474029, 0.00000000000)),
                new ArcData(new Point3d(42.30873038112, 75.11129474029, 0.00000000000),
                    new Point3d(41.65667885794, 75.34295325559, 0.00000000000),
                    new Point3d(41.22457690904, 75.88343892826, 0.00000000000)),
                new ArcData(new Point3d(41.22457690904, 75.88343892826, 0.00000000000),
                    new Point3d(31.91142478783, 51.01938657605, 0.00000000000),
                    new Point3d(33.98890137774, 16.16394601204, 0.00000000000)),
                new ArcData(new Point3d(33.98890137774, 16.16394601204, 0.00000000000),
                    new Point3d(36.65318046636, 16.04061447383, 0.00000000000),
                    new Point3d(39.31745955499, 16.16394601204, 0.00000000000)),
                new ArcData(new Point3d(39.31745955499, 16.16394601204, 0.00000000000),
                    new Point3d(39.59029603990, 8.22516827524, 0.00000000000),
                    new Point3d(39.31745955499, 0.28639053845, 0.00000000000)),
                new ArcData(new Point3d(39.31745955499, 0.28639053845, 0.00000000000),
                    new Point3d(30.00969964442, 0.0, 0.00000000000),
                    new Point3d(20.70193973385, 0.28639053845, 0.00000000000)),
                new ArcData(new Point3d(20.70193973385, 0.28639053845, 0.00000000000),
                    new Point3d(21.42209908822, 1.0861012816, 0.00000000000),
                    new Point3d(21.97417666841, 2.00988540892, 0.00000000000)),
                new ArcData(new Point3d(21.97417666841, 2.00988540892, 0.00000000000),
                    new Point3d(22.16443323036, 8.35249838148, 0.00000000000),
                    new Point3d(21.97417666841, 14.69511135405, 0.00000000000)),
                new ArcData(new Point3d(21.97417666841, 14.69511135405, 0.00000000000),
                    new Point3d(22.91751971942, 15.69350857512, 0.00000000000),
                    new Point3d(23.36782291782, 16.99116806529, 0.00000000000)),
                new ArcData(new Point3d(23.36782291782, 16.99116806529, 0.00000000000),
                    new Point3d(25.13366583262, 47.70717162499, 0.00000000000),
                    new Point3d(29.36403590491, 78.18166989706, 0.00000000000)),
                new ArcData(new Point3d(29.36403590491, 78.18166989706, 0.00000000000),
                    new Point3d(27.72584404825, 78.10190743983, 0.00000000000),
                    new Point3d(26.08765219159, 78.18166989701, 0.00000000000)),
                new ArcData(new Point3d(26.08765219159, 78.18166989701, 0.00000000000),
                    new Point3d(23.60214791278, 80.19065421666, 0.00000000000),
                    new Point3d(22.38986588753, 83.14770034546, 0.00000000000)),
                new ArcData(new Point3d(22.38986588753, 83.14770034546, 0.00000000000),
                    new Point3d(22.03013014096, 84.83377821022, 0.00000000000),
                    new Point3d(21.43177677267, 86.45063986789, 0.00000000000)),
                new ArcData(new Point3d(21.43177677267, 86.45063986789, 0.00000000000),
                    new Point3d(20.45707336288, 87.62430486681, 0.00000000000),
                    new Point3d(19.02122258524, 88.1399295473, 0.00000000000)),
                new ArcData(new Point3d(19.02122258524, 88.1399295473, 0.00000000000),
                    new Point3d(17.23222811099, 88.20998220744, 0.00000000000),
                    new Point3d(15.44323363681, 88.13992954748, 0.00000000000)),
                new ArcData(new Point3d(15.44323363681, 88.13992954748, 0.00000000000),
                    new Point3d(15.37629964075, 90.28639053845, 0.00000000000),
                    new Point3d(15.44323363559, 92.43285152947, 0.00000000000))
            };
        }

        /// <summary>
        /// Возвращает список дуг эскиза рисунка на внешней стороне диска
        /// </summary>
        public List<ArcData> PetalSketchArcs
        {
            get => new List<ArcData>() 
            {
                new ArcData(new Point3d(0.00000000000, 187.81396319307, 0.00000000000),
                    new Point3d(0.00000000000, 187.57705015397, -13.51344554558),
                    new Point3d(0.00000000000, 186.29342713558, -26.96787419372)),
                new ArcData(new Point3d(0.00000000000, 186.29342713558, -26.96787419372),
                    new Point3d(0.00000000000, 185.28516964806, -29.06336944390),
                    new Point3d(0.00000000000, 183.23691660408, -30.16443391632)),
                new ArcData(new Point3d(0.00000000000, 183.23691660408, -30.16443391632),
                    new Point3d(0.00000000000, 130.59627018679, -19.85378699770),
                    new Point3d(0.00000000000, 77.91601734948, -9.74744957416)),
                new ArcData(new Point3d(0.00000000000, 77.91601734948, -9.74744957416),
                    new Point3d(0.00000000000, 75.25013217689, -5.20263457372),
                    new Point3d(0.00000000000, 74.41653717094, 0.00000000000))
            };
        }

        /// <summary>
        /// Возвращает первоначальную высоту эскиза лепестка рисунка
        /// </summary>
        public double PetalSketchHeight => 113.4;

        /// <summary>
        /// Возвращает минимальный диаметр
        /// </summary>
        public double MinDiameter { get => 101.6; }

        /// <summary>
        /// Возвращает максимальный диаметр
        /// </summary>
        public double MaxDiameter { get => 1447.8; }

        /// <summary>
        /// Хранит диаметр
        /// </summary>
        private double _diameter = double.NaN;

        /// <summary>
        /// Устанавливает и возвращает диаметр
        /// </summary>
        public double Diameter 
        {
            get => _diameter;
            set
            {
                _diameter = double.NaN;
                if (!double.IsNaN(value))
                {
                    const string context = "диаметр диска";
                    ValueValidator.AssertNumberInRange(value, MinDiameter,
                        MaxDiameter, context);
                    _diameter = value;
                }
            }
        }

        /// <summary>
        /// Минимальный процент от диаметра диска, 
        /// который может составлять диаметр центрального отверстия
        /// </summary>
        private const double MIN_CENTER_HOLE_PERCENT = 10;

        /// <summary>
        /// Максимальный процент от диаметра диска, 
        /// который может составлять диаметр центрального отверстия
        /// </summary>
        private const double MAX_CENTER_HOLE_PERCENT = 18;

        /// <summary>
        /// Возвращает минимальный диаметр центрального отверстия
        /// </summary>
        public double MinCentralHoleDiameter
        {
            get
            {
                if (double.IsNaN(Diameter))
                {
                    return double.NaN;
                }
                else
                {
                    return Math.Round((Diameter * MIN_CENTER_HOLE_PERCENT 
                        / 100), 3);
                }
            }
        }

        /// <summary>
        /// Возвращает максимальный диаметр центрального отверстия
        /// </summary>
        public double MaxCentralHoleDiameter
        {
            get
            {
                if (double.IsNaN(Diameter))
                {
                    return double.NaN;
                }
                else
                {
                    return Math.Round((Diameter * MAX_CENTER_HOLE_PERCENT 
                        / 100), 3);
                }
            }
        }

        /// <summary>
        /// Диаметр центрального отверстия
        /// </summary>
        private double _centralHoleDiameter = double.NaN;

        /// <summary>
        /// Устанавливает и возвращает 
        /// значение диаметра центрального отверстия
        /// </summary>
        public double CentralHoleDiameter
        {
            get => _centralHoleDiameter;
            set
            {
                _centralHoleDiameter = double.NaN;
                if (!double.IsNaN(value))
                {
                    if (double.IsNaN(Diameter))
                    {
                        throw new ArgumentException("Невозможно рассчитать "
                            + "диапазон допустимых значений диаметра "
                            + "центрального отверстия. \nДиаметру диска "
                            + "присвоено некорректное значение");
                    }
                    const string context = "диаметр " 
                        + "центрального отверстия диска";
                    ValueValidator.AssertNumberInRange(value,
                        MinCentralHoleDiameter, MaxCentralHoleDiameter, 
                        context);
                    _centralHoleDiameter = value;
                }
            }
        }

        /// <summary>
        /// Коэффициент для расчета минимальной посадочной ширины
        /// </summary>
        private const double SKETCH_HEIGTH_TO_WIDTH = 1.524;

        /// <summary>
        /// Возвращает минимальный размер посадочной ширины
        /// </summary>
        public double MinWidth 
        {
            get
            {
                if (double.IsNaN(CentralHoleDiameter))
                {
                    return double.NaN;
                }
                else
                {
                    return Math.Round((Diameter / 2 
                        - CentralHoleDiameter / 2) 
                        / SKETCH_HEIGTH_TO_WIDTH, 3);
                }
            }
        }

        /// <summary>
        /// Возвращает максимальный размер посадочной ширины
        /// </summary>
        public double MaxWidth 
        {
            get
            {
                if (double.IsNaN(CentralHoleDiameter))
                {
                    return double.NaN;
                }
                else
                {
                    return Math.Round(Diameter / 2 
                        - CentralHoleDiameter / 2, 3);
                }
            }
        }

        /// <summary>
        /// Посадочная ширина
        /// </summary>
        private double _width = double.NaN;

        /// <summary>
        /// Устанавливает и возвращает посадочную ширину диска
        /// </summary>
        public double Width 
        {
            get => _width;
            set
            {
                _width = double.NaN;
                if (!double.IsNaN(value))
                {
                    if (double.IsNaN(CentralHoleDiameter))
                    {
                        throw new ArgumentException("Невозможно рассчитать "
                            + "диапазон допустимых значений "
                            + "посадочной ширины диска. \n"
                            + "Возможно, диаметру диска или "
                            + "диаметру центрального отвертия "
                            + "присвоены некорректные значения");
                    }
                    const string context = "посадочную ширину диска";
                    ValueValidator.AssertNumberInRange(value, MinWidth,
                        MaxWidth, context);
                    _width = value;
                }
            }
        }

        /// <summary>
        /// Минимальный процент от половины посадочной ширины диска, 
        /// который может составлять отрицательный вылет
        /// </summary>
        private const double MIN_OFFSET_PERCENT = 5;

        /// <summary>
        /// Возвращает максимальный отрицательный вылет
        /// </summary>
        public double MinOffSet
        {
            get
            {
                if(double.IsNaN(Width))
                {
                    return double.NaN;
                }
                else
                {
                    return Math.Round(-1 * (Width / 2 
                        * MIN_OFFSET_PERCENT / 100), 3);
                }
            }
        }

        /// <summary>
        /// Возвращает максимальный положительный вылет
        /// </summary>
        public double MaxOffSet 
        {
            get
            {
                if (double.IsNaN(Width))
                {
                    return double.NaN;
                }
                else
                {
                    return Math.Round(Width / 2, 3);
                }
            }
        }

        /// <summary>
        /// Вылет диска
        /// </summary>
        private double _offSet = double.NaN;

        /// <summary>
        /// Устанавливает и возвращает вылет диска
        /// </summary>
        public double OffSet
        {
            get => _offSet;
            set
            {
                _offSet = double.NaN;
                if (!double.IsNaN(value))
                {
                    if (double.IsNaN(Width))
                    {
                        throw new ArgumentException("Невозможно рассчитать "
                            + "диапазон допустимых значений вылета. \n"
                            + "Возможно, диаметр диска, "
                            + "диаметр центрального отверстия или \n"
                            + "посадочная ширина заданы неккоректно");
                    }
                    const string context = "вылет диска";
                    ValueValidator.AssertNumberInRange(value, MinOffSet,
                        MaxOffSet, context);
                    _offSet = value;
                }
            }
        }

        /// <summary>
        /// Коэффициент для расчета высоты привалочной плоскости
        /// </summary>
        private const double DRILL_PLACE_COEFFICIENT = 7;

        /// <summary>
        /// Возвращает высоту привалочной поверхности
        /// </summary>
        public double DrillPlaceHeight
        {
            get
            {
                if(double.IsNaN(CentralHoleDiameter))
                {
                    return double.NaN;
                }
                else
                {
                    return ((Diameter - CentralHoleDiameter) / 2) 
                        / DRILL_PLACE_COEFFICIENT;
                }
            }
        }

        /// <summary>
        /// Минимальный процент от высоты привалочной поверхности, 
        /// который может составлять диаметр сверловки 
        /// </summary>
        private const double MIN_DRILL_DIAMETER_PERCENT = 67.0;

        /// <summary>
        /// Максимальный процент от высоты привалочной поверхности, 
        /// который может составлять диаметр сверловки 
        /// </summary>
        private const double MAX_DRILL_DIAMETER_PERCENT = 83.3;

        /// <summary>
        /// Возвращает минимальный диаметр сверловки
        /// </summary>
        public double MinDrillDiameter 
        {
            get
            {
                if(double.IsNaN(DrillPlaceHeight))
                {
                    return double.NaN;
                }
                else
                {
                    return Math.Round(DrillPlaceHeight 
                        * MIN_DRILL_DIAMETER_PERCENT  / 100, 3);
                }
            } 
        }

        /// <summary>
        /// Возвращает максимальный диаметр сверловки
        /// </summary>
        public double MaxDrillDiameter 
        {
            get
            {
                if (double.IsNaN(DrillPlaceHeight))
                {
                    return double.NaN;
                }
                else
                {
                    return Math.Round(DrillPlaceHeight 
                        * MAX_DRILL_DIAMETER_PERCENT / 100, 3);
                }
            }
        }

        /// <summary>
        /// Диаметр сверловки
        /// </summary>
        private double _drillDiameter = double.NaN;

        /// <summary>
        /// Устанавливает и возвращает диаметр сверловки
        /// </summary>
        public double DrillDiameter 
        {
            get => _drillDiameter;
            set
            {
                _drillDiameter = double.NaN;
                if (!double.IsNaN(value))
                {
                    if (double.IsNaN(CentralHoleDiameter))
                    {
                        throw new ArgumentException("Невозможно рассчитать "
                            + "диапазон допустимых значений "
                            + "диаметра сверловки.\n"
                            + "Возможно, диаметр диска / "
                            + "диаметр центрального отверстия "
                            + "заданы некорректно");
                    }
                    const string context = "диаметр сверловки";
                    ValueValidator.AssertNumberInRange(value, 
                        MinDrillDiameter, MaxDrillDiameter, context);
                    _drillDiameter = value;
                }
            }
        }

        /// <summary>
        /// Минимальное количество отверстий
        /// </summary>
        private const int MIN_DRILLINGS_COUNT = 4;

        /// <summary>
        /// Возвращает минимальное количество отверстий
        /// </summary>
        public int MinDrillingsCount
        {
            get
            {
                if (double.IsNaN(DrillDiameter))
                {
                    return int.MinValue;
                }
                else
                {
                    return MIN_DRILLINGS_COUNT;
                }
            }
        }

        /// <summary>
        /// Возвращает максимальное количество отверстий
        /// </summary>
        public int MaxDrillingsCount 
        {
            get
            {
                if (double.IsNaN(DrillDiameter))
                {
                    return int.MaxValue;
                }
                else
                {
                    const double centerX = 0.0;
                    const double centerY = 0.0;
                    double radius = CentralHoleDiameter / 2 
                        + DrillPlaceHeight / 2;
                    int maxDrillingsCount = MIN_DRILLINGS_COUNT;
                    while(true)
                    {
                        if(Сalculator.IsCirclesIntersect(centerX, 
                            centerY, radius,
                            DrillDiameter / 2, maxDrillingsCount))
                        {
                            return maxDrillingsCount - 1;
                        }
                        maxDrillingsCount++;
                    }
                }
            }
        }

        /// <summary>
        /// Количество отверстий
        /// </summary>
        private int _drillingsCount = int.MinValue;

        /// <summary>
        /// Устанавливает и возвращает количество отверстий
        /// </summary>
        public int DrillingsCount 
        {
            get => _drillingsCount;
            set
            {
                _drillingsCount = int.MinValue;
                if (value != int.MinValue)
                {
                    if (double.IsNaN(DrillDiameter))
                    {
                        throw new ArgumentException("Невозможно определить "
                            + "допустимое число отверстий. \n"
                            + "Возможно, диаметр диска, "
                            + "диаметр центрального отверстия или \n"
                            + "диаметр сверловки заданы неккоректно");
                    }
                    const string context = "количество отверстий";
                    ValueValidator.AssertNumberInRange(value,
                        MinDrillingsCount, MaxDrillingsCount, context);
                    _drillingsCount = value;
                }
            }
        }

        /// <summary>
        /// Минимальное количество спиц
        /// </summary>
        private const int MIN_SPOKES_COUNT = 4;

        /// <summary>
        /// Возвращает минимальное количество спиц
        /// </summary>
        public int MinSpokesCount
        {
            get
            {
                if (double.IsNaN(Diameter))
                {
                    return int.MinValue;
                }
                else
                {
                    return MIN_SPOKES_COUNT;
                }
            }
        }

        /// <summary>
        /// Максимальное количество спиц
        /// </summary>
        private const int MAX_SPOKES_COUNT = 18;

        /// <summary>
        /// Возвращает максимальное количество спиц
        /// </summary>
        public int MaxSpokesCount
        {
            get
            {
                if (double.IsNaN(Diameter))
                {
                    return int.MaxValue;
                }
                else
                {
                    return MAX_SPOKES_COUNT;
                }
            }
        }

        /// <summary>
        /// Количество спиц
        /// </summary>
        private int _spokesCount = int.MinValue;

        /// <summary>
        /// Устанавливает и возвращает количество спиц
        /// </summary>
        public int SpokesCount 
        {
            get => _spokesCount;
            set
            {
                _spokesCount = int.MinValue;
                if (value != int.MinValue)
                {
                    if (double.IsNaN(Diameter))
                    {
                        throw new ArgumentException("Невозможно определить "
                            + "допустимое число спиц. \n"
                            + "Диаметр диска задан некорректно.");
                    }
                    const string context = "количество спиц";
                    ValueValidator.AssertNumberInRange(value,
                        MinSpokesCount, MaxSpokesCount, context);
                    _spokesCount = value;
                }
            }
        }
    }
}
