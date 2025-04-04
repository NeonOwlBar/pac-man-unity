using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This derives from Monobehaviour. Could it simply be called from a GameManager class?
public class MazeGenerator : MonoBehaviour
{
    // Prefab for individual tile
    public GameObject tilePrefab;
    // Origin of maze (0, 0)
    Vector2 MazeOrigin = Vector2.zero;
    // default maze size:
    const int kDefaultMazeX = 28;
    const int kDefaultMazeY = 31;

    //Vector2Int mazeSize;
    Dictionary<int, Color> tileColours = new();
    // Tile map. 0 = wall, 1 = path
    // 5x8 dimensions
    int[,] TileMap = { 
        { 0, 0, 0, 0, 0 },
        { 0, 1, 1, 1, 0 },
        { 0, 1, 0, 1, 0 },
        { 0, 1, 1, 1, 0 },
        { 0, 1, 0, 1, 0 },
        { 0, 1, 0, 1, 0 },
        { 0, 1, 1, 1, 0 },
        { 0, 0, 0, 0, 0 },
    };

    //// Default constructor, creates maze of default size
    //public MazeGenerator()
    //{
    //    tileColours.Add(0, new Color(0f, 0f, 0f, 1f));
    //    tileColours.Add(1, new Color(0f, 0f, 1f, 1f));
    //}
    //// Create maze of specific size
    //public MazeGenerator(int xLength, int yLength)
    //{
    //    //mazeSize.x = xLength;
    //    //mazeSize.y = yLength;
    //    Debug.Log("tile map is " + TileMap.GetLength(1) + " by " + TileMap.GetLength(0) + ".");
    //}

    private void Start()
    {
        Debug.Log("tile map is " + TileMap.GetLength(1) + " by " + TileMap.GetLength(0) + ".");
        
        tileColours.Add(0, Color.red);
        tileColours.Add(1, Color.green);

        Debug.Log("Tile colour is " + tileColours[TileMap[0, 0]].ToString() + ".");

        // ~~~~~~~~~~~~~ Try to render just one tile first ~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~ Then iterate over the array below ~~~~~~~~~~~~~~~~~~~~~~



        // as each j is a column and each i is a row,
        //      j represents x, and i represents y.
        //      Therefore, coords are in the format [j, i].

        // Iterate row by row
        for (int i = 0; i < TileMap.GetLength(0); i++)
        {
            // iterate across each column of a row
            for (int j = 0; j < TileMap.GetLength(1); j++)
            {
                Debug.Log("Coordinate: [" + i + ", " + j + "]");
                // create MazeTile object
                // Add object to a list?
                // at particular co-ordinate
                // colour in by referencing dictionary

                // Create new tile
                // consider if needs to be made false for Pac-Man position on maze
                GameObject newTileObject = Instantiate(tilePrefab, transform, true);
                // Get MazeTile class on tile object
                MazeTile newTile = newTileObject.GetComponent<MazeTile>();
                // determine whether this tile is path (true) or wall (false)
                bool isTileOnPath = TileMap[i, j] == 1;
                // Initialise values for tile
                newTile.Initialise(new Vector2Int(1, 1), new Vector2Int(j, i), isTileOnPath, tileColours[TileMap[i, j]]);
                // Perhaps need a tile prefab
            }
        }
    }



}
