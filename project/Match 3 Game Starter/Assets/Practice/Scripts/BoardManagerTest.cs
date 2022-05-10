using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManagerTest : MonoBehaviour
{
    public static BoardManagerTest instance;
    public List<Sprite> charactes = new List<Sprite>();
    public GameObject tile;
    public int xSize, ySize;
    private GameObject[,] tiles;
    private void Start()
    {
        instance = GetComponent<BoardManagerTest>();
        Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
        CreateBoard(offset.x, offset.y);
    }
    private void CreateBoard(float xOffset, float yOffset)
    {
        tiles = new GameObject[xSize,ySize];
        float startX = transform.position.x;
        float startY = transform.position.y;
        for(int x = 0; x < xSize; x ++)
        {
            for(int y = 0; y < ySize; y++)
            {
                GameObject newTile = Instantiate<GameObject>(tile, new Vector3(startX + (x * xOffset), startY + (y * yOffset), 0), tile.transform.rotation );
                tiles[x, y] = newTile;
                newTile.transform.parent = transform;
                Sprite newSprite = charactes[Random.Range(0, charactes.Count)];
                newTile.GetComponent<SpriteRenderer>().sprite = newSprite;
            }
        }
    }
}
