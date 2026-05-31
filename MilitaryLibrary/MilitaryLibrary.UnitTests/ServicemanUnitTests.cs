using System;
using NUnit.Framework;
using MilitaryLibrary;

namespace MilitaryLibrary.UnitTests
{
    [TestFixture]
    public class ServicemanUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var soldier = CreateTestServiceman();//создаем солдата 

            Assert.That(soldier.Name, Is.EqualTo("Иван"));
            Assert.That(soldier.Surname, Is.EqualTo("Петров"));
            Assert.That(soldier.MilitaryIDN, Is.EqualTo("АБ123456"));
            Assert.That(soldier.Rank, Is.EqualTo("рядовой"));
            Assert.That(soldier.MilUnitNumber, Is.EqualTo("54321"));
            Assert.That(soldier.EnlistmentDate.ToShortDateString(), Is.EqualTo("01.06.2020"));
            Assert.That(soldier.Type, Is.EqualTo(TypeService.Urgent));
            Assert.That(soldier.ServiceTime, Is.EqualTo(DateTime.Now.Year - 2020));
        }

        [Test]
        public void GetInfoTest()
        {
            var soldier = CreateTestServiceman();
            var info = soldier.GetInfo();//получаем массив с информацией

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("Иван Петров"));
            Assert.That($"Военный билет: АБ123456. Звание: рядовой. Часть: 54321. Поступил: 01.06.2020. Срок службы: {DateTime.Now.Year - 2020} лет. Тип службы: срочная.",
                Is.EqualTo(info[1]));
        }
        private Serviceman CreateTestServiceman()
        {
            return new Serviceman("Иван", "Петров", "АБ123456", "рядовой", "54321", new DateTime(2020, 6, 1), TypeService.Urgent);
        }
    }
}