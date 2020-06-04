using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class GameData
{
    public static GameObject mainPanel;
    public static GameObject currentJobPanel;

    public static string name_of_era;
    public static string name_of_subera;

    public static int currentMainPanelIndex = 0;

    public static BigInteger population_size = 3000000;
    public static int resources = 0;
    public static int food = 0;
    public static int energy = 20;

    public static Chromozome population_abilities = new Chromozome();

    public static Dictionary<string, int> achievements;
    

    public static void initAchv()
    {
        achievements = new Dictionary<string, int> { { "Image", 0 }, { "Image (1)", 0 }, { "Image (2)", 0 }, { "Image (3)", 0 }, { "Image (4)", 0 }, { "Image (5)", 0 }, { "Image (6)", 0 }, { "Image (7)", 0 } };
        PlayerPrefs.SetString("achievements", JsonConvert.SerializeObject(achievements));
    }

    public static void restoreEnergy() { energy = 20; }

    public static int getFirstTime()
    {
        return PlayerPrefs.GetInt("first_time");
    }
    public static void saveGame()
    {
        PlayerPrefs.SetString("population_size", population_size.ToString());
        PlayerPrefs.SetInt("resources", resources);
        PlayerPrefs.SetInt("food", food);
        PlayerPrefs.SetInt("energy", energy);
        PlayerPrefs.SetInt("currentMainPanelIndex", currentMainPanelIndex);
        PlayerPrefs.SetString("abilities", JsonConvert.SerializeObject(population_abilities));
    }

    public static void loadGame()
    {
        population_size = BigInteger.Parse(PlayerPrefs.GetString("population_size"));
        //cand se deschide pentru prima data jocul
        if (population_size == 0) population_size = 3000000;
        resources = PlayerPrefs.GetInt("resources");
        food = PlayerPrefs.GetInt("food");
        energy = PlayerPrefs.GetInt("energy");
        currentMainPanelIndex = PlayerPrefs.GetInt("currentMainPanelIndex");
        population_abilities = JsonConvert.DeserializeObject<Chromozome>(PlayerPrefs.GetString("abilities"));
        achievements = JsonConvert.DeserializeObject<Dictionary<string, int>>(PlayerPrefs.GetString("achievements"));

    }

    public static void newGame()
    {
        PlayerPrefs.SetInt("first_time", 1);    
        population_abilities = new Chromozome();
        GameData.population_size = 3000000;
        GameData.resources = 0;
        GameData.food = 0;
        GameData.energy = 20;
        GameData.currentMainPanelIndex = 0;
    }



    public static string getGameAchv()
    {
        string imageName = "Image (7)"; //novice, daca nu intra in nici un if

        if (population_abilities.calculateFitness() == 1)      // daca sunt maximizate toate, nu se va da medalie in parte pentru fiecare
        {
            imageName = "Image (6)";       
            goto FoundNew;
        }

        if (population_abilities.abilities["strength"] == 1)
        {
            imageName = "Image (2)";
            if (achievements[imageName] == 0) //daca este o medalie noua, nu trebuie cautata alta
                goto FoundNew;
        }

        if (population_abilities.abilities["patience"] == 1)
        {
            imageName = "Image";
            if (achievements[imageName] == 0)
                goto FoundNew;
        }

        if (population_abilities.abilities["spirituality"] == 1)
        {
            imageName = "Image (4)";
            if (achievements[imageName] == 0)
                goto FoundNew;
        }

        if (population_abilities.abilities["intelligence"] == 1)
        {
            imageName = "Image (1)";
            if (achievements[imageName] == 0)
                goto FoundNew;
        }

        if (population_abilities.abilities["agility"] == 1)
        {
            imageName = "Image (3)";
            if (achievements[imageName] == 0)
                goto FoundNew;
        }

        if (population_abilities.abilities["resources_resistance"] == 1 &&
            population_abilities.abilities["food_resistance"] == 1 &&
            population_abilities.abilities["people_resistance"] == 1)
        {
            imageName = "Image (5)";
            if (achievements[imageName] == 0)
                goto FoundNew;
        }

        FoundNew:
        achievements[imageName] = 1;
        PlayerPrefs.SetString("achievements", JsonConvert.SerializeObject(achievements));
        return imageName;
    }

}

