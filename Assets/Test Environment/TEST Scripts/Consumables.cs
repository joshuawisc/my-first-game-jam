using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumables : MonoBehaviour, IInteractable, IConsumable
{

    //Fields
    private string _name;
    private string _instanceID;
    private string _type = "Consumables";
    private string _description;

    public PlayableCharacter player;

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

    public abstract void Interact();

    public void Spawn(Vector3 input)
    {
        Instantiate(gameObject, input, Quaternion.identity);
    }

    public abstract void Use();

    public void Initialize()
    {
        player = FindObjectOfType<PlayableCharacter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Add pick up effects
    private void OnCollisionEnter(Collision collision)
    {
        //if player touches it
        if (collision.collider.tag.Equals("Player"))
        {
            //Apply effects
            Debug.Log("Consumed " + Name + ":"+ Description);
            Interact();

            //Remove it
            Despawn();
        }
    }
}
