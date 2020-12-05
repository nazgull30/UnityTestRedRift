using System;

namespace UnityTestRedRift.Util
{
    public class Property<T>
    {
        private T _value;
        public Action<T> OnChanged;
        
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChanged?.Invoke(_value);
            } 
        }    
    }
}