using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTile : MonoBehaviour
{
    // Before implementing struct TileInfo, I should probably create a Tile class.
    // Instances of the Tile class should have:
    // - Vector2 position/co-ordinate
    // - bool isClear   // This should be more specific. isWall or isPath, perhaps?
    // - bool hasPowerPellet????

    // I should probably use these tiles to generate a maze. Rather than
    // creating a maze within editor and trying to link it to these tile instances



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


struct TileInfo
{
    bool IsUpClear;
    bool IsRightClear;
    bool IsDownClear;
    bool IsLeftClear;
}
