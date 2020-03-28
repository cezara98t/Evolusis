using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HousingRepository
{
    public List<Housing> housings { get; }

    public void add(int era)
    {
        //la fiecare era gasesti formula????????? vezi mai incolo tipuri diferite smth sau citit din fisier sau enum
        for (int i = 0; i < era*5+1; i++)
        {
            Housing h = new Housing(5,0, 0, 0);
            housings.Add(h);
        }
    }

    public int destroy(double fire_resistance, double water_resistance, double shake_resistance)
    {
        int people_dead = 0;
        foreach (Housing h in housings)
        {
            if (h.fire_resistance < fire_resistance || h.water_resistance < water_resistance || h.shake_resistance <shake_resistance)
            {
                people_dead += h.capacity;
                housings.Remove(h); //vezi daca nu cumva trebuie id ca elimina toate la fel
            }
        }
        return people_dead;
    }
}


