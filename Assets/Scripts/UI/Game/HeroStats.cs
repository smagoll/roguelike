using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class HeroStats : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI hpText;
    [SerializeField]
    private TextMeshProUGUI speedText;
    [SerializeField]
    private TextMeshProUGUI evasionText;

    private Character character;

    [Inject]
    private void Construct(Character character)
    {
        this.character = character;
    }

    private void OnEnable()
    {
        hpText.text = character.HP.ToString();
        speedText.text = character.Speed.ToString();
        evasionText.text = character.Evasion.ToString();
    }

}
