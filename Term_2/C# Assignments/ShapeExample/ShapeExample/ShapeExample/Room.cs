using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment03
{
    
    public class Room : ICloneable
    {
        private String name; //name of room
        private Shape shape; //geometric shape of room
        public Room(String name, Shape shape)
        {
            this.name = name;
            this.shape = shape;
        }

        public Room(Room roomToCopy)
        {
            this.name = roomToCopy.name;
            this.shape = (Shape) roomToCopy.shape.Clone();
        }

        public object Clone()
        {
            return new Room(this);
        }

        public override string ToString()
        {
            return String.Format("Room {0}\n", name) + shape;
        }

        public double GetArea()
        {
            return shape.CalcArea();
        }

        public double GetPerimeter()
        {
            return shape.CalcPerimeter();
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public String GetName()
        {
            return this.name;
        }

        public void SetShape(Shape shape)
        {
            this.shape = shape;
        }

        public Shape GetShape()
        {
            return (Shape) this.shape.Clone();
        }
    }
}
