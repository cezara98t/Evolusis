
using System.Collections.Generic;

public class Chromozome
{
    public double fitness; //trebuie get si set, nu am pus ca sa nu apara in json

    public Dictionary<string, double> genes { get; set; }

    //random init
    public Chromozome()
    {
        fitness = 0;
        genes = new Dictionary<string, double>();
        genes.Add("intelligence", 0);
        genes.Add("health", 0);
        genes.Add("fire_resistance", 0);
        genes.Add("swimming_ability", 0);
        genes.Add("diseases_resistance", 0);
        genes.Add("poison_resistance", 0);
        genes.Add("strength", 0);
        genes.Add("spirituality", 0);
        genes.Add("patience", 0);
        genes.Add("agility", 0);
        List<string> keys = new List<string>(genes.Keys);
        foreach (string key in keys)
        {
            genes[key] = Utils.GetRandomDouble();
            fitness += genes[key];
        }

        fitness /= genes.Count;

    }

    public void calculateFitness()
    {

        List<string> keys = new List<string>(genes.Keys);
        foreach (string key in keys)
        {
            fitness += genes[key];
        }

        fitness /= genes.Count;
    }

    public void mutate()
    {
        List<string> keys = new List<string>(genes.Keys);
        string randomKey = keys[Utils.GetRandomInt(keys.Count)];
        genes[randomKey] = Utils.GetRandomDouble();

    }

}
