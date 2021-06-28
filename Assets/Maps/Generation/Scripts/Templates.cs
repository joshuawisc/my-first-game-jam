using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;
using UnityEngine;

/*
 * Public interface for MapTemplate Objects
 * Parent to things like, Enemy Room, Item Room, Hallway (and other roomtypes)
 * Needs properties like rawPosition, gridPosition, template prefab
 * Needs Methods like getConnections
 */
public interface IMapTemplate
{
    Vector3 RawPosition { get; set; }

    Vector2 GridPosition { get; set; }

    GameObject TemplateAsset { get; set; }
    string type { get; }
    void Load(GameObject clone);
}


public class CenterTemplate : IMapTemplate
{

    public string type => "Center";

    // This is for a room with 4 open doors.
    private Vector3 _rawPosition;
    public Vector3 RawPosition { 
        get
        {
            return _rawPosition;
        }
        set
        {
            _rawPosition = value;
        }
    }

    Vector2 _gridPosition;
    public Vector2 GridPosition 
    {
        get
        {
            return _gridPosition;
        }
        set
        {
            _gridPosition = value;
        }
    }

    private GameObject _templateAsset;
    public GameObject TemplateAsset 
    {
        get
        {
            return _templateAsset;
        }
        set
        {
            _templateAsset = value;
        }
    }

    public void Load(GameObject clone)
    {

    }
}
