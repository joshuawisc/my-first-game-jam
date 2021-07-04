using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, IInteractable, IConsumable
{
    //Fields
    private string _name;
    private string _instanceID;
    private string _type;
    private string _description;

    private PlayableCharacter player;

    public GameObject InGameObject => gameObject;

    public string InstanceID => _instanceID;

    public string Type => _type;

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

    public string Description
    {
        get
        {
            return _description;
        }

        set
        {
            _description = value;
        }
    }

    public void Despawn()
    {
        Destroy(gameObject);
    }

    public void Interact()
    {
        Use();
    }

    public void Spawn(Vector3 input)
    {
        Instantiate(gameObject, input, Quaternion.identity);
    }

    public void Use()
    {
        //hard coded effect
        player.Damage(-10);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayableCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
