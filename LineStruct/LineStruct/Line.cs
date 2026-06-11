using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Globalization;//для форматирования чисел чтоб была точка

namespace LineStruct
{
    public struct Line
    {
        private const double Tolerance = 1e-13;//для чисел с плавающ тчк такая точность

        public double A { get; set; }
        public double B { get; set; }

        public double AngleInDegrees//угол накл прямой к оси ох
        {
            get
            {
                double angleRad = Math.Atan(A);//арктанг в радианах
                double angleDeg = angleRad * 180.0 / Math.PI;//перевела в градусы

                if (angleDeg <= -90.0 || angleDeg >= 90.0)//проверка угла 
                    throw new InvalidOperationException(
                        "Угол наклона вышел за допустимые пределы (-90°, 90°)");

                return angleDeg;
            }
        }

        public Line(double a, double b) : this()
        {
            A = a;//установка значений
            B = b;
        }

        public override string ToString()
        {
            if (Math.Abs(A) < Tolerance && Math.Abs(B) < Tolerance)//сравниваю с 1e-13, будет совп с осью ох
                return "y = 0";

            if (Math.Abs(A) < Tolerance)//прямая будет паралл ох
                return $"y = {FormatNumber(B)}";

            string aStr = FormatCoefficient(A, "x");//форматирование коэф А

            if (Math.Abs(B) < Tolerance)//прямая проходит через начало координат
                return $"y = {aStr}";

            string bStr = FormatNumber(Math.Abs(B));//вид у=ах+b

            if (B > 0)
            {
                return $"y = {aStr} + {bStr}";
            }
            else
            {
                return $"y = {aStr} - {bStr}";//взяла модуль чтоб было y = ax - |b|
            }

        }

        private string FormatNumber(double value)//вспом метод для форматирования, убрать лишние тчк
        {
            if (Math.Abs(value - Math.Round(value)) < Tolerance)//разница с округлением меньше 1e-13
                return Math.Round(value).ToString(CultureInfo.InvariantCulture);

            return value.ToString(CultureInfo.InvariantCulture);//иначе возвр с тчк
        }

        private string FormatCoefficient(double coeff, string variable)//форматир коэф при х
        {
            if (Math.Abs(coeff - 1) < Tolerance)//если коэф 1, выводим только х
                return variable;
            if (Math.Abs(coeff + 1) < Tolerance)//если коэф -1
                return $"-{variable}";
            return $"{FormatNumber(coeff)}{variable}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Line other)
                return Math.Abs(A - other.A) < Tolerance && //сравниваем A этой прямой с A другой прямой
                       Math.Abs(B - other.B) < Tolerance;

            throw new ArgumentException("Объект для сравнения не является прямой");
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                const int p = 23;
                hash = hash * p + A.GetHashCode();
                hash = hash * p + B.GetHashCode();
                return hash;//получаем хеш для конкретной прямой
            }
        }

        public static bool operator ==(Line x, Line y) => x.Equals(y);
        public static bool operator !=(Line x, Line y) => !x.Equals(y);

        public static Line operator ~(Line line)
        {
            
            if (Math.Abs(line.A) < Tolerance)//проверяю что а не равно 0 т.е не горизонт прямая
            {
                throw new InvalidOperationException(
                    "Операцию ~ нельзя применить к прямой, параллельной оси Ox (a = 0).");
            }
            //условие перп-ти: а1*а2=-1
            double newA = -1.0 / line.A;//новый угл коэф

            double newB = 0.0;//тк прямая через начало коорд

            return new Line(newA, newB);
        }
    }
}