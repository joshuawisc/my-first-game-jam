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

    private List<MapTemplate> _map;

    private MapTemplate _root;

    private MapTemplate _current;

    public MapTemplate Root => _root;

    public MapTemplate CurrentMap => _current;

    public MapTemplate getTileAt(int x, int y)
    {
        // Slow, use this sparingly
        return _map.FirstOrDefault(t => t._gridX == x && t._gridY == y);
    }

    public GeneratedMap(int width, int height)
    {
        // Initialize grid dimensions
        _gridWidth = width;
        _gridHeight = height;

        // Set Dimensions.
        _map = new List<MapTemplate>();
    }
}

public abstract class MapTemplate 
{
    public abstract string name { get; }

    public float[] doorConnectionOffsets;

    public int _gridX;

    public int _gridY;

    public List<MapTemplate> Connections;

    // TODO: Implement default grid orientation
    private Quaternion GridOrientation => new Quaternion();

    protected GameObject _templatePrefab;

    public MapTemplate()
    {
        // Initialize Fields
        Connections = new List<MapTemplate>();
    }

    public bool Render 
    {
        get
        {
            return _templatePrefab.activeSelf;
        }
        set
        {
            _templatePrefab.SetActive(value);
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


public class PrototypeSmallMap : MapTemplate
{
    public override string name => "PrototypeSmallMap";

    public GameObject TemplatePrefab => _templatePrefab;

    public PrototypeSmallMap(GameObject prefab) : base()
    {
        InitializeDoorOffsets();
        _templatePrefab = prefab;

    }

    private void InitializeDoorOffsets()
    {
        doorConnectionOffsets = new float[4];
        // Push door offsets 
    }

}


