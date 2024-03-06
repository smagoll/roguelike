using TMPro;
using UnityEngine;

public class UIManagerMenu : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    [SerializeField]
    private WindowUpgrade windowUpgradeWeapon;
    [SerializeField]
    private WindowUpgrade windowUpgradeAbility;
    [SerializeField]
    private TextMeshProUGUI textRecord;

    private void Awake()
    {
        GlobalEventManager.UpdateCoinMenu.AddListener(UpdateCoinText);
        GlobalEventManager.ShowWindowUpgrade.AddListener(ShowWindowUpgrade);
    }

    private void Start()
    {
        UpdateCoinText();
        UpdateRecord();
    }

    public void UpdateCoinText()
    {
        coinText.text = DataManager.instance.gameData.coins.ToString();
    }

    private void UpdateRecord()
    {
        textRecord.text = DataManager.instance.gameData.record.ToString();
    }

    public void ButtonPlay()
    {
        SceneTransition.LoadScene("Game");
    }

    public void ShowWindowUpgrade(Cell cell, EquipmentType equipmentType)
    {
        switch (equipmentType)
        {
            case EquipmentType.Weapon:
                windowUpgradeWeapon.SetInfo(cell, equipmentType);
                if (!windowUpgradeWeapon.isActiveAndEnabled)
                    windowUpgradeWeapon.gameObject.SetActive(true);
                else
                    windowUpgradeWeapon.animation.AnimationIn();
                break;
            case EquipmentType.Ability:
                windowUpgradeAbility.SetInfo(cell, equipmentType);
                windowUpgradeAbility.gameObject.SetActive(true);
                break;
        }
    }
}
