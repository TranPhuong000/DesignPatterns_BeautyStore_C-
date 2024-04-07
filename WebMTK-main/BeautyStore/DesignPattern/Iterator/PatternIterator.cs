using BeautyStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.DesignPattern
{
    public class PatternIterator<list> : Iterator<list>
    {
        List<list> _listItems;
        int current = 0;
        int step = 1;

        public PatternIterator(List<list> listItems)
        {
            _listItems = listItems;
        }

        public bool IsDone { get { return current >= _listItems.Count; } }
        public list CurrentIT => _listItems[current];

        public list First()
        {
            current = 0;
            return _listItems[current];
        }

        public list Next()
        {
            current += step;
            if (!IsDone)
            {
                return _listItems[current];
            }
            else
            {
                return default(list);
            }
        }
    }
}