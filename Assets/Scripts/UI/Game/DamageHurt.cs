using DG.Tweening;
using TMPro;
using UnityEngine;

public class DamageHurt : MonoBehaviour
{
    public float damage;
    [SerializeField]
    private TextMeshProUGUI textDamage;
    [SerializeField]
    private float moveY;
    [SerializeField]
    private float timeInMove;
    [SerializeField]
    private float timeBeforeDestroy;

    private void Start()
    {
        textDamage.text = damage.ToString();

        transform.DOMove(transform.position + new Vector3(0, 0.2f, 0), timeInMove);
        DOTween.Sequence().Append(transform.DOScale(0.03f, 0.1f)).AppendInterval(timeBeforeDestroy).Append(textDamage.DOFade(0.1f, 1f)).AppendCallback(() => Delete());
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}