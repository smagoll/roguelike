using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class NavigationButtonClick : MonoBehaviour
{
    [SerializeField]
    private RectTransform content;
    private void Awake()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(Pressed);
    }

    public void Pressed(bool isOn)
    {
        if (isOn)
        {
            DOTween.Sequence()
                .Append(content.DOAnchorPos(new Vector2(0f, -25f), .5f))
                .SetEase(Ease.OutBounce)
                .SetUpdate(true);
        }
        else
        {
            DOTween.Sequence()
                .Append(content.DOAnchorPos(new Vector2(0f, 0f), .5f))
                .SetEase(Ease.OutBounce)
                .SetUpdate(true);
        }

        

    }
}