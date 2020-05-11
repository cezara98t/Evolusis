using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public static int population_size = 1000;
    public static int resources = 0;
    public static int food = 0;
    public static int energy = 20;

    public static Chromozome population_abilities = new Chromozome();

    public static Dictionary<string, int> achievements = new Dictionary<string, int> { { "Image", 1 }, {"Image (1)", 0 }, { "Image (2)", 1 }, { "Image (3)", 0 }, { "Image (4)", 0 }, { "Image (5)", 0 }, { "Image (6)", 0 }, { "Image (7)", 0 } };
    
    public static string getGameAchv()
    {
        if (population_abilities.abilities["strength"] == 1)
        {
            achievements["Image (3)"] = 1;
            return "Image (3)";
        }
        return "Image (4)";
    }

    public static void restoreEnergy() { energy = 20; }

    public static int getFirstTime()
    {
        return PlayerPrefs.GetInt("first_time");
    }
    public static void saveGame()
    {
        PlayerPrefs.SetInt("population_size", population_size);
        PlayerPrefs.SetInt("resources", resources);
        PlayerPrefs.SetInt("food", food);
        PlayerPrefs.SetInt("energy", energy);
        PlayerPrefs.SetInt("currentMainPanelIndex", currentMainPanelIndex);
        PlayerPrefs.SetString("abilities", JsonConvert.SerializeObject(population_abilities));
    }

    public static void loadGame()
    {
        population_size = PlayerPrefs.GetInt("population_size");
        //cand se deschide pentru prima data jocul
        if (population_size == 0) population_size = 1000;
        resources = PlayerPrefs.GetInt("resources");
        food = PlayerPrefs.GetInt("food");
        energy = PlayerPrefs.GetInt("energy");
        currentMainPanelIndex = PlayerPrefs.GetInt("currentMainPanelIndex");
        population_abilities = JsonConvert.DeserializeObject<Chromozome>(PlayerPrefs.GetString("abilities"));

    }

    public static void newGame()
    {
        PlayerPrefs.SetInt("first_time", 1);    
        population_abilities = new Chromozome();
        GameData.population_size = 1000;
        GameData.resources = 0;
        GameData.food = 0;
        GameData.energy = 20;
        GameData.currentMainPanelIndex = 0;
    }

}

