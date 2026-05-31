using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryLibrary
{
    public class Serviceman
    {

        public string Name { get; set; }//имя
        public string Surname { get; set; }//фамилия
        public readonly string MilitaryIDN;//номер воен бил
        public string Rank { get; set; }//звание
        public string MilUnitNumber { get; set; }//номер воин части
        public DateTime EnlistmentDate { get; set; }//дата поступления
        public readonly TypeService Type;//тип службы
        public int ServiceTime => DateTime.Now.Year - EnlistmentDate.Year;//считаем срок службы


        public Serviceman(string name, string surname, string militaryIDN,
                          string rank, string milUnitNumber,
                          DateTime enlistmentDate, TypeService type)
        {
            if (enlistmentDate > DateTime.Now)
                throw new ArgumentException("Дата поступления не может быть в будущем");

            Name = name;
            Surname = surname;
            MilitaryIDN = militaryIDN;
            Rank = rank;
            MilUnitNumber = milUnitNumber;
            EnlistmentDate = enlistmentDate;
            Type = type;
        }

        public virtual string[] GetInfo()//получение инф-ции
        {
            var info = new string[2];//массив на 2 ячейки
            info[0] = $"{Name} {Surname}";

            string typeName;
            if (Type == TypeService.Urgent)
                typeName = "срочная";
            else
                typeName = "по контракту";

            info[1] = $"Военный билет: {MilitaryIDN}. " +
                      $"Звание: {Rank}. " +
                      $"Часть: {MilUnitNumber}. " +
                      $"Поступил: {EnlistmentDate:d}. " +//d для даты
                      $"Срок службы: {ServiceTime} лет. " +
                      $"Тип службы: {typeName}.";

            return info;
        }
    }
}