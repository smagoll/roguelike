using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        icon.sprite = DataManager.instance.improvements.FirstOrDefault(x => x.statType == stat.Type).icon;
    }
}
