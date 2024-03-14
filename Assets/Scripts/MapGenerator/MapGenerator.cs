using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    private float[,] noiseMap;
    public int width;
    public int height;

    [Header("Camera")]
    [SerializeField] private Camera cam;
    private Vector2Int posCam;

    [Header("Noise Configuration")]
    [SerializeField] private int seed = 100;
    [Range(1, 100)] [SerializeField] private float scale = 30.0F;
    [Range(1, 5)] [SerializeField] private int octaves = 1;
    [Range(0, 1)] [SerializeField] private float persistence = 0.5F;
    [SerializeField] private float lacunarity = 1.0F;

    [Header("Earth Tiles")]
    [SerializeField]
    private TileBase floorTile;
    [SerializeField]
    private TileBase grainGreyTile;
    [SerializeField]
    private TileBase grainTile;

    [Header("Items Tiles")]
    [SerializeField]
    private TileBase[] flowers;
    [SerializeField]
    private TileBase stones;
    [SerializeField]
    private TileBase stump;

    [Header("Chunks")]
    [SerializeField]
    private ChunkSystem chunkSystem;

    private void Start()
    {
        foreach (var chunkLayer in chunkSystem.chunkLayers)
        {
            for (int x = 0; x < chunkSystem.size; x++)
            for (int y = 0; y < chunkSystem.size; y++)
            {
                GenerateTilemap(chunkLayer[x,y].coord, chunkLayer[x,y].tilemap, chunkLayer[x,y].chunkType);
            }
        }
    }

    private void Update()
    {
        Check();
    }

    private void Check()
    {
        var direction = cam.transform.position - chunkSystem.chunkLayers[0][1,1].tilemap.transform.position;
        int x = 0;
        int y = 0;

        if (Mathf.Abs(direction.x) > width * chunkSystem.grid.transform.localScale.x)
            x = direction.x < 0 ? -1 : 1;
        else if (Mathf.Abs(direction.y) > height * chunkSystem.grid.transform.localScale.y)
            y = direction.y < 0 ? -1 : 1;
        else
            return;

        chunkSystem.Rotate(x, y);
    }


    public void GenerateTilemap(Vector2 coord, Tilemap tilemap, ChunkType chunkType)
    {
        coord = coord * width * chunkSystem.grid.transform.localScale;
        noiseMap ??= PerlinNoise.GenerateNoiseMap(width, height, scale, seed, octaves, persistence, lacunarity, coord);

        switch (chunkType)
        {
            case ChunkType.Earth:
                StartCoroutine(PaintTilesEarth(noiseMap, tilemap, width, height, coord));
                break;            
            case ChunkType.Items:
                StartCoroutine(PaintTilesItems(noiseMap, tilemap, width, height, coord));
                break;
        }

    }

    IEnumerator PaintTilesEarth(float[,] positions, Tilemap tilemap, int width, int height, Vector2 chunkCoord)
    {
        for (int x = -(width / 2); x < (width / 2); x++)
            for (int y = -(height / 2); y < (height / 2); y++)
            {
                var posTileInMap = positions[x + (width / 2), y + (height / 2)];

                if (posTileInMap > -1f)
                    PaintSingleTile(tilemap, floorTile, x, y, chunkCoord);
                if (posTileInMap > -0.5f && posTileInMap < 0)
                    PaintSingleTile(tilemap, grainTile, x, y, chunkCoord);
                if (posTileInMap > 0.32f && posTileInMap < .35f)
                    PaintSingleTile(tilemap, grainGreyTile, x, y, chunkCoord);
                if (posTileInMap > 0.35f && posTileInMap < 0.37f)
                    PaintSingleTile(tilemap, grainTile, x, y, chunkCoord);
                if (posTileInMap > 0.9f)
                    PaintSingleTile(tilemap, grainTile, x, y, chunkCoord);
            }
        yield return null;
    }

    IEnumerator PaintTilesItems(float[,] positions, Tilemap tilemap, int width, int height, Vector2 chunkCoord)
    {
        for (int x = -(width / 2); x < (width / 2); x++)
        for (int y = -(height / 2); y < (height / 2); y++)
        {
            var posTileInMap = positions[x + (width / 2), y + (height / 2)];

            if (posTileInMap is > 0.1f and < 0.102f)
                PaintSingleTile(tilemap, flowers[Random.Range(0, flowers.Length)], x, y, chunkCoord);
            if (posTileInMap is > 0.35f and < 0.351f)
                PaintSingleTile(tilemap, flowers[Random.Range(0, flowers.Length)], x, y, chunkCoord);
            if (posTileInMap is > 0.20f and < .202f)
                PaintSingleTile(tilemap, stones, x, y, chunkCoord);
            if (posTileInMap is > 0.70f and < .702f)
                PaintSingleTile(tilemap, stones, x, y, chunkCoord);
            if (posTileInMap is > 0.55f and < 0.552f)
                PaintSingleTile(tilemap, stump, x, y, chunkCoord);
            if (posTileInMap is > 0.15f and < 0.152f)
                PaintSingleTile(tilemap, stump, x, y, chunkCoord);
        }
        yield return null;
    }
    
    private void PaintSingleTile(Tilemap tilemap, TileBase tile, float x, float y, Vector2 chunkCoord)
    {
        tilemap.gameObject.transform.position = new Vector2(chunkCoord.x, chunkCoord.y);
        tilemap.SetTile(new Vector3Int((int)x, (int)y), tile);
    }

}
