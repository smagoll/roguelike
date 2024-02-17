using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChunkSystem : MonoBehaviour
{
    public ChunkData[,] chunks;
    [SerializeField]
    private Grid grid;
    [SerializeField]
    public int size;
    [SerializeField]
    private Tilemap prefabTilemap;
    [SerializeField]
    private MapGenerator mapGenerator;

    private void Awake()
    {
        CreateFirstChunks();
    }

    public void CreateFirstChunks()
    {
        chunks = new ChunkData[size, size];

        for (int x = -1; x <= 1; x++)
            for (int y = -1; y <= 1; y++)
                CreateChunk(x, y);
    }

    private void CreateChunk(int x, int y)
    {
        var tilemap = Instantiate(prefabTilemap, grid.gameObject.transform);
        tilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = -1;
        var coordChunk = new Vector2Int(x, y);
        chunks[x + 1, y + 1] = new ChunkData(coordChunk, tilemap);
    }

    public void Rotate(int xRotate, int yRotate)
    {
        if (xRotate == 0 && yRotate == 0)
        {
            return;
        }

        ChunkData[,] copyChunks = Copy(chunks);

        foreach (var chunk in chunks)
        {
            chunk.coord += new Vector2Int(xRotate, yRotate);
            Debug.Log(chunk.coord);
        }

        for(int x = 0; x < size; x++)
        {
            for(int y = 0; y < size; y++)
            {
                var isFind = true;
                foreach (var copyChunk in copyChunks)
                {
                    if (chunks[x, y].coord == copyChunk.coord)
                    {
                        chunks[x, y].tilemap = copyChunk.tilemap;
                        isFind = false;
                        break;
                    }
                }
                if (!isFind)
                {
                    copyChunks[x, y].tilemap.ClearAllTiles();
                    mapGenerator.GenerateMap(chunks[x,y].coord, chunks[x, y].tilemap);
                    //CreateChunk(x, y);
                }

            }
        }
    }

    private static T[,] Copy<T>(T[,] array)
    {
        T[,] newArray = new T[array.GetLength(0), array.GetLength(1)];
        for (int i = 0; i < array.GetLength(0); i++)
            for (int j = 0; j < array.GetLength(1); j++)
                newArray[i, j] = array[i, j];
        return newArray;
    }
}

public class ChunkData
{
    public Vector2Int coord;
    public Tilemap tilemap;

    public ChunkData(Vector2Int coord, Tilemap tilemap)
    {
        this.coord = coord;
        this.tilemap = tilemap;
    }
}
