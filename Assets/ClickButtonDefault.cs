using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ClickButtonDefault : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Pressed);
    }

    public void Pressed()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(.8f, .3f))
            .Append(transform.DOScale(1f, .1f))
            .SetEase(Ease.OutBack)
            .SetUpdate(true);
    }
}