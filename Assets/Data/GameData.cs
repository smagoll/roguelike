using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct GameData
{
    public int coins;
    public List<EquipmentData> weapons;
    public List<EquipmentData> abilities;
}