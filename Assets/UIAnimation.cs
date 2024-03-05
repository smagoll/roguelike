using DG.Tweening;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public enum AnimationType
    {
        SlideUp,
        SlideDown,
        SlideLeft,
        SlideRight,
        ScaleUp
    }

    [SerializeField]
    private AnimationType uiAnimation;
    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private float fadeTime;

    private void OnEnable()
    {
        AnimationIn();
    }

    public void AnimationIn()
    {
        switch (uiAnimation)
        {
            case AnimationType.ScaleUp:
                rectTransform.transform.localScale = Vector3.zero;
                rectTransform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce).SetUpdate(true);
                break;
            case AnimationType.SlideDown:
                rectTransform.transform.localPosition = new Vector3(0f,-100f,0f);
                rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
            case AnimationType.SlideUp:
                rectTransform.transform.localPosition = new Vector3(0f,100f,0f);
                rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
            case AnimationType.SlideLeft:
                rectTransform.transform.localPosition = new Vector3(100f,0f,0f);
                rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
            case AnimationType.SlideRight:
                rectTransform.transform.localPosition = new Vector3(-100f,0f,0f);
                rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
        }
    }
}
