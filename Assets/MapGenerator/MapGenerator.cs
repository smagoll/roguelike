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
    [Range(0, 50)] [SerializeField] private float panSpeed = 5.0F;
    private Vector2Int posCam;

    [Header("Noise Configuration")]
    [SerializeField] private int seed = 100;
    [Range(1, 100)] [SerializeField] private float scale = 30.0F;
    [Range(1, 5)] [SerializeField] private int octaves = 1;
    [Range(0, 1)] [SerializeField] private float persistence = 0.5F;
    [SerializeField] private float lacunarity = 1.0F;

    public TilemapVisualizer tilemapVisualizer;
    public MapDisplay mapDisplay;

    [SerializeField]
    private TileBase floorTile;
    [SerializeField]
    private TileBase grainTile;

    [Header("Chunks")]
    [SerializeField]
    private ChunkSystem chunkSystem;

    private void Start()
    {
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
            {
                GenerateMap(chunkSystem.chunks[x,y].coord, chunkSystem.chunks[x, y].tilemap);
            }
    }

    private void Update()
    {
        //if (Mathf.Abs(posCam.x - cam.transform.position.x) > panSpeed - 1 || Mathf.Abs(posCam.y - cam.transform.position.y) > panSpeed - 1)
        //{
        //    GenerateMap();
        //}
        Check();
    }

    private void Check()
    {
        var direction = cam.transform.position - chunkSystem.chunks[1, 1].tilemap.transform.position;
        int x = 0;
        int y = 0;

        if (Mathf.Abs(direction.x) > 10)
            x = direction.x < 0 ? -1 : 1;
        else if (Mathf.Abs(direction.y) > 10)
            y = direction.y < 0 ? -1 : 1;
        else
            return;

        chunkSystem.Rotate(x, y);
        Debug.Log($"x: {x}, y: {y}");
    }


    public void GenerateMap(Vector2Int chunkCoord, Tilemap tilemap)
    {
        //posCam = new Vector2Int((int)cam.transform.position.x, (int)cam.transform.position.y);
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
                if (posTileInMap > 0.5f)
                    PaintSingleTile(tilemap, grainTile, x, y, chunkCoord);
                if (posTileInMap < 0.5f)
                    PaintSingleTile(tilemap, floorTile, x, y, chunkCoord);
            }
        yield return null;
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, float x, float y, Vector2Int chunkCoord)
    {
        tilemap.gameObject.transform.position = new Vector2(chunkCoord.x, chunkCoord.y);
        tilemap.SetTile(new Vector3Int((int)x, (int)y), tile);
    }

}
