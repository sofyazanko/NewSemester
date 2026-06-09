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

    [TestFixture]
    public class CommandStaffTests//это уже к 14 заданию
    {
        [Test]
        public void ConstructorTest()
        {
            var staff = GetTestCommandStaff();

            Assert.That(staff.UnitName, Is.EqualTo("мотострелковый полк"));
            Assert.That(staff.Position, Is.EqualTo("командир батальона"));
        }

        [Test]
        public void GetInfoTest()
        {
            var staff = GetTestCommandStaff();
            var info = staff.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));

            var expectedLines = new[]//построчно пропис информацию
            {
                "Иван Петров",
                $"Военный билет: АБ123456. Звание: майор. Часть: 54321. Поступил: 01.06.2010. Срок службы: {DateTime.Now.Year - 2010} лет. Тип службы: по контракту.",
                "Командный состав. Подразделение: мотострелковый полк. Должность: командир батальона."
            };

            for (int i = 0; i < info.Length; i++)//цикл по строкам массива
                Assert.That(info[i], Is.EqualTo(expectedLines[i]));//сравн каждую строку
        }

        private CommandStaff GetTestCommandStaff()//вспомогат метод
        {
            return new CommandStaff(
                name: "Иван",
                surname: "Петров",
                militaryIDN: "АБ123456",
                rank: "майор",
                milUnitNumber: "54321",
                enlistmentDate: new DateTime(2010, 6, 1),
                type: TypeService.UnderContract,
                unitName: "мотострелковый полк",
                position: "командир батальона"
            );
        }
    }

    
    [TestFixture]
    public class HeadquartersTests
    {
        [Test]
        public void ConstructorTest()
        {
            var hq = GetTestHeadquarters();//создаем штаб

            Assert.That(hq.DistrictName, Is.EqualTo("Западный военный округ"));
            Assert.That(hq.Position, Is.EqualTo("начальник штаба"));
        }

        [Test]
        public void GetInfoTest()
        {
            var hq = GetTestHeadquarters();
            var info = hq.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));

            var expectedLines = new[]//что мы хотим увидеть
            {
                "Сергей Сидоров",
                $"Военный билет: ВГ789012. Звание: полковник. Часть: 001. Поступил: 15.01.2005. Срок службы: {DateTime.Now.Year - 2005} лет. Тип службы: по контракту.",
                "Органы управления (штаб). Округ: Западный военный округ. Должность: начальник штаба."
            };

            for (int i = 0; i < info.Length; i++)
                Assert.That(info[i], Is.EqualTo(expectedLines[i]));
        }

        private Headquarters GetTestHeadquarters()//вспом метод
        {
            return new Headquarters(
                name: "Сергей",
                surname: "Сидоров",
                militaryIDN: "ВГ789012",
                rank: "полковник",
                milUnitNumber: "001",
                enlistmentDate: new DateTime(2005, 1, 15),
                type: TypeService.UnderContract,
                districtName: "Западный военный округ",
                position: "начальник штаба"
            );
        }
    }


    [TestFixture]
    public class VeteranTests
    {
        [Test]
        public void ConstructorTest()
        {
            var veteran = GetTestVeteran();//создаем ветерана

            Assert.That(veteran.YearsOfService, Is.EqualTo(25.0));
            Assert.That(veteran.PensionAmount, Is.EqualTo(35000.0));
        }

        [Test]
        public void GetInfoTest()
        {
            var veteran = GetTestVeteran();
            var info = veteran.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));

            var expectedLines = new[]
            {
                "Алексей Иванов",
                $"Военный билет: ДЕ345678. Звание: сержант. Часть: 12345. Поступил: 20.05.1990. Срок службы: {DateTime.Now.Year - 1990} лет. Тип службы: срочная.",
                "Ветеран. Выслуга: 25 лет. Пенсия: 35000 руб."
            };

            for (int i = 0; i < info.Length; i++)
                Assert.That(info[i], Is.EqualTo(expectedLines[i]));
        }

        private Veteran GetTestVeteran()
        {
            return new Veteran(
                name: "Алексей",
                surname: "Иванов",
                militaryIDN: "ДЕ345678",
                rank: "сержант",
                milUnitNumber: "12345",
                enlistmentDate: new DateTime(1990, 5, 20),
                type: TypeService.Urgent,
                yearsOfService: 25.0,
                pensionAmount: 35000.0
            );
        }
    }
        [TestFixture]
        public class SubdivisionTests//тесты для 15
        {
            MilitarySubdivision unit;
            Serviceman[] servicemen;

            [SetUp]
            public void Setup()//тестовые солдаты
            {
               
                var ivanov = new Serviceman("Иван", "Иванов", "АБ123", "рядовой", "54321", new DateTime(2020, 1, 1), TypeService.Urgent);
                var chernov = new Serviceman("Пётр", "Чернов", "ВГ456", "сержант", "54321", new DateTime(2019, 5, 1), TypeService.UnderContract);
                var bystrov = new Serviceman("Сидор", "Быстров", "ДЕ789", "лейтенант", "10001", new DateTime(2021, 3, 1), TypeService.Urgent);
                var belov = new Serviceman("Алексей", "Белов", "ЖК012", "рядовой", "54321", new DateTime(2022, 7, 1), TypeService.Urgent);
                var smirnov = new Serviceman("Николай", "Смирнов", "ЗЛ345", "капитан", "54321", new DateTime(2018, 9, 1), TypeService.UnderContract);

                servicemen = new Serviceman[] { ivanov, chernov, bystrov, belov, smirnov, ivanov };//проверка на двух ивановых

               
                unit = new MilitarySubdivision("Мотострелковый полк", "54321", servicemen);//созд подразд
            }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(unit.Name, Is.EqualTo("Мотострелковый полк"));
            Assert.That(unit.UnitNumber, Is.EqualTo("54321"));

            var list = unit.ToList();  

            foreach (var serviceman in servicemen)
            {
                if (serviceman.MilUnitNumber != unit.UnitNumber)
                    continue;  //пропустить солдат не из нашей части

                Assert.That(list.Contains(serviceman) &&
                            list.IndexOf(serviceman) == list.LastIndexOf(serviceman), Is.True);
            }
        }

        [Test]
            public void CountTest()
            {
                Assert.That(unit.Count, Is.EqualTo(4));//должно быть 4 солдата
            }

            [Test]
            public void IEnumerableTest()
            {
                int i = 0;
                
                Serviceman[] expected = new Serviceman[]
                {
                servicemen[0], //сначала иванов
                servicemen[1], //потом чернов
                servicemen[3], 
                servicemen[4]  
                };

                foreach (var serviceman in unit)
                {
                    Assert.That(serviceman, Is.SameAs(expected[i]));//перебираю по порядку солдат
                    i++;
                }
                Assert.That(i, Is.EqualTo(4));
            }
        }

        [TestFixture]
        public class ServicemanCompareTests
        {
            [Test]
            public void CompareToTest()
            {
                
                var ivanov = new Serviceman("Иван", "Иванов", "АБ123", "рядовой", "54321", new DateTime(2020, 1, 1), TypeService.Urgent);
                var chernov = new Serviceman("Пётр", "Чернов", "ВГ456", "сержант", "54321", new DateTime(2019, 5, 1), TypeService.UnderContract);
                var bystrov = new Serviceman("Сидор", "Быстров", "ДЕ789", "лейтенант", "10001", new DateTime(2021, 3, 1), TypeService.Urgent);
                var belov = new Serviceman("Алексей", "Белов", "ЖК012", "рядовой", "54321", new DateTime(2022, 7, 1), TypeService.Urgent);
                var smirnov = new Serviceman("Николай", "Смирнов", "ЗЛ345", "капитан", "54321", new DateTime(2018, 9, 1), TypeService.UnderContract);

               
                Assert.That(bystrov.CompareTo(ivanov), Is.LessThan(0));

                Assert.That(ivanov.CompareTo(chernov), Is.LessThan(0));

                Assert.That(ivanov.CompareTo(belov), Is.GreaterThan(0));

                Assert.That(ivanov.CompareTo(smirnov), Is.LessThan(0));

                Assert.That(ivanov.CompareTo(ivanov), Is.EqualTo(0));
            }
        }

}
