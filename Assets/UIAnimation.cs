using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

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
    private AnimationType uiAnimationIn;
    [SerializeField]
    private AnimationType uiAnimationOut;
    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private float fadeTime;

    private Sequence sequenceOut;

    private void OnEnable()
    {
        AnimationIn();
    }

    public void AnimationIn()
    {
        //rectTransform.transform.localScale = Vector3.one;
        switch (uiAnimationIn)
        {
            case AnimationType.ScaleUp:
                rectTransform.transform.localScale = Vector3.zero;
                rectTransform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce).SetUpdate(true);
                break;
            case AnimationType.SlideDown:
                rectTransform.transform.localPosition = new Vector3(0f,100f,0f);
                rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
            case AnimationType.SlideUp:
                rectTransform.transform.localPosition = new Vector3(0f,-100f,0f);
                rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
            case AnimationType.SlideLeft:
                rectTransform.transform.localPosition = new Vector3(-100f,0f,0f);
                rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
            case AnimationType.SlideRight:
                rectTransform.transform.localPosition = new Vector3(100f,0f,0f);
                rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
        }
    }
    
    public void AnimationOut()
    {
        sequenceOut.Kill(true);
        var fadeTimeOut = fadeTime / 2;
        rectTransform.transform.localScale = Vector3.one;
        sequenceOut = DOTween.Sequence();
        switch (uiAnimationOut)
        {
            case AnimationType.ScaleUp:
                rectTransform.DOScale(0f, fadeTime / 2).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
            case AnimationType.SlideDown:
                rectTransform.DOAnchorPos(new Vector2(0f, -100f), fadeTimeOut).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
            case AnimationType.SlideUp:
                rectTransform.DOAnchorPos(new Vector2(0f, 100f), fadeTimeOut).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
            case AnimationType.SlideLeft:
                rectTransform.DOAnchorPos(new Vector2(100f, 0f), fadeTimeOut).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
            case AnimationType.SlideRight:
                rectTransform.DOAnchorPos(new Vector2(-100f, 0f), fadeTimeOut).SetEase(Ease.OutElastic).SetUpdate(true);
                break;
        }
        sequenceOut.AppendInterval(fadeTimeOut / 2);
        sequenceOut.AppendCallback(() => gameObject.SetActive(false));
    }
}

