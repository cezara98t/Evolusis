using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Housing
{
    public int capacity;
    public double fire_resistance;
    public double water_resistance;
    public double shake_resistance;

    public Housing(int capacity, double fire_resistance, double water_resistance, double shake_resistance)
    {
        this.capacity = capacity;
        this.fire_resistance = fire_resistance;
        this.water_resistance = water_resistance;
        this.shake_resistance = shake_resistance;
    }
}

