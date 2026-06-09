using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryLibrary
{
    public class MilitarySubdivision : IEnumerable<Serviceman>
    {
        public string Name { get; set; }//назв подразделения
        public string UnitNumber { get; set; }//номер части
        public int Count => personnel.Count;//кол-во военнослуж, вычисл из размера списка

        private List<Serviceman> personnel;//закрыт поле список военнослуж

        public MilitarySubdivision(string name, string unitNumber, IEnumerable<Serviceman> servicemen)//конструктор
        {
            Name = name;
            UnitNumber = unitNumber;
            personnel = new List<Serviceman>();//созд пуст список для солдат

            foreach (var serviceman in servicemen)
            {
                
                if (serviceman.MilUnitNumber == unitNumber)//фильтр по ном части
                {
                   
                    if (!personnel.Any(s => s.MilitaryIDN == serviceman.MilitaryIDN))//чтоб не было дубликатов по ном воен бил
                    {
                        personnel.Add(serviceman);
                    }
                }
            }
        }

        public IEnumerator<Serviceman> GetEnumerator() => personnel.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
