using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 键值类
    /// </summary>
    public class KeyValue
    {
        public KeyValue()
        { }
        public KeyValue(object _key, object _value)
        {
            this.key = _key;
            this.value = _value;
        }
        /// <summary>
        /// 键
        /// </summary>
        public object key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public object value { get; set; }
    }
}
