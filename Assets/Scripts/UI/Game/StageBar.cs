using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI textStage;
    [SerializeField]
    private Transform iconStage;
    
    private void Awake()
    {
        GlobalEventManager.UpdateStageBar.AddListener(UpdateStageBar);

        slider = GetComponent<Slider>();
    }

    public void UpdateStageBar(int stage, float xpCollect, float xpForCurrentStage)
    {
        slider.maxValue = xpForCurrentStage;
        slider.DOValue(xpCollect, 0.05f);
        textStage.text = $"Stage {stage}";
        StageBit();
    }

    public void StageBit()
    {
        DOTween.Sequence()
            .Append(iconStage.DOScale(1.3f, 0.05f))
            .Append(iconStage.DOScale(1f, 0.05f));
    }
}
