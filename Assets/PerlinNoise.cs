using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PerlinNoise
{
    public static float[,] GenerateNoiseMap(int width, int height, float scale)
    {
        float[,] noiseMap = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = x / scale;
                float yCoord = y / scale;

                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                noiseMap[x, y] = sample;
            }
        }

        return noiseMap;
    }
}
