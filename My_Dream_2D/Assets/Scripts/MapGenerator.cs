﻿using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public Texture2D map;

    public ColorToPrefab[] colorMappings;

    // Use this for initialization
    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color PixelColor = map.GetPixel(x, y);

        if (PixelColor.a == 0)
        {
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(PixelColor))
            {
                Vector2 position = new Vector2(x, y); 
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
