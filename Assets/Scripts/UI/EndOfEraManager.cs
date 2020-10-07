using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfEraManager : MonoBehaviour
{
    private static EndOfEraManager _instance;

    public GameObject disastersPanel;
    public GameObject prefab_disaster;
    private IRepository<List<ButtonData>> disastersRepository;
    private IRepository<List<ButtonData>> improvementsRepository;
    public GameObject improvementsPanel;
    public GameObject prefab_improvement;

    public GameObject endOfEraPanel;

    void Start()
    {
        disastersPanel.SetActive(true);
        disastersRepository = new DisastersRepository();
        improvementsRepository = new ImprovementsRepository();
    }
    //singleton
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public static EndOfEraManager Instance { get { return _instance; } }

    public void showDisasters()
    {
        disastersPanel.SetActive(true);

        foreach (Transform child in disastersPanel.transform)
         {
             GameObject.Destroy(child.gameObject);
         }
        foreach (ButtonData disaster in disastersRepository.buttons)
        {
            GameObject go = Instantiate(prefab_disaster, new Vector3(0, 0, 0), Quaternion.identity);
            go.GetComponentsInChildren<Text>()[0].text = disaster.text;
            go.GetComponentsInChildren<Text>()[1].text = disaster.subtext;
            go.GetComponent<Button>().onClick.AddListener(delegate { doDisaster(disaster); });
            go.transform.SetParent(disastersPanel.transform, false);
        }
    }

    private void doDisaster(ButtonData disaster)
    {
        int factor = GameData.currentMainPanelIndex;

        if (GameData.population_abilities.abilities["food_resistance"]<1)
        {
            GameData.food += disaster.affected_food * factor; 
            if (GameData.food < 0) GameData.food = 0;
        }
        if (GameData.population_abilities.abilities["resources_resistance"]<1)
        {
            GameData.resources += disaster.affected_resources * factor;
            if (GameData.resources < 0) GameData.resources = 0;
        }
        if (GameData.population_abilities.abilities["people_resistance"]<1)
        {
            GameData.population_size += disaster.affected_people * factor;
            if (GameData.population_size < 0) GameData.population_size = 0;
        }

        GameData.population_abilities.addChromozome(disaster.affected_chromozome);
        disastersPanel.SetActive(false);
        showImprovements();

    }

    public void showImprovements()
    {
        improvementsPanel.SetActive(true);

        foreach (Transform child in improvementsPanel.transform)
         {
             GameObject.Destroy(child.gameObject);
         }

        foreach (ButtonData improvement in improvementsRepository.buttons)
        {
            GameObject go = Instantiate(prefab_improvement, new Vector3(0, 0, 0), Quaternion.identity);
            go.GetComponentsInChildren<Text>()[0].text = improvement.text;
            go.GetComponentsInChildren<Text>()[1].text = improvement.subtext;
            go.GetComponent<Button>().onClick.AddListener(delegate { doImprovement(improvement); });
            go.transform.SetParent(improvementsPanel.transform, false);
        }
    }

    private void doImprovement(ButtonData improvement)
    {
        int factor = GameData.currentMainPanelIndex;
        GameData.food += improvement.affected_food * factor;
        GameData.resources += improvement.affected_resources * factor;
        GameData.population_size += improvement.affected_people * factor;
        GameData.population_abilities.addChromozome(improvement.affected_chromozome);
        improvementsPanel.SetActive(false);
        endOfEraPanel.SetActive(false);
        SoundManager.Instance.playMainSound();
    }

}
