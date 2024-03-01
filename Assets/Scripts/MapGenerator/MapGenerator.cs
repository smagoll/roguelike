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

    [SerializeField]
    private TileBase floorTile;
    [SerializeField]
    private TileBase grainGreyTile;
    [SerializeField]
    private TileBase grainTile;

    [Header("Chunks")]
    [SerializeField]
    private ChunkSystem chunkSystem;

    private void Start()
    {
        for (int x = 0; x < chunkSystem.size; x++)
            for (int y = 0; y < chunkSystem.size; y++)
            {
                GenerateMap(chunkSystem.chunks[x,y].coord, chunkSystem.chunks[x, y].tilemap);
            }
    }

    private void Update()
    {
        Check();
    }

    private void Check()
    {
        var direction = cam.transform.position - chunkSystem.chunks[1, 1].tilemap.transform.position;
        int x = 0;
        int y = 0;

        if (Mathf.Abs(direction.x) > width)
            x = direction.x < 0 ? -1 : 1;
        else if (Mathf.Abs(direction.y) > height)
            y = direction.y < 0 ? -1 : 1;
        else
            return;

        chunkSystem.Rotate(x, y);
        Debug.Log($"x: {x}, y: {y}");
    }


    public void GenerateMap(Vector2Int chunkCoord, Tilemap tilemap)
    {
        chunkCoord = chunkCoord * width;
        noiseMap = PerlinNoise.GenerateNoiseMap(width, height, scale, seed, octaves, persistence, lacunarity, chunkCoord);

        StartCoroutine(PaintTiles(noiseMap, tilemap, width, height, chunkCoord));
    }

    IEnumerator PaintTiles(float[,] positions, Tilemap tilemap, int width, int height, Vector2Int chunkCoord)
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

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, float x, float y, Vector2Int chunkCoord)
    {
        tilemap.gameObject.transform.position = new Vector2(chunkCoord.x, chunkCoord.y);
        tilemap.SetTile(new Vector3Int((int)x, (int)y), tile);
    }

}

public enum TileType
{
    Ground,
    Items
}
