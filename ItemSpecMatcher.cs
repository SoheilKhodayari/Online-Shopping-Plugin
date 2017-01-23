using OnlineShopping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    class ItemSpecMatcher: IMatchStrategy
    {
        public bool matches(ItemSpec thisSpec, ItemSpec otherSpec)
        {
            Dictionary<string, Object> properties = thisSpec.getProperties();
            foreach (var property in properties.ToArray())
            {
                string propertyName = property.Key;
                if (!otherSpec.containsProperty(propertyName))
                {
                    continue;
                }
                else if (!properties[propertyName].Equals(otherSpec.getProperty(propertyName)))
                {
                    return false;
                }
            }
            return true;
        }
        public bool strictlyMatches(ItemSpec thisSpec, ItemSpec otherSpec)
        {
            Dictionary<string, Object> properties = thisSpec.getProperties();
            foreach (var property in properties.ToArray())
            {
                string propertyName = property.Key;
                if (!properties[propertyName].Equals(otherSpec.getProperty(propertyName)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
