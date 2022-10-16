using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lab_ASP.NET_MVC.Models
{
    public class Triangle : Shape, IComparable<Triangle>
    {
        public double Stb { get; set; }
        public double Stc { get; set; }
        //public string Name
        //{
        //    get
        //    {
        //        return String.Format("\"Треугольник со сторонами {0}, {1} и {2}\"", Sta, Stb, Stc);
        //    }
        //}
        public double Perimeter => Math.Round(St + Stb + Stc);
        override public string Name => $"\"Треугольник со сторонами{St},{Stb} и {Stc}\"";
        public double Area
        {
            get
            {
                double sq = Math.Sqrt(Perimeter / 2 * (Perimeter / 2 - St) * (Perimeter / 2 - Stb) * (Perimeter / 2 - Stc));
                return sq;
            }
        }
        public Triangle(double a, double b, double c)
        {
            St = a;
            Stb = b;
            Stc = c;
        }
        public int CompareTo(Triangle other)
        {
            if (this.Area == other.Area) return 0;
            else if(this.Area > other.Area) return 1;
            else return -1;
        }
    }
    public class Circle : Shape, IComparable<Circle>
    {
        override public string Name
        {
            get
            {
                return String.Format("\"Окружность срадиусом {0}\"", St);
            }
        }
        public Circle(double a)
        {
            St = a;
        }
        public double Dlina
        {
            get
            {
                double p = 2 * Math.PI * St;
                return p;
            }
        }
        public double Area
        {
            get
            {
                double sq = Math.PI * St * St;
                return sq;
            }
        }
        public int CompareTo(Circle other)
        {
            if (this.Area == other.Area) return 0;
            else if (this.Area > other.Area) return 1;
            else return -1;
        }
    }
    public class Shape
    {
        public double St { get; set; }
        virtual public string Name
        {
            get { return String.Format("\"Фигура\""); }
        }
    }
}
