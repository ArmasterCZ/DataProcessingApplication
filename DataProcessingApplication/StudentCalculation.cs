using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingApplication
{
    /// <summary>
    /// Calculate information like average, median, modus from basic models
    /// </summary>
    class StudentCalculation
    {
        public static int WeightMath { get; set; } = 40;

        public static int WeightPhys { get; set; } = 35;

        public static int WeightEngl { get; set; } = 25;

        public static int CalcAverageAll(StudentModel studentModel)
        {
            int mathAverage = studentModel.Math    * WeightMath / 100;
            int physAverage = studentModel.Physics * WeightPhys / 100;
            int englAverage = studentModel.English * WeightEngl / 100;

            return mathAverage + physAverage + englAverage;
        }

        public static int CalcAverageMath(List<StudentModel> students)
        {
            if (students.Count() > 0)
            {
                int sum = students.Sum(s => s.Math);
                return sum / students.Count();
            }
            else
            {
                return 0;
            }

        }

        public static int CalcAveragePhys(List<StudentModel> students)
        {
            if (students.Count() > 0)
            {
                int sum = students.Sum(s => s.Physics);
                return sum / students.Count();
            }
            else
            {
                return 0;
            }

        }

        public static int CalcAverageEngl(List<StudentModel> students)
        {
            if (students.Count() > 0)
            {
                int sum = students.Sum(s => s.English);
                return sum / students.Count();
            }
            else
            {
                return 0;
            }

        }

        public static double CalcMedianAll(List<StudentModel> students)
        {
            if (students.Count() > 0)
            {
                List<int> allNumbers = new List<int>();
                foreach (var student in students)
                {
                    allNumbers.Add(student.Math);
                    allNumbers.Add(student.Physics);
                    allNumbers.Add(student.English);
                }

                return CalcMedian(allNumbers);
            }
            else
            {
                return 0;
            }

        }

        public static double CalcMedianMath(List<StudentModel> students)
        {
            if (students.Count() > 0)
            {
                List<int> allNumbers = new List<int>();
                foreach (var student in students)
                {
                    allNumbers.Add(student.Math);
                }

                return CalcMedian(allNumbers);
            }
            else
            {
                return 0;
            }

        }

        public static double CalcMedianPhys(List<StudentModel> students)
        {
            if (students.Count() > 0)
            {
                List<int> allNumbers = new List<int>();
                foreach (var student in students)
                {
                    allNumbers.Add(student.Physics);
                }

                return CalcMedian(allNumbers);
            }
            else
            {
                return 0;
            }

        }

        public static double CalcMedianEngl(List<StudentModel> students)
        {
            if (students.Count() > 0)
            {
                List<int> allNumbers = new List<int>();
                foreach (var student in students)
                {
                    allNumbers.Add(student.English);
                }

                return CalcMedian(allNumbers);
            }
            else
            {
                return 0;
            }

        }

        private static double CalcMedian(List<int> inputNumbers)
        {
            //order list
            inputNumbers = inputNumbers.OrderBy(i => i).ToList();

            double median = 0;
            if (inputNumbers.Count() % 2 > 0)
            {
                //odd
                median = (double)inputNumbers[(inputNumbers.Count() - 1) / 2];
            }
            else
            {
                //even
                int middle1 = inputNumbers[inputNumbers.Count() / 2];
                int middle2 = inputNumbers[(inputNumbers.Count() / 2) -1];
                median = (double)(middle1 + middle2) / 2;
            }

            return median;
        }

        public static List<int> CalcModusMath(List<StudentModel> students)
        {
            var groupedMath = students.GroupBy(s => s.Math).OrderByDescending(g => g.Count());
            int occurCountMath = groupedMath.FirstOrDefault().Count();
            var modusMath = groupedMath.Where(g => g.Count() == occurCountMath).Select(n => n.Key).ToList();
            return modusMath;
        }

        public static List<int> CalcModusPhys(List<StudentModel> students)
        {
            var groupedPhys = students.GroupBy(s => s.Physics).OrderByDescending(g => g.Count());
            int occurCountPhys = groupedPhys.FirstOrDefault().Count();
            var modusPhys = groupedPhys.Where(g => g.Count() == occurCountPhys).Select(n => n.Key).ToList();
            return modusPhys;
        }

        public static List<int> CalcModusEngl(List<StudentModel> students)
        {
            var groupedEngl = students.GroupBy(s => s.English).OrderByDescending(g => g.Count());
            int occurCountEngl = groupedEngl.FirstOrDefault().Count();
            var modusEngl = groupedEngl.Where(g => g.Count() == occurCountEngl).Select(n => n.Key).ToList();
            return modusEngl;
        }
    }
}
