using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderSystem
{
    public class Equipment
    {
        public string name;
        public float weight;
        public float value;
    }

    public class EquipmentDatabase : SortedList<string, Equipment>
    {
        public EquipmentDatabase()
        {
            Weapon.AddWeapons(this);
        }

        public List<T> GetAll<T>() where T : Equipment
        {
            List<T> result = new List<T>();

            foreach (Equipment curItem in Values)
            {
                if (curItem is T)
                    result.Add((T)curItem);
            }

            return result;
        }

        public void Add(Equipment addMe)
        {
            Add(addMe.name, addMe);
        }
    }
}
