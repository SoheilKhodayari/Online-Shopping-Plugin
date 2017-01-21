using System;
using System.Collections.Generic;
namespace OnlineShopping
{
    public interface IItemSpec
    {
        bool addPropertyIfNotExists(string key, object value);
        bool containsProperty(string key);
        Dictionary<string, object> getProperties();
        object getProperty(string key);
        bool setProperty(string key, object value);
        bool hasEqualProperty(string propertyName, ItemSpec otherSpec);
        bool matches(ItemSpec otherSpec);
        bool strictlyMatches(ItemSpec otherSpec);
        Tuple<Dictionary<string, object>, Dictionary<string, object>> getDifferentProperties(ItemSpec otherSpec);
        Dictionary<string, object> getSameProperties(ItemSpec otherSpec);


    }
}
