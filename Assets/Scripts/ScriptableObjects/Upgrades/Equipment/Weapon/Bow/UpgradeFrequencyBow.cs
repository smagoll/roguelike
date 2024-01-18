using UnityEngine;

[CreateAssetMenu(fileName = "FrequencyBow", menuName = "Upgrades/Weapons/Bow/Frequency")]
public class UpgradeFrequencyBow : Upgrade
{
    public override void Action()
    {
        switch (rare)
        {
            case 1:
                GameManager.player.GetComponent<Bow>().scaleFrequency -= 1;
                break;
            case 2:
                GameManager.player.GetComponent<Bow>().scaleFrequency -= 3;
                break;
            case 3:
                GameManager.player.GetComponent<Bow>().scaleFrequency -= 5;
                break;
        }
    }
}
