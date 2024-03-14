using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class DropdownButtonDefault : MonoBehaviour, IPointerClickHandler
{
    public void Pressed()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(.8f, .3f))
            .Append(transform.DOScale(1f, .1f))
            .SetEase(Ease.OutBack)
            .SetUpdate(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Pressed();
    }
}
