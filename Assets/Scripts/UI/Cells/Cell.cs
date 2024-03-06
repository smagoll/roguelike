using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class Cell : MonoBehaviour
{
    public Image image;
    public GameObject fade;

    private bool isOpen = false;
    public int id;
    
    public bool IsOpen
    {
        get => isOpen;
        set
        {
            isOpen = value;
            SetFade(isOpen);
        }
    }

    public abstract void Init(int id);
    public abstract void UpdateCell();

    public virtual void SetFade(bool isOpen)
    {
        fade.SetActive(!isOpen);
    }
}