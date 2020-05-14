
using System.Collections.Generic;
using UnityEngine;

public class Chromozome
{

    public Dictionary<string, double> abilities { get; set; }

    //random init
    public Chromozome()
    {
        abilities = new Dictionary<string, double>();
        abilities.Add("intelligence", 0);
        abilities.Add("strength", 0);
        abilities.Add("spirituality", 0);
        abilities.Add("patience", 0);
        abilities.Add("agility", 0);
        abilities.Add("food_resistance", 0);
        abilities.Add("resources_resistance", 0);
        abilities.Add("people_resistance", 0);
        List<string> keys = new List<string>(abilities.Keys);
        foreach (string key in keys)
        {
            abilities[key] = RandomGenerator.GetRandomDouble(0,0.2);
        }

    }

    public double calculateFitness()
    {
        double fitness = 0;
        List<string> keys = new List<string>(abilities.Keys);
        foreach (string key in keys)
        {
            fitness += abilities[key];
        }

        fitness /= abilities.Count;
        return fitness;
    }

  
    public void addChromozome(Chromozome other)
    {
        List<string> keys = new List<string>(abilities.Keys);
        foreach (string key in keys)
        {
            abilities[key] +=  other.abilities[key];
            if (abilities[key] < 0) abilities[key] = 0;
            if (abilities[key] > 1) abilities[key] = 1;
        }
    }
    
}
