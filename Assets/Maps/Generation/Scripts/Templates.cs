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
}