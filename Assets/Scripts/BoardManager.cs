﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager sharedInstance;
    public List<Sprite> prefabs = new List<Sprite>();
    public GameObject currentCandy;
    public int xSize, ySize;

    private GameObject[,] candies;

    public bool isShifting { get; set; }

    void Start()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Vector2 offset = currentCandy.GetComponent<BoxCollider2D>().size;
        CreateInitialBoard(offset);
    }

    private void CreateInitialBoard(Vector2 offset)
    {
        candies = new GameObject[xSize, ySize];

        float startX = this.transform.position.x;
        float startY = this.transform.position.y;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                var position = new Vector3(startX + (offset.x * x),
                                           startY + (offset.y * y),
                                           0);
                GameObject newCandy = Instantiate(currentCandy,
                                                  position,
                                                  currentCandy.transform.rotation);
                newCandy.name = $"Candy [{x}] [{y}]";
                candies[x, y] = newCandy;
            }
        }
    }

    void Update()
    {

    }
}