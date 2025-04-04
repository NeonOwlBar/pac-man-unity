using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTile : MonoBehaviour
{
    Vector2Int tileSize;
    Vector2Int mazeCoordinate;
    Color tileColor;
    bool isPath;
    bool hasPowerPellet; // this may be pointless but let's leave it here for now
    //TileInfo tileDetails;
    SpriteRenderer spriteRenderer;

    // I should probably use these tiles to generate a maze. Rather than
    // creating a maze within editor and trying to link it to these tile instances

    public void Initialise(Vector2Int size, Vector2Int coordinate, bool isPathTile, Color color)
    {
        tileSize = size;
        mazeCoordinate = coordinate;
        mazeCoordinate.y *= -1;
        isPath = isPathTile;
        tileColor = color;
        
        if (!TryGetComponent<SpriteRenderer>(out spriteRenderer))
        {
            // if can't find sprite renderer
            Debug.LogError("Could not find sprite renderer for tile");
        }

        gameObject.transform.localScale = new Vector3(tileSize.x, tileSize.y, 0f);
        transform.position = (Vector2)mazeCoordinate;
        isPath = isPathTile;
        spriteRenderer.color = tileColor;
    }

}

struct TileInfo
{
    public bool IsUpClear;
    public bool IsRightClear;
    public bool IsDownClear;
    public bool IsLeftClear;
}
