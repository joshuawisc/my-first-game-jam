using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour, ICharacter, IDamageable
{
    #region FIELDS

    // position
    private float _xPosition;
    private float _yPosition;
    private float _zPosition;

    // identity
    private string _name;
    private string _instanceID;

    // damageable
    private int _currenthealth;
    private int _maxhealth;

    // prefab
    //private GameObject _self;
    #endregion

    #region Custom Fields

    // Item being held by the right hand on screen
    private IHoldable _mainHandItem;

    private AnimationStateContainer animState;

    #endregion

    #region Custom Properties

    public IHoldable MainHandItem
    {
        get
        {
            return _mainHandItem;
        }
    }

    #endregion

    #region PROPERTIES
    public Vector3 Position
    {
        get
        {
            return gameObject.transform.position;
        }
        set
        {
            _xPosition = value.x;
            _yPosition = value.y;
            _zPosition = value.z;
            gameObject.transform.position = value;
        }
    }
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public string InstanceID => _instanceID;
    public int Health
    {
        get
        {
            // TODO current health formula
            return _currenthealth;
        }
        set
        {
            // avoid this setter
            _currenthealth = value;
        }
    }
    public int MaximumHealth
    {
        get
        {
            return _maxhealth;
        }
        set
        {
            _maxhealth = value;
        }
    }

    public GameObject Actor => gameObject;

    #endregion

    #region PUBLIC METHODS
    public void Damage(int dmg)
    {
        // TODO work out damage formula
        _currenthealth -= dmg;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void MoveTo(Vector3 input)
    {
        throw new NotImplementedException();
    }

    public void Spawn(Vector3 input)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region PRIVATE METHODS

    private void invokeMainHandItem()
    {
        if (_mainHandItem == null)
        {
            return;
        }

        if (_mainHandItem is IConsumeable)
        {
            //TODO change this to consume
            ((IConsumeable)_mainHandItem).Use();
        }

        _mainHandItem.Use();
    }

    private bool equipFromInventorySlot(string accessID)
    {
        //TODO: Get Item from Inventory
        IItem itemFromInventory = null; // Test Item

        if (!(itemFromInventory is IHoldable))
        {
            // The item is not equipable
            return false;
        }

        _mainHandItem = itemFromInventory as IHoldable;
        return true;
    }

    #endregion
    public PlayableCharacter _self;

    private void Initialize()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
