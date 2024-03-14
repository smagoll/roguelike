using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChunkSystem : MonoBehaviour
{
    public List<ChunkData[,]> chunkLayers = new();
    public ChunkData[,] chunksItems;
    public Grid grid;
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

    private void CreateFirstChunks()
    {
        //chunksEarth = new ChunkData[size, size];
        //chunksItems = new ChunkData[size, size];
        
        foreach (ChunkType chunkType in Enum.GetValues(typeof(ChunkType)))
        {
            var chunks = new ChunkData[size, size];
            chunkLayers.Add(chunks);
            for (int x = -1; x <= 1; x++)
            for (int y = -1; y <= 1; y++)
                CreateChunk(chunks, x, y, chunkType);
        }
        
        //for (int x = -1; x <= 1; x++)
        //    for (int y = -1; y <= 1; y++)
        //        CreateChunk(chunksEarth, x, y);
    }

    private void CreateChunk(ChunkData[,] chunks, int x, int y, ChunkType chunkType)
    {
        var tilemap = Instantiate(prefabTilemap, grid.gameObject.transform);
        tilemap.gameObject.GetComponent<TilemapRenderer>().sortingOrder = (int)chunkType;
        var coordChunk = new Vector2Int(x, y);
        chunks[x + 1, y + 1] = new ChunkData(coordChunk, tilemap, chunkType);
    }

    public void Rotate(int xRotate, int yRotate)
    {
        if (xRotate == 0 && yRotate == 0) return;

        foreach (var chunkLayer in chunkLayers)
        {
            ChunkData[,] copyChunks = Copy(chunkLayer);

            foreach (var chunk in chunkLayer) chunk.coord += new Vector2(xRotate, yRotate);

            for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
            {
                var isFind = false;
                foreach (var copyChunk in copyChunks)
                    if (chunkLayer[x, y].coord == copyChunk.coord)
                    {
                        chunkLayer[x, y].tilemap = copyChunk.tilemap;
                        isFind = true;
                        break;
                    }

                if (!isFind)
                {
                    chunkLayer[x, y].tilemap = copyChunks[x + xRotate * -2, y + yRotate * -2].tilemap;
                    chunkLayer[x, y].tilemap.ClearAllTiles();
                    mapGenerator.GenerateTilemap(chunkLayer[x, y].coord, chunkLayer[x, y].tilemap, chunkLayer[x, y].chunkType);
                }
            }
        }
    }

    private static ChunkData[,] Copy(ChunkData[,] array)
    {
        ChunkData[,] newArray = new ChunkData[array.GetLength(0), array.GetLength(1)];
        for (int i = 0; i < array.GetLength(0); i++)
            for (int j = 0; j < array.GetLength(1); j++)
                newArray[i, j] = new ChunkData(array[i, j].coord, array[i, j].tilemap, array[i,j].chunkType);
        return newArray;
    }
}

public class ChunkData
{
    public Vector2 coord;
    public Tilemap tilemap;
    public ChunkType chunkType;

    public ChunkData(Vector2 coord, Tilemap tilemap, ChunkType chunkType)
    {
        this.coord = coord;
        this.tilemap = tilemap;
        this.chunkType = chunkType;
    }
}
