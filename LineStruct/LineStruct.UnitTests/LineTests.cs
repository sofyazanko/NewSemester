using NUnit.Framework;
using System;

namespace LineStruct.UnitTests
{
    [TestFixture]
    public class LineTests
    {
        private const double Tolerance = 1e-13;//точность

        [Test]
        public void ConstructorTest()
        {
            var line = new Line(2.5, -3.0);//создали прямую
            Assert.That(line.A, Is.EqualTo(2.5).Within(Tolerance));//проверка с точностью
            Assert.That(line.B, Is.EqualTo(-3.0).Within(Tolerance));
        }

        [TestCase(0.0, 0.0)]//тест угла наклона
        [TestCase(1.0, 45.0)]
        [TestCase(-1.0, -45.0)]
        [TestCase(1.7320508075688772, 60.0)]
        [TestCase(-1.7320508075688772, -60.0)]
        public void AngleInDegreesTest(double a, double expected)//проверка вычисл угла
        {
            var line = new Line(a, 0.0);
            Assert.That(line.AngleInDegrees, Is.EqualTo(expected).Within(Tolerance));
        }

        [TestCase(2.0, 3.0, "y = 2x + 3")]//сравнение коэф с ожид строкой
        [TestCase(2.0, -3.0, "y = 2x - 3")]
        [TestCase(1.0, 5.0, "y = x + 5")]
        [TestCase(-1.0, 5.0, "y = -x + 5")]
        [TestCase(0.0, 5.0, "y = 5")]
        [TestCase(2.5, 0.0, "y = 2.5x")]
        [TestCase(-2.5, 0.0, "y = -2.5x")]
        [TestCase(0.0, 0.0, "y = 0")]
        [TestCase(1.0, 0.0, "y = x")]
        public void ToStringTest(double a, double b, string expected)//проверка форматир
        {
            var line = new Line(a, b);//созд прямую
            Assert.That(line.ToString(), Is.EqualTo(expected));
        }

        [TestCase(2.0, 3.0, 2.0, 3.0, true)]//тест сравн прямых
        [TestCase(2.0, 3.0, 2.0, 5.0, false)]
        [TestCase(0.0, 0.0, 0.0, 0.0, true)]
        public void Equals_TwoLines_ExpectedResult(double a1, double b1, double a2, double b2, bool expected)
        {
            var line1 = new Line(a1, b1);//1 прямая
            var line2 = new Line(a2, b2);//2 прямая
            Assert.That(line1.Equals(line2), Is.EqualTo(expected));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var line = new Line(1.0, 2.0);
            var wrongObj = new object();//созд объет другого типа не лайн
            Assert.That(() => line.Equals(wrongObj), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCodeTest()
        {
            var x = new Line(2.5, -3.0);
            var y = new Line(2.5, -3.0);
            var z = new Line(2.5, 0.0);

            Assert.That(x.Equals(y), Is.True);
            Assert.That(x.Equals(z), Is.False);
            Assert.That(x.GetHashCode(), Is.EqualTo(y.GetHashCode()));//у равных прямых хеши одинаковые
        }

        [Test]
        public void ComparisonTest()//проверка операторов == и !=
        {
            var x = new Line(1.0, 2.0);
            var y = new Line(1.0, 2.0);
            var z = new Line(3.0, 4.0);

            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }

        [TestCase(2.0, 0.0, -0.5, 0.0)]
        [TestCase(0.5, 0.0, -2.0, 0.0)]
        [TestCase(-4.0, 0.0, 0.25, 0.0)]
        [TestCase(1.0, 5.0, -1.0, 0.0)]
        public void TildeOperatorTest(double a, double b, double expectedA, double expectedB)
        {
            var line = new Line(a, b);//исх прямая
            var perp = ~line;//применила оператор перепендикуляра

            Assert.That(perp.A, Is.EqualTo(expectedA).Within(Tolerance));
            Assert.That(perp.B, Is.EqualTo(expectedB).Within(Tolerance));
        }

        [TestCase(0.0, 5.0)]//если будет горизонт прямая
        [TestCase(0.0, 0.0)]
        public void TildeOperator_ZeroA_ThrowsInvalidOperationException(double a, double b)
        {
            var line = new Line(a, b);
            Assert.That(() => ~line, Throws.InvalidOperationException);//проверила что будет уведомл InvalidOperationException
        }
    }
}