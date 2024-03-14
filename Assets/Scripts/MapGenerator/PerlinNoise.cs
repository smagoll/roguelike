using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PerlinNoise
{
    public static float[,] GenerateNoiseMap(int width, int height, float scale, int seed, int octaves, float persistence, float lacunarity, Vector2 offset)
    {
        float[,] noiseMap = new float[width, height];
        var rnd = new System.Random(seed);

        Vector2[] octavesOffset = new Vector2[octaves];

        for (int i = 0; i < octaves; i++)
        {
            float xOffset = rnd.Next(-100000, 100000) + offset.x * (width / scale);
            float yOffset = rnd.Next(-100000, 100000) + offset.y * (height / scale);

            octavesOffset[i] = new Vector2(xOffset / width, yOffset / height);
        }

        if (scale < 0) scale = 0.0001F;

        float halfWidth = width / 2.0F;
        float halfHeight = height / 2.0F;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;
                float superpositionCompensation = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float xResult = (x - halfWidth) / scale * frequency + octavesOffset[i].x * frequency;
                    float yResult = (y - halfHeight) / scale * frequency + octavesOffset[i].y * frequency;

                    float generateValue = Mathf.PerlinNoise(xResult, yResult);

                    noiseHeight += generateValue * amplitude;
                    noiseHeight -= superpositionCompensation;

                    amplitude *= persistence;
                    frequency *= lacunarity;
                    superpositionCompensation = amplitude / 2;
                }

                noiseMap[x, y] = Mathf.Clamp01(noiseHeight);
            }
        }
        return noiseMap;
    }
}
