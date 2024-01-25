using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI textXp;
    [SerializeField]
    private TextMeshProUGUI textStage;

    private void Awake()
    {
        GlobalEventManager.UpdateStageBar.AddListener(UpdateStageBar);

        slider = GetComponent<Slider>();
    }

    public void UpdateStageBar(int stage, float xpCollect, float xpForCurrentStage)
    {
        slider.maxValue = xpForCurrentStage;
        slider.value = xpCollect;
        textXp.text = $"{xpCollect}/{xpForCurrentStage}";
        textStage.text = $"Stage {stage}";
    }
}
