using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;
using UnityEngine;
using System.Text;

/*
 * Public interface for any serializeable/deserializable object
 * Must have a serialize() deserialize() 
 */
public interface ISerializable 
{
    string serialize();
    string deserialize();
}