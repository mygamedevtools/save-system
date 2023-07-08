using System;
using System.Collections.Generic;

namespace MyGameDevTools.Persistence
{
    public class SaveSystem : ISaveSystem
    {
        readonly Dictionary<string, object> _saveData;

        public SaveSystem()
        {
            _saveData = new Dictionary<string, object>();
        }

        public void Set<T>(string key, T value)
        {
            if (!_saveData.ContainsKey(key))
                _saveData.Add(key, value);
            else
                _saveData[key] = value;
        }

        public T Get<T>(string key)
        {
            _saveData.TryGetValue(key, out var value);
            return (T)value;
        }
    }
}