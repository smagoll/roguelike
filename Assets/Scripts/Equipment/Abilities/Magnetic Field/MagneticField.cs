using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : EquipmentStatic
{
    public float damage;
    private float frequency;
    public float scaleFrequency = 100;
    private float scaleRadius = 100;

    public GameObject prefabField;
    private GameObject field;

    public float Frequency
    {
        get => frequency * scaleFrequency / 100;
        set => frequency = value;
    }

    public float ScaleRadius
    {
        get
        {
            return scaleRadius;
        }
        set
        {
            scaleRadius = value;
            field.GetComponent<Field>().UpdateScale(scaleRadius);
        }
    }

    private void CreateField()
    {
        field = Instantiate(prefabField, transform);
        field.GetComponent<Field>().controller = this;
    }

    public void Initialize(UpgradeAddField data)
    {
        damage = data.Damage;
        upgrades = data.upgrades;
        Frequency = data.Frequency;
        prefabField = data.prefabField;

        CreateField();
    }
}
