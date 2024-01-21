using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Catalog", menuName = "Catalog")]
public class Catalog : ScriptableObject
{
    public Price[] prices;
}

[System.Serializable]
public class Price
{
    public int level;
    public int price;
}
