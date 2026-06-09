using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryLibrary
{
    public class Headquarters : Serviceman
    {
        public string DistrictName { get; set; }//название округа
        public string Position { get; set; }//должность

        public Headquarters(string name, string surname, string militaryIDN,
                            string rank, string milUnitNumber,
                            DateTime enlistmentDate, TypeService type,
                            string districtName, string position)
                            : base(name, surname, militaryIDN, rank, milUnitNumber, enlistmentDate, type)
        {
            DistrictName = districtName;
            Position = position;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[3];//массив из 3 ячеек

            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Органы управления (штаб). Округ: {DistrictName}. Должность: {Position}.";

            return info;
        }
    }
}
