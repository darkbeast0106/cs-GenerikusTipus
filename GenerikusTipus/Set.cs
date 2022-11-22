using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace GenerikusTipus
{
    public class Set<T>
    {
        private List<T> elements;

        public Set()
        {
            this.elements = new List<T>();
        }

        public bool Add(T element)
        {
            bool successful = false;
            if (!this.elements.Contains(element))
            {
                this.elements.Add(element);
                successful = true;
            }
            return false;
        }

        public bool Remove(T element)
        {
            return this.elements.Remove(element);
        }

        public int Size
        {
            get => this.elements.Count;
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public bool Contains(T element)
        {
            return this.elements.Contains(element);
        }

        public bool IsEmpty()
        {
            return this.elements.Count == 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Set<T>)) return false;
            Set<T> other = (Set<T>)obj;

            if (other.Size != this.Size) return false;
            foreach (T element in this.elements)
            {
                if (!other.Contains(element))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPartOf(Set<T> other)
        {
            if (this.Size > other.Size) return false;

            foreach (T element in this.elements)
            {
                if (!other.Contains(element))
                {
                    return false;
                }
            }
            return true;
        }

        public Set<T> Unio(Set<T> other)
        {
            Set<T> unio = new Set<T>();
            foreach (T element in this.elements)
            {
                unio.Add(element);
            }
            foreach (T element in other.elements)
            {
                unio.Add(element);
            }
            return unio;
        }

        public Set<T> Intersection(Set<T> other)
        {
            Set<T> intersection = new Set<T>();
            foreach(T element in this.elements)
            {
                if (other.Contains(element))
                {
                    intersection.Add(element);
                }
            }
            return intersection;
        }

        public Set<T> Different(Set<T> other)
        {
            Set<T> different = new Set<T>();
            foreach (T element in this.elements)
            {
                if (!other.Contains(element))
                {
                    different.Add(element);
                }
            }
            return different;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (T element in this.elements)
            {
                stringBuilder.AppendLine(element.ToString());
            }
            return stringBuilder.ToString().Trim();
        }
    }
}
