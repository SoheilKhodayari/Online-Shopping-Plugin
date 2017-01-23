using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace OnlineShopping
{
    public class ItemSpec : IItemSpec
    {
        [Key]
        public int _Id {get; set;}
        public string _SerializedProperties { get; set; }
        public ItemSpec()
        {

        }
        public ItemSpec(Dictionary<string,Object> properties)
        {
            this._SerializedProperties = JsonConvert.SerializeObject(properties);
        }

        public bool addPropertyIfNotExists(string key, Object value)
        {
            Dictionary<string, Object> properties = this.getProperties();
            if(!properties.ContainsKey(key))
            {
                properties.Add(key, value);
                this._SerializedProperties = JsonConvert.SerializeObject(properties);
                return true;
            }
            return false;
        }
        public bool setProperty(string key, Object value)
        {
            Dictionary<string, Object> properties = this.getProperties();
            if (properties.ContainsKey(key))
            {
                properties[key] = value;
                this._SerializedProperties = JsonConvert.SerializeObject(properties);
                return true;
            }
            return false;
        }
        public Object getProperty(string key)
        {
            Dictionary<string, Object> properties = this.getProperties();
            if (properties.ContainsKey(key))
            {
                return properties[key];
            }
            return null;
        }

        public Dictionary<string, Object> getProperties()
        {   
            if(this._SerializedProperties != null)
            {
                Dictionary<string, Object> properties = JsonConvert.DeserializeObject<Dictionary<string, Object>>(_SerializedProperties);
                return properties;
            }
            return new Dictionary<string, Object>();
        }

        public bool containsProperty(string key)
        {
            return this.getProperties().ContainsKey(key);
        }

        public bool hasEqualProperty(string propertyName, ItemSpec otherSpec)
        {
            if (otherSpec.containsProperty(propertyName) 
                && this.getProperties()[propertyName].Equals(otherSpec.getProperty(propertyName)))
                return true;
            return false;
        }

        public bool matches(ItemSpec otherSpec)
        {
            Dictionary<string, Object> properties = this.getProperties();
            foreach (var property in properties.ToArray())
            {
                string propertyName = property.Key;
                if (!otherSpec.containsProperty(propertyName))
                {
                    continue;
                }
                else if(!properties[propertyName].Equals(otherSpec.getProperty(propertyName)))
                {
                    return false;
                }
            }
            return true;
        }

        public bool strictlyMatches(ItemSpec otherSpec)
        {
            Dictionary<string, Object> properties = this.getProperties();
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

        public Dictionary<string, Object> getSameProperties(ItemSpec otherSpec)
        {
            Dictionary<string, Object> properties = this.getProperties();
            Dictionary<string, Object> sameProperties = new Dictionary<string, Object>();
            foreach (var property in properties.ToArray())
            {
                string propertyName = property.Key;
                if(hasEqualProperty(propertyName, otherSpec))
                {
                    sameProperties.Add(propertyName, properties[propertyName]);
                }
            }
            return sameProperties;
        }
        public Tuple<Dictionary<string, Object>, Dictionary<string, Object>> getDifferentProperties(ItemSpec otherSpec)
        {
            Dictionary<string, Object> properties = this.getProperties();

            string propertyName;
            Dictionary<string, Object> diff = new Dictionary<string, Object>();
            Dictionary<string, Object> otherDiff = new Dictionary<string, Object>();
            Tuple<Dictionary<string, Object>,Dictionary<string, Object>> differences;
            foreach (var property in properties.ToArray())
            {
                propertyName = property.Key;
                if (!hasEqualProperty(propertyName, otherSpec))
                {
                    if (otherSpec.getProperties().ContainsKey(propertyName))
                    {
                        otherDiff.Add(propertyName, otherSpec.getProperty(propertyName));
                    }
                    diff.Add(propertyName, properties[propertyName]);   
                }
            }
            foreach (var property in otherSpec.getProperties().ToArray())
            {
                propertyName = property.Key;
                if (!properties.ContainsKey(propertyName))
                {
                    otherDiff.Add(propertyName, otherSpec.getProperty(propertyName));
                }
            }

            differences = new Tuple<Dictionary<string, Object>,Dictionary<string, Object>>(diff, otherDiff);
            return differences;
        }
    }
}
