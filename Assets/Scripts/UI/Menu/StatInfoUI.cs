using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatInfoUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI value;
    [SerializeField]
    private Image icon;


    public virtual void Initialize(int level, Stat stat)
    {
        value.text = stat.GetValue(level).ToString();
    }
}