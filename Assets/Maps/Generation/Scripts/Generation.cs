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

    public GameObject roomTemplate1;
    public string playerName = "Player";
    public string startingRoomName = "StartingRoom";

    private List<GameObject> rooms = new List<GameObject>();
    private GameObject player;
    private GameObject startingRoom;
    private bool wasRemoved = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(playerName).transform.Find("Player").gameObject;
        startingRoom = GameObject.Find(startingRoomName);
        rooms.Add(startingRoom);
    }

    // Update is called once per frame
    void Update()
    {
        // Get door points from room

        foreach (GameObject room in rooms)
            
        {
            if (room == null)
            {
                rooms.Remove(room);
                continue;
            }

            Transform doors = room.transform.Find("Doors");

            foreach (Transform child in doors)
            {
                // Debug.Log((child.position - player.transform.position).magnitude);
                
                // If near empty doorway, add room
                if ((child.position - player.transform.position).magnitude < 5)
                {
                    Vector3 centerToDoorVec = child.position - room.transform.position;
                    // Place new room at correct doorway
                    Vector3 newPos = centerToDoorVec + child.position;

                    // Place in correct orientation (align entrance of template room)
                    float angle = Vector3.SignedAngle(centerToDoorVec, roomTemplate1.transform.Find("Entrance").position, Vector3.up);
                    Debug.Log(angle);
                    // angle = angle == 180 ? 0 : angle;

                    float fangle = Vector3.Angle(centerToDoorVec, Vector3.forward)/180;
                    // Debug.Log(fangle);
                    // Add randomness
                    // if (Random.Range(0f, 1f) > 0.45 && fangle != 0)
                    addRoom(roomTemplate1, newPos, Quaternion.Euler(0f, 180-angle, 0f), child.position);

                    // Make sure doorway doesn't trigger again and save time
                    Destroy(child.gameObject);
                    // GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = child.position;

                }
               
            }
        }
    }

    void addRoom(GameObject roomTemplate, Vector3 position, Quaternion rotation, Vector3 doorPosition)
    {

        GameObject newRoom = Instantiate(roomTemplate, position, rotation);
       
        rooms.Add(newRoom);
        newRoom.name = "NewRoom" + rooms.Count;

        /*
        if (!newRoom.GetComponent<TemplateCollisionChecker>().collided)
        {
            
            newRoom.name = "NewRoom" + rooms.Count;
        }
        else
        {
            GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = doorPosition;
            Destroy(newRoom);
            Debug.Log("COLLIDED GEN SCRIPT");

        }
        */
    }

}
