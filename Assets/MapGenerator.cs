using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int width;
    public int height;

    public float scale;

    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        float[,] noiseMap = PerlinNoise.GenerateNoiseMap(width, height, scale);

        var display = GetComponent<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }
}
