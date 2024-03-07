using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI textHp;
    [SerializeField]
    private Transform iconHeart;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        GlobalEventManager.UpdateHealthBar.AddListener(UpdateHealthBar);
    }

    public void UpdateHealthBar(float health, float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.DOValue(health, 0.05f);
        textHp.text = $"{health}/{maxHealth}";
        HeartBit();
    }

    private void HeartBit()
    {
        DOTween.Sequence()
            .Append(iconHeart.DOScale(1.3f, 0.05f))
            .Append(iconHeart.DOScale(1f, 0.05f)).SetUpdate(true);
    }
}
