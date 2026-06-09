using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryLibrary
{
    public class Veteran : Serviceman
    {
        public double YearsOfService { get; set; }//выслуга лет
        public double PensionAmount { get; set; }//размер пенсии

        
        public Veteran(string name, string surname, string militaryIDN,
                       string rank, string milUnitNumber,
                       DateTime enlistmentDate, TypeService type,
                       double yearsOfService, double pensionAmount)
                       : base(name, surname, militaryIDN, rank, milUnitNumber, enlistmentDate, type)//то что передаем в базовый класс
        {
            YearsOfService = yearsOfService;
            PensionAmount = pensionAmount;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[3];

            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Ветеран. Выслуга: {YearsOfService} лет. Пенсия: {PensionAmount} руб.";

            return info;
        }
    }
}
