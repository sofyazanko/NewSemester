using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryLibrary
{
    public class CommandStaff : Serviceman
    {
        public string UnitName { get; set; }//назв подразделения
        public string Position { get; set; }//должность

        public CommandStaff(string name, string surname, string militaryIDN,
                            string rank, string milUnitNumber,
                            DateTime enlistmentDate, TypeService type,
                            string unitName, string position)
                            : base(name, surname, militaryIDN, rank, milUnitNumber, enlistmentDate, type)
        {
            UnitName = unitName;
            Position = position;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[3];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Командный состав. Подразделение: {UnitName}. Должность: {Position}.";
            return info;
        }
    }
}