using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject achievementslPanel;
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
        if (GameData.getFirstTime() == 0)   // este prima data cand utilizatorul deschide jocul
        {
            tutorialPanel.SetActive(true);
            GameData.initAchv();
        }
        loadGame();
        LoadText.readJson();
        loadEraText();
        GameData.mainPanel = mainPanels[GameData.currentMainPanelIndex];
        return_button = eraInfo.transform.Find("return_button").gameObject;
        qmark_button = eraInfo.transform.Find("qmark_button").gameObject;
        book_button = eraInfo.transform.Find("info_button").gameObject;            
        return_button.SetActive(false);
        qmark_button.SetActive(false);
        book_button.SetActive(true);
    }

    private void Update()
    {
        lifeInfo.transform.Find("population").GetComponent<Text>().text = convertWithDot(GameData.population_size);
        lifeInfo.transform.Find("food").GetComponent<Text>().text = convertWithDot(GameData.food);
        lifeInfo.transform.Find("resources").GetComponent<Text>().text = convertWithDot(GameData.resources);        
    }

    private string convertWithDot(int number)
    {
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        nfi.CurrencyDecimalSeparator = ",";
        nfi.CurrencyGroupSeparator = ".";
        nfi.CurrencySymbol = "";
        var answer = Convert.ToDecimal(number).ToString("C3", nfi);
        return answer.Substring(0, answer.Length - 4);
    }


    private void loadEraText()
    {
        eraInfo.transform.Find("name_of_era").GetComponent<Text>().text=LoadText.getName_of_era();
        eraInfo.transform.Find("part_of_era").GetComponent<Text>().text=LoadText.getPart_of_era();
    }

    public void mainToJob(GameObject jobPanel) {
        mainPanel.SetActive(false);
        jobPanel.SetActive(true);
        currentJobPanel = jobPanel;
        GameData.currentJobPanel = jobPanel;
        return_button.SetActive(true);
        qmark_button.SetActive(true);
        book_button.SetActive(false);

        SoundManager.Instance.playJobSound();
    }

    public void jobToMain() {
        currentJobPanel.SetActive(false);
        mainPanel.SetActive(true);
        return_button.SetActive(false);
        qmark_button.SetActive(false);
        book_button.SetActive(true);
        GameData.currentJobPanel = null;

        SoundManager.Instance.stopJobSound();
    }

    public void showHelpArrow() {
        currentJobPanel.transform.Find("help_arrow").gameObject.SetActive(true);
    }

    public void endEra() {
        endOfEraPanel.SetActive(true);
        GameData.restoreEnergy();
        EnergyBarManager.Instance.refreshEnergy();
        if(currentJobPanel!=null) jobToMain();
        GameData.currentMainPanelIndex++;
        changeMainPanel();
        EndOfEraManager.Instance.showDisasters();

        LoadText.readJson();
        loadEraText();

        if (GameData.currentMainPanelIndex == 6) //la final o sa fie 8 cand sunt toate !!
        {
            eraInfo.transform.Find("endGame_button").gameObject.SetActive(true);
        }
    }

    //schimba main-ul curent cu cel de la indexul din GameData
    public void changeMainPanel()
    {
        mainPanel.SetActive(false);
        if (GameData.currentMainPanelIndex < mainPanels.Length)
        {
            mainPanel = mainPanels[GameData.currentMainPanelIndex];
            GameData.mainPanel = mainPanel;
        }
        mainPanel.SetActive(true);
    }


    public void saveGame()
    {
        GameData.saveGame();
    }

    public void loadGame()
    {
        achievementslPanel.SetActive(false); 
        eraInfo.transform.Find("endGame_button").gameObject.SetActive(false);
        GameData.mainPanel = mainPanels[GameData.currentMainPanelIndex];
        mainPanel = GameData.mainPanel;
        if (GameData.currentJobPanel != null)
            jobToMain();
        GameData.loadGame();
        changeMainPanel();
        EnergyBarManager.Instance.refreshEnergy();
        LoadText.readJson();
        loadEraText();
        if (GameData.currentMainPanelIndex == 6) //la final o sa fie 8 cand sunt toate !!
        {
            eraInfo.transform.Find("endGame_button").gameObject.SetActive(true);
        }

        SoundManager.Instance.playMainSound();
    }

    public void newGame()
    {
        achievementslPanel.SetActive(false);
        eraInfo.transform.Find("endGame_button").gameObject.SetActive(false);
        GameData.mainPanel = mainPanels[0]; 
        if (GameData.currentJobPanel != null)
            jobToMain();
        GameData.newGame();
        changeMainPanel();
        EnergyBarManager.Instance.refreshEnergy();
        LoadText.readJson();
        loadEraText();

        SoundManager.Instance.playMainSound();
    }


}
