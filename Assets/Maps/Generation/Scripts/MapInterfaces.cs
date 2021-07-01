using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;
using UnityEngine;

public class GeneratedMap 
{
    public int _gridWidth;

    public int _gridHeight;

    private MapTemplate[][] _map;
    
    public MapTemplate getTileAt(int x, int y)
    {
        return _map[x][y];
    }
}

public abstract class MapTemplate 
{
    // TODO: Implement default grid orientation
    private Quaternion GridOrientation => new Quaternion();

    private GameObject _mapTemplate;

    public bool Render 
    {
        get
        {
            return _mapTemplate.active;
        }
        set
        {
            _mapTemplate.active = value;
        }
    }

    public enum MapOrientation 
    { 
        North,
        South,
        East,
        West
    }

    private Quaternion getGridRotation(MapOrientation orientation)
    {
        return new Quaternion();
    }

    private Vector3 getGridPosition(int gridX, int gridY)
    {
        return new Vector3();
    }
}

