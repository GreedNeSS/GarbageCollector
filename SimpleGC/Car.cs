using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC
{
    class Car
    {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }

        public Car()
        {

        }

        public Car(string name, int speed)
        {
            PetName = name;
            CurrentSpeed = speed;
        }

        public override string ToString() => $"[PetName = {PetName}, CurrentSpeed = {CurrentSpeed}]";
    }
}
