using System.Collections.Generic;
using UnityEngine;

namespace nFramework.Api{

	public class Data
	{
		List<string> _keys;
		List<string> _values;

        public Data()
        {
            this._keys = new List<string>();
            this._values = new List<string>();
        }

		public Data(List<string> keys, List<string> values)
		{
			this._keys = keys;
			this._values = values;
		}

		public void addData(string key, string value)
		{
			this._keys.Add(key);
			this._values.Add(value);
		}

		public List<string> getKeys()
		{
			return this._keys;
		}

		public List<string> getValues()
		{
			return this._values;
		}
	}
}