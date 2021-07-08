using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateContainer : MonoBehaviour, ITemplateContainer
{
    public GameObject FourDoorConnector;
    public GameObject LConnector;
    public GameObject TConnector;
    public GameObject IConnector;
    public GameObject DeadEnd;
    public GameObject Hallway;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject retrieve(string moniker)
    {
        if (moniker.ToLower().Equals("4-Connector"))
        {
            return FourDoorConnector;
        } 
        else if (moniker.ToLower().Equals("L-Connector"))
        {
            return LConnector;
        }
        else if (moniker.ToLower().Equals("T-Connector"))
        {
            return TConnector;
        }
        else if (moniker.ToLower().Equals("I-Connector"))
        {
            return IConnector;
        }
        else if (moniker.ToLower().Equals("DeadEndRoom"))
        {
            return DeadEnd;
        }
        return null;
    }
}

public interface ITemplateContainer
{
    GameObject retrieve(string moniker);
}

