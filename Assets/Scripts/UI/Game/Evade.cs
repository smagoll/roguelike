using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class Evade : MonoBehaviour
{
    public ObjectPool<Evade> pool;
    [FormerlySerializedAs("text")] [SerializeField]
    private TextMeshProUGUI textEvade;
    [SerializeField]
    private float moveY;
    [SerializeField]
    private float timeInMove;
    [SerializeField]
    private float timeBeforeDestroy;

    public void Show()
    {
        AudioGame.instance.PlayMainSFX(AudioGame.instance.evasion);
        transform.DOMove(transform.position + new Vector3(0, moveY, 0), timeInMove);
        DOTween.Sequence()
            .Append(transform.DOScale(0.03f, 0.1f))
            .AppendInterval(timeBeforeDestroy)
            .Append(textEvade.DOFade(0.1f, 1f))
            .AppendCallback(Delete);
    }

    public void Delete()
    {
        pool.Release(this);
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        textEvade.DOFade(1f, 0f);
    }
}