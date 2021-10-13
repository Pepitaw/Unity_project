using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    
    private string temp = "main";
    public void PlayGame()
    {
        SceneManager.LoadScene(temp);
    }    

    void Start()
    {
        GameObject.Find("ChooseLevel").GetComponent<Dropdown>().onValueChanged.AddListener(LevelResult);
        GameObject.Find("ChooseSite").GetComponent<Dropdown>().onValueChanged.AddListener(SiteResult);
    }

    public void SiteResult(int value)
    {
        switch (value)
        {
            case 0:
                temp = "main";
                break;
            case 1:
                temp = "main2";
                break;
            case 2:
                temp = "main1";
                break;
        }
    }

    public static int MaxMovementSpeed = 5;
    public void LevelResult(int value)
    {
        switch (value)
        {
            case 0:
                MaxMovementSpeed = 5;
                break;
            case 1:
                MaxMovementSpeed = 20;
                break;
            case 2:
                MaxMovementSpeed = 80;
                break;
        }
    }
}