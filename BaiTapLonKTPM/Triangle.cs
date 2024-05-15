using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonKTPM_13_Loc
{
    public enum TypeOfTriangle
    {
        NormalTriangle,
        IsoscelesTriangle,
        EquilateralTriangle,
        RightTriangle,
        IsoscelesRightTriangle
    }
    public class Triangle
    {
        private double a_13_loc, b_13_loc, c_13_loc;

        public Triangle(double a, double b, double c)
        {
            if (a > 0 && b > 0 && c > 0)
                if (Triangle.isTriangle(a, b, c))
                {
                    this.a_13_loc = a;
                    this.b_13_loc = b;
                    this.c_13_loc = c;
                }
                else
                {
                    throw new ArgumentException("Invalid triangle: The given sides cannot form a triangle.");
                }
            else
                throw new FormatException();
        }


        //check if this is a triangle
        public static bool isTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
        
        //calculate the perimeter
        public double getPerimeter()
        {
            return this.a_13_loc + this.b_13_loc + this.c_13_loc;
        }

        //calculate the acreage
        public double getAcreage()
        {
            double halfPerimeter = this.getPerimeter() / 2.0;
            double acreage = Math.Sqrt(halfPerimeter * (halfPerimeter - this.a_13_loc) * (halfPerimeter - this.b_13_loc) * (halfPerimeter - this.c_13_loc));
            return Math.Round(acreage, 2);
        }

        //check if this is an isosceles triangle
        public bool isIsoscelesTriangle()
        {
            return this.a_13_loc == this.b_13_loc || this.a_13_loc == this.c_13_loc || this.b_13_loc == this.c_13_loc;
        }

        //check if this is an equilateral triangle
        public bool isEquilateralTriangle()
        {
            return this.a_13_loc == this.b_13_loc && this.a_13_loc == this.c_13_loc;
        }

        //check if this is a right triangle
        public bool isRightTriangle()
        {
            double maxSide = Math.Max(Math.Max(this.a_13_loc, this.b_13_loc), this.c_13_loc);
            double minSide = Math.Min(Math.Min(this.a_13_loc, this.b_13_loc), this.c_13_loc);
            double midSide = this.a_13_loc + this.b_13_loc + this.c_13_loc - maxSide - minSide;
            double epsilon = 0000.1;
            return Math.Abs(maxSide * maxSide - (midSide * midSide + minSide * minSide)) < epsilon;
        }

        //check the type of this triangle
        public TypeOfTriangle getType()
        {
            if (this.isRightTriangle())
            {
                if (this.isIsoscelesTriangle())
                {
                    return TypeOfTriangle.IsoscelesRightTriangle;
                }
                else
                {
                    return TypeOfTriangle.RightTriangle;
                }    
            }
            else
            {
                if (this.isEquilateralTriangle())
                {
                    return TypeOfTriangle.EquilateralTriangle;
                }
                else if (this.isIsoscelesTriangle())
                {
                    return TypeOfTriangle.IsoscelesTriangle;
                }
            }
            return TypeOfTriangle.NormalTriangle;
        }


        public string toString()
        {
            switch (this.getType())
            {
                case TypeOfTriangle.NormalTriangle:
                    return "Tam giác thường";
                case TypeOfTriangle.RightTriangle:
                    return "Tam giác vuông";
                case TypeOfTriangle.IsoscelesRightTriangle:
                    return "Tam giác vuông cân";
                case TypeOfTriangle.IsoscelesTriangle:
                    return "Tam giác cân";
                case TypeOfTriangle.EquilateralTriangle:
                    return "Tam giác đều";
                default:
                    return "";
            }
        }
    }
}
