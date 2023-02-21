using System;
using System.Collections.Generic;
using System.Text;

namespace PathfinderSystem
{
    public class KeyRegistry : List<string>
    {
        public KeyRegistry(string[] loadList)
        {
            foreach (string curStr in loadList)
                Add(curStr);
        }

        public int this[string key]
        {
            get
            {
                if (!Contains(key))
                    Add(key);

                return IndexOf(key);
            }
        }
    }
}
