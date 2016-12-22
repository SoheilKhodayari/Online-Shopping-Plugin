using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    class ItemSpec
    {
        private Dictionary<string, Object> _Properties;
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
        
    }
}
