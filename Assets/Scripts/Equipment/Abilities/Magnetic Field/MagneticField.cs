using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : EquipmentStatic
{
    public float damage;
    private float frequency;
    public float scaleRadius = 100;
    public GameObject prefabField;

    public float Frequency
    {
        get => frequency * scaleRadius / 100;
        set => frequency = value;
    }

    private void CreateField()
    {
        var fieldObject = Instantiate(prefabField, transform);
        fieldObject.GetComponent<Field>().controller = this;
    }

    public void Initialize(UpgradeAddField data)
    {
        damage = data.damage;
        upgrades = data.upgrades;
        Frequency = data.frequency;
        prefabField = data.prefabField;

        CreateField();
    }
}
