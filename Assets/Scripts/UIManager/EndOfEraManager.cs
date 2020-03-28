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
    public DisastersRepository disastersRepository;

    public ImprovementsRepository improvementsRepository;
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
        foreach (DisasterButtonData disaster in disastersRepository.buttons)
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
        GameData.food += disaster.affected_food;
        GameData.resources += disaster.affected_resources;
        GameData.population_size += disaster.affected_people;
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
        GameData.food += improvement.affected_food;
        GameData.resources += improvement.affected_resources;
        GameData.population_size += improvement.affected_people;
        improvementsPanel.SetActive(false);
        endOfEraPanel.SetActive(false);
    }

}
