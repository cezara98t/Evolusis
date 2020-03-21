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
    public GameObject[] energy_bar;
    public GameObject error_panel;

    private ActionButtonRepository actionButtonRepository;
    private ActionButtonValidator validator;

    // Start is called before the first frame update
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
            GameData.energy--;
            Image energy = energy_bar[GameData.energy].GetComponent<Image>();
            var tempColor = energy.color;
            tempColor.a = 0;
            energy.color = tempColor;

            double chance = Utils.GetRandomDouble();
            if (chance > button.requested_ability_percentage)
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
        GameData.resources -= button.lose_resources;
        GameData.population_size -= button.lose_people;
    }

    private void doGoodAction(ActionButtonData button)
    {
        GameData.food += button.affected_food;
        GameData.resources += button.affected_resources;
        GameData.population_size += button.affected_people;
    }

    private IEnumerator showErrorPanel( string validated){
        error_panel.SetActive(true);
        error_panel.GetComponentInChildren<Text>().text = validated;
        int seconds = validated.Length / 30 + 1;
        yield return new WaitForSeconds(seconds);
        error_panel.SetActive(false);
    }

    public void restoreEnergy() {
        for (int i=0;i<energy_bar.Length;i++) {
            Image energy = energy_bar[i].GetComponent<Image>();
            var tempColor = energy.color;
            tempColor.a = 1;
            energy.color = tempColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
