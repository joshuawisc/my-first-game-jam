using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{

    //Not implementing the interface to use the unity inspector as a fast solution
    //So the fields can be directly modified in unity

    public string Type;

    public string Name = "Potion";

    public string Description = "No Effect";


    public void Despawn()
    {
        Destroy(gameObject);//destroy this
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void Spawn(Vector3 input)
    {
        throw new System.NotImplementedException();
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

            Despawn();
        }
    }
}
