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

        [NotMapped]
        public Dictionary<string, Object> _Properties;

        public string _PropertiesDB { get; set; }


        public void SyncPropertiesFromSerializations()
        {
            this._Properties = JsonConvert.DeserializeObject<Dictionary<string, Object>>(_PropertiesDB);
        }
        public void SyncPropertiesToSerializations()
        {
            this._PropertiesDB = JsonConvert.SerializeObject(this._Properties);
        }
        public ItemSpec()
        {
            this._Properties = new Dictionary<string, Object>();
        }
        public ItemSpec(Dictionary<string,Object> properties)
        {
            this._Properties = properties;
        }

        public bool addPropertyIfNotExists(string key, Object value)
        {
            if(!this._Properties.ContainsKey(key))
            {
                this._Properties.Add(key, value);
                return true;
            }
            return false;
        }
        public bool setProperty(string key, Object value)
        {
            if (this._Properties.ContainsKey(key))
            {
                this._Properties[key] = value;
                return true;
            }
            return false;
        }
        public Object getProperty(string key)
        {
            if (this._Properties.ContainsKey(key))
            {
                return this._Properties[key];
            }
            return null;
        }

        public Dictionary<string, Object> getProperties()
        {
            return this._Properties;
        }

        public bool containsProperty(string key)
        {
            return this._Properties.ContainsKey(key);
        }

        public bool hasEqualProperty(string propertyName, ItemSpec otherSpec)
        {
            if (otherSpec.containsProperty(propertyName) 
                && this._Properties[propertyName].Equals(otherSpec.getProperty(propertyName)))
                return true;
            return false;
        }

        public bool matches(ItemSpec otherSpec)
        {
            foreach (var property in this._Properties.ToArray())
            {
                string propertyName = property.Key;
                if (!otherSpec.containsProperty(propertyName))
                {
                    continue;
                }
                else if(!this._Properties[propertyName].Equals(otherSpec.getProperty(propertyName)))
                {
                    return false;
                }
            }

            return true;
        }

        public bool strictlyMatches(ItemSpec otherSpec)
        {
            foreach (var property in this._Properties.ToArray())
            {
                string propertyName = property.Key;
                if (!this._Properties[propertyName].Equals(otherSpec.getProperty(propertyName)))
                {
                    return false;
                }
            }

            return true;
        }

        public Dictionary<string, Object> getSameProperties(ItemSpec otherSpec)
        {
            Dictionary<string, Object> sameProperties = new Dictionary<string, Object>();
            foreach (var property in this._Properties.ToArray())
            {
                string propertyName = property.Key;
                if(hasEqualProperty(propertyName, otherSpec))
                {
                    sameProperties.Add(propertyName, this._Properties[propertyName]);
                }
            }
            return sameProperties;
        }
        public Tuple<Dictionary<string, Object>, Dictionary<string, Object>> getDifferentProperties(ItemSpec otherSpec)
        {
            Dictionary<string, Object> diff = new Dictionary<string, Object>();
            Dictionary<string, Object> otherDiff = new Dictionary<string, Object>();
            Tuple<Dictionary<string, Object>,Dictionary<string, Object>> differences;
            foreach (var property in this._Properties.ToArray())
            {
                string propertyName = property.Key;
                if (!hasEqualProperty(propertyName, otherSpec))
                {
                    diff.Add(propertyName, this._Properties[propertyName]);
                }
            }
            foreach (var property in otherSpec.getProperties().ToArray())
            {
                string propertyName = property.Key;
                if (!hasEqualProperty(propertyName, this))
                {
                    otherDiff.Add(propertyName, otherSpec.getProperty(propertyName));
                }
            }

            differences = new Tuple<Dictionary<string, Object>,Dictionary<string, Object>>(diff, otherDiff);
            return differences;
        }
    }
}
