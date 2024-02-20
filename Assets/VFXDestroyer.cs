using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXDestroyer : MonoBehaviour
{
    private VisualEffect vfx;

    private bool isStart;

    void Awake()
    {
        vfx = GetComponent<VisualEffect>();
    }

    private void Start()
    {
        vfx.SendEvent("OnPlay");
    }

    void Update()
    {
        if (vfx.aliveParticleCount > 0)
            isStart = true;
        else
            if (isStart) Destroy(gameObject);
    }
}
