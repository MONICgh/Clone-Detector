using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace task1
{
    public class DummyObject
    {
        public object data;

        public DummyObject() : this(0) {}

        public DummyObject(object obj) {
            this.data = obj;
        }

        public object Value()
        {
            return data;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is DummyObject)
            {
                return data == ((DummyObject)obj).data;
            }
            return false;
        }
    }
}
