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
        bool hasEqualProperty(string propertyName, IItemSpec otherSpec);
        bool matches(IItemSpec otherSpec);
        bool strictlyMatches(IItemSpec otherSpec);
        KeyValuePair<Dictionary<string, object>, Dictionary<string, object>> getDifferentProperties(IItemSpec otherSpec);
        Dictionary<string, object> getSameProperties(IItemSpec otherSpec);


    }
}
