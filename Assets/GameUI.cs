using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject selected;

    private void Awake()
    {
        GlobalEventManager.ChoiseBonus.AddListener(ShowSelected);
    }

    public void ShowSelected()
    {
        selected.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void HideSelected()
    {
        selected.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ButtonOK()
    {
        HideSelected();
    }
}
