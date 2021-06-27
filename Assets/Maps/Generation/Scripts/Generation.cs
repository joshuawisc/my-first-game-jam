using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This script attaches to a director object
 * It reads and writes serialized data using MapSerialization methods
 * Its core function is to intelligently form a map based on where the user is 
 * 
 * It should create a serialized map and store templates in a Map Object 
 * On game start, it should deserialize the starting location and a render ring
 * these objects should be used to grab template prefabs
 * 
 * It should be capable of spawning the templates within the render ring
 * 
 * As the player moves, it should cache templates and load them in as they move into the render ring.
 * 
 * Once templates move out of the render ring, this script should dispose of them. 
 * (Maintain the object, release the 3d asset from memory and stop rendering)
 */
public class Generation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
