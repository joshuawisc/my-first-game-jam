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

        foreach (GameObject room in new List<GameObject>(rooms))
            
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
        GenerateMap(7,7);
    }


    private void GenerateMap(int cx, int cy)
    {
        var chunk = GenerateChunk(cx, cy);
        int retries = 0;
        while (ValidateChunk(chunk, cx, cy) == false && retries < 3)
        {
            chunk = GenerateChunk(cx, cy);
            retries++;
        }
        if (retries == 4 && !ValidateChunk(chunk, cx, cy))
        {
            throw new System.Exception("Out of Retries");
        }
        DEBUGChunkGeneration(chunk, cx, cy);
        PopulateChunk(chunk, cx, cy);
    }

    

    private GenerationMapShell[,] GenerateChunk(int cx, int cy)
    {
        GenerationMapShell[,] chunk = new GenerationMapShell[cx, cy];
        List<GenerationMapShell> prevMoves = new List<GenerationMapShell>();

        // step 1 : Add the chunk start and end
        int center = (cx / 2);
        var start = new GenerationMapShell(center, 0);
        chunk[center, 0] = start;
        var end = new GenerationMapShell(center, cy - 1);
        chunk[center, cy - 1] = end;

        prevMoves.Add(start);
        while (prevMoves.Count > 0)
        {
            var stepMoves = new List<GenerationMapShell>();
            foreach (var shell in prevMoves)
            {
                bool[] currentMoves = GetPossibleMoves(shell, cx, cy);

                for (int i = 0; i < 3; i ++)
                {
                    if (currentMoves[i])
                    {                       
                        currentMoves[i] = Random.Range(0, 3) != 1;
                        if (!currentMoves[0] && !currentMoves[1] && !currentMoves[2])
                        {
                            currentMoves[i] = true;
                        }
                    }
                }
                
                if (currentMoves[0])
                {
                    // Add top edge
                    if (chunk[shell.x, shell.y + 1] == null)
                    {
                        chunk[shell.x, shell.y + 1] = new GenerationMapShell(shell.x, shell.y + 1);
                        stepMoves.Add(chunk[shell.x, shell.y + 1]);
                    }
                    AddEdge(shell, chunk[shell.x, shell.y + 1]);
                }
                if (currentMoves[1])
                {
                    // Add left edge
                    if (chunk[shell.x - 1, shell.y] == null)
                    {
                        chunk[shell.x - 1, shell.y] = new GenerationMapShell(shell.x - 1, shell.y);
                        stepMoves.Add(chunk[shell.x - 1, shell.y]);
                    }
                    AddEdge(shell, chunk[shell.x - 1, shell.y]);
                }
                if (currentMoves[2])
                {
                    // Add right edge
                    if (chunk[shell.x + 1, shell.y] == null)
                    {
                        chunk[shell.x + 1, shell.y] = new GenerationMapShell(shell.x + 1, shell.y);
                        stepMoves.Add(chunk[shell.x + 1, shell.y]);
                    }
                    AddEdge(shell, chunk[shell.x + 1, shell.y]);
                }
            }
            prevMoves = stepMoves;
        }

        return chunk;
    }

    private bool ValidateChunk(GenerationMapShell[,] unvalidiated_chunk, int cx, int cy)
    {
        // get end position
        int center = (cx / 2);
        var endPosition = unvalidiated_chunk[center, cy - 1];

        // check the edges connected to end position
        if (endPosition.up == null && endPosition.down == null 
            && endPosition.left == null && endPosition.right == null)
        {
            return false;
        }
        return true;
    }

    /* Never report backwards
     * Up: 0
     * Left: 1
     * Right: 2
     */
    private bool[] GetPossibleMoves(GenerationMapShell shell, int cx, int cy)
    {
        bool[] ret = new bool[3];
        int x = shell.x;
        int y = shell.y;

        ret[0] = (y + 1 < cy);
        ret[1] = (x - 1 >= 0);
        ret[2] = (x + 1 < cx);

        return ret;
    }

    private void AddEdge(GenerationMapShell s1, GenerationMapShell s2)
    {
        int xDiff = s1.x - s2.x;
        int yDiff = s1.y - s2.y;

        if (xDiff == 1)
        {
            s1.left = s2;
            s2.right = s1;
            return;
        }
        else if (xDiff == -1)
        {
            s1.right = s2;
            s2.left = s1;
            return;
        }

        if (yDiff == 1)
        {
            s1.up = s2;
            s2.down = s1;
            return;
        }
        else if (yDiff == -1)
        {
            s1.down = s2;
            s2.up = s1;
            return;
        }
    }

    private void PopulateChunk(GenerationMapShell[,] chunk, int cx, int cy)
    {
        ITemplateContainer container = null;
        try
        {
            container = gameObject.GetComponent<TemplateContainer>();
        }
        catch (System.Exception ex)
        {
            // TODO: try to find other method to get container
        }

        for (int x =  0; x < cx; x++)
        {
            for (int y = 0; y < cy; y++)
            {
                var shell = chunk[x, y];
                if (shell != null)
                {
                    int edges = 0;
                    bool[] edgelocations = { false, false, false, false }; //0-U 1-D 2-L 3-R

                    if (shell.up != null)
                    {
                        edges++;
                        edgelocations[0] = true;
                    }
                    if (shell.down != null)
                    {
                        edges++;
                        edgelocations[1] = true;
                    }
                    if (shell.left != null)
                    {
                        edges++;
                        edgelocations[2] = true;
                    }
                    if (shell.right != null)
                    {
                        edges++;
                        edgelocations[3] = true;
                    }

                    if (container == null)
                    {
                        container = new ResourceTemplateContainer();
                    }

                    string moniker = "";
                    // Decide Shape
                    if (edges == 1)
                    {
                        // DE Connector
                        moniker = "DeadEndRoom";
                    }
                    else if (edges == 2)
                    {
                        // I or L Connector
                        // UpDown or LeftRight
                        if ((edgelocations[0] && edgelocations[1]) || (edgelocations[2] && edgelocations[3]))
                        {
                            moniker = "I-Connector";
                        }
                        else
                        {
                            moniker = "L-Connector";
                        }

                    }
                    else if (edges == 3)
                    {
                        // T Connector
                        moniker = "T-Connector";
                    }
                    else if (edges == 4)
                    {
                        // Center Connector
                        moniker = "4-Connector";
                    }

                    // Set the shell template -> chunk is now active
                    shell.template = container.retrieve(moniker);
                }
            }
        }
    }

    private void InstantiateChunk(GenerationMapShell[,] activeChunk, int cx, int cy)
    {
        for (int x = 0; x < cx; x++)
        {
            for (int y = 0; y < cy; y++)
            {
                var activeChunkElem = activeChunk[x, y];

                // Get the GameObject

                // Generate Quaternion

                // Find the entrances of the object
                
                // connect 
            }
        }
    }

    private void DEBUGChunkGeneration(GenerationMapShell[,] chunk, int cx, int cy)
    {
        string output = "";
        for (int j = 0; j < cy; j++)
        {
            string forwards = "";
            string currentline = "";
            for (int i = 0; i < cx; i++)
            {
                string forward = "   ";
                string lr = " o ";
                var c = chunk[i, j];
                if (c != null)
                {
                    if (i == (cx / 2) && j == 0) lr = "s";
                    else if (i == (cx / 2) && j == cy - 1) lr = "e";
                    else lr = "x";

                    if (c.left != null) lr = "-" + lr;
                    else lr = " " + lr;

                    if (c.up != null) forward = "  |  ";
                    else forward = "     ";

                    if (c.right != null) lr = lr + "-";
                    else lr = lr + " ";
                }
                currentline += lr;
                forwards += forward;
            }
            output += forwards + "\n" + currentline + "\n";
        }
        Debug.Log(output);
    }

    private class GenerationMove 
    {
        public bool left, right, up, down;
    }

    private class GenerationMapShell 
    {
        public int x;
        public int y;
        public GenerationMapShell left;
        public GenerationMapShell right;
        public GenerationMapShell up;
        public GenerationMapShell down;
        public GameObject template;
        public GenerationMapShell(int xi, int yi) { 
            x = xi; y = yi; 
        }
    }

    private class ResourceTemplateContainer : ITemplateContainer
    {
        public GameObject retrieve(string moniker)
        {
            GameObject res = Resources.Load<GameObject>($"MapTemplates/{moniker}");
            return res;
        }
    }

}
