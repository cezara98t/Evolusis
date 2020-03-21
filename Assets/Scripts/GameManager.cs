using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ActionButtonsManager actionButtonsManager;
    public GameObject mainPanel;
    private GameObject currentJobPanel;
    public GameObject endOfEraPanel;
    [SerializeField]
    private GameObject[] mainPanels;

    public GameObject eraInfo;
    public GameObject lifeInfo;

    private GameObject return_button;
    private GameObject qmark_button;
    private GameObject book_button;


    private void Start()
    {
        GameData.mainPanel = mainPanel;
        return_button = eraInfo.transform.Find("return_button").gameObject;
        qmark_button = eraInfo.transform.Find("qmark_button").gameObject;
        book_button = eraInfo.transform.Find("info_button").gameObject;            
        return_button.SetActive(false);
        qmark_button.SetActive(false);
        book_button.SetActive(true);
    }

    private void Update()
    {
        lifeInfo.transform.Find("population").GetComponent<Text>().text = GameData.population_size.ToString();
        lifeInfo.transform.Find("food").GetComponent<Text>().text = GameData.food.ToString();
        lifeInfo.transform.Find("resources").GetComponent<Text>().text = GameData.resources.ToString();
        
    }


    public void mainToJob(GameObject jobPanel) {
        mainPanel.SetActive(false);
        jobPanel.SetActive(true);
        currentJobPanel = jobPanel;
        GameData.currentJobPanel = jobPanel;
        return_button.SetActive(true);
        qmark_button.SetActive(true);
        book_button.SetActive(false);
    }

    public void jobToMain() {
        currentJobPanel.SetActive(false);
        mainPanel.SetActive(true);
        return_button.SetActive(false);
        qmark_button.SetActive(false);
        book_button.SetActive(true);
        GameData.currentJobPanel = null;
    }

    public void showHelpArrow() {
        currentJobPanel.transform.Find("help_arrow").gameObject.SetActive(true);
    }

    public void endEra() {
        endOfEraPanel.SetActive(true);
        GameData.restoreEnergy();
        actionButtonsManager.restoreEnergy();
        if(currentJobPanel!=null) jobToMain();
        mainPanel.SetActive(false);
        if(GameData.currentMainPanelIndex<mainPanels.Length)
            mainPanel = mainPanels[GameData.currentMainPanelIndex++];
        mainPanel.SetActive(true);
    }
}
