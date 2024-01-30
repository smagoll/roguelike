using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public GameObject target;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    [SerializeField]
    private float speedRotate;

    public bool isActive = true;

    private void Start()
    {
        target = GameManager.player;
    }

    void Update()
    {
        if (isActive)
        {
            transform.RotateAround(target.transform.position, zAxis, speedRotate * Time.deltaTime);
        }
    }
}
