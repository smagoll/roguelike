using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ToggleButtonDefault : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(Pressed);
    }

    public void Pressed(bool isMark)
    {
        DOTween.Sequence()
            .Append(transform.DOScale(.8f, .3f))
            .Append(transform.DOScale(1f, .1f))
            .SetEase(Ease.OutBack)
            .SetUpdate(true);
    }
}