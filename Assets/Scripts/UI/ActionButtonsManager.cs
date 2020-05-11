using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActionButtonsManager : MonoBehaviour
{

    public GameObject prefab;
    public GameObject containter;
    public GameObject error_panel;

    private IRepository<List<ActionButtonData>> actionButtonRepository;
    private ActionButtonValidator validator;

 
    void Start()
    {
        actionButtonRepository = new ActionButtonRepository();
        validator = new ActionButtonValidator();
    }

    public void readButtons()
    {
        if (GameData.currentJobPanel != null)
        {
            actionButtonRepository.read();
            instantiateButtons();
        }
    }

    private void instantiateButtons()
    {
        foreach (Transform child in containter.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (ActionButtonData actionButtonData in actionButtonRepository.buttons) {
            GameObject go = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            go.GetComponentsInChildren<Text>()[0].text = actionButtonData.text;
            go.GetComponentsInChildren<Text>()[1].text = actionButtonData.subtext;
            go.GetComponent<Button>().onClick.AddListener(delegate{ onClick(actionButtonData,go);});
            go.transform.SetParent(containter.transform, false);
        }
        
    }

    private void onClick(ActionButtonData button, GameObject go)
    {
        string validated = validator.validate(button);
        if (String.IsNullOrEmpty(validated))
        {
            EnergyBarManager.Instance.consumeEnergy();
            double requested_ability_percentage = GameData.population_abilities.abilities[button.requested_ability];
            if (requested_ability_percentage > button.requested_ability_percentage)
            {
                doGoodAction(button);
            }
            else {
                doBadAction(button);
                StartCoroutine(showErrorPanel(button.bad_message));
            }
        }
        else
        {
            StartCoroutine(showErrorPanel(validated));
        }
    }

    // abilitatea nu este destul de mare
    private void doBadAction(ActionButtonData button)
    {
        GameData.food -= button.lose_food;
        if (GameData.food < 0) GameData.food = 0;
        GameData.resources -= button.lose_resources;
        if (GameData.resources < 0) GameData.resources = 0;
        GameData.population_size -= button.lose_people;
        GameData.population_abilities.addChromozome(button.affected_chromozome);
    }

    private void doGoodAction(ActionButtonData button)
    { 
        GameData.food += button.affected_food;
        if (GameData.food < 0) GameData.food = 0;
        GameData.resources += button.affected_resources;
        if (GameData.resources < 0) GameData.resources = 0;
            GameData.population_size += button.affected_people;
        GameData.population_abilities.addChromozome(button.affected_chromozome);
    }

    private IEnumerator showErrorPanel( string validated){
        error_panel.SetActive(true);
        error_panel.GetComponentInChildren<Text>().text = validated;
        int seconds = validated.Length / 30 + 1;
        yield return new WaitForSeconds(seconds);
        error_panel.SetActive(false);
    }


}
