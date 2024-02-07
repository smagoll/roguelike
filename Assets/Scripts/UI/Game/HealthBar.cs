using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI textHp;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        GlobalEventManager.UpdateHealthBar.AddListener(UpdateHealthBar);
    }

    public void UpdateHealthBar(float health, float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
        textHp.text = $"{health}/{maxHealth}";
    }
}
