using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject selected;

    private void Awake()
    {
        GlobalEventManager.EndWave.AddListener(ShowSelected);
    }

    public void ShowSelected()
    {
        selected.SetActive(true);
    }
    
    public void HideSelected()
    {
        selected.SetActive(false);
    }

    public void ButtonOK()
    {
        HideSelected();
        GlobalEventManager.Start_NextWave();
    }
}
