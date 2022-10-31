using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Point
    {
        double x;
        double y;
        public Point()
        {
            x = 0;
            y = 0;
        }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void setPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void setX(double x)
        {
            this.x = x;
        }
        public void setY(double y)
        {
            this.y = y;
        }
        public double getX()
        {
            return this.x;
        }
        public double getY()
        {
            return this.y;
        }
        
    }
}
