using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject usingUI;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one UIManager");
        }
        instance = this;
    }
    public void ChangeUI(GameObject target)
    {
        if (usingUI != null)
        {
            usingUI.SetActive(false);
        }
        usingUI = target;
        usingUI.SetActive(true);
    }
    public void HideUI()
    {
        if (usingUI != null)
        {
            usingUI.SetActive(false);
        }
        usingUI = null;
    }
}
