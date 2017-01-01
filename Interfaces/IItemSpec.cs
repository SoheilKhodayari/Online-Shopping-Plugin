using System;
using System.Collections.Generic;

namespace OnlineShopping
{
    interface IItemSpec
    {
        bool addPropertyIfNotExists(string key, object value);
        bool containsProperty(string key);
        KeyValuePair<Dictionary<string, object>, Dictionary<string, object>> getDifferentProperties(ItemSpec otherSpec);
        Dictionary<string, object> getProperties();
        object getProperty(string key);
        Dictionary<string, object> getSameProperties(ItemSpec otherSpec);
        bool hasEqualProperty(string propertyName, ItemSpec otherSpec);
        bool matches(ItemSpec otherSpec);
        bool setProperty(string key, object value);
        bool strictlyMatches(ItemSpec otherSpec);
    }
}
