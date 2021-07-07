using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractableObject
{
    [SerializeField] Animator anim;
    bool isOpened;
    bool unlocked;
    PlayableCharacter player;

    //int interactionCooldown = 2;
    bool interactable = true;

    public int keyRequirement; //how many keys are required to open this door


    public GameObject InGameObject => gameObject;

    public string InstanceID => throw new System.NotImplementedException();

    public string Type => throw new System.NotImplementedException();

    public string Name => "Wooden Door";

    public string Description => "Requires 1 key to open";

    public void ApplyForce(Vector3 direction, float magnitude)
    {
        throw new System.NotImplementedException();
    }

    public void Despawn()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        if (isOpened) //probably add other constraints to close doors
        {
            //if the door is opened, close it
            Close();
        }

        else if (player.Key >= keyRequirement || unlocked)
        {
            //open the door if the player has the keys or the door is already unlocked
            //TODO: maybe require the player to be out of combat before opening the doors

            if (!unlocked)
            {
                unlocked = true;
                player.addKey(-keyRequirement);
            }

            Open();
        }
    }

    public void setState(string stateID, string state)
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

        isOpened = false;
        unlocked = false;
        player = FindObjectOfType<PlayableCharacter>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            Interact();
            interactable = false;
        }

    }

    //A temp way of interacting with the doors
    private void OnTriggerStay(Collider other)
    {

        //if the player is in the trigger area, interactable
        if (other.tag.Equals("Player"))
        {
            interactable = true;

            //StartCoroutine(StopInteraction());
        }

    }

    private void Close()
    {
        anim.SetTrigger("close");
        isOpened = !isOpened;
    }

    private void Open()
    {
        anim.SetTrigger("open");
        isOpened = !isOpened;
    }

    //Allow interaction after the interaction cool down
    //IEnumerator StopInteraction()
    //{
    //    interactable = false;

    //    yield return new WaitForSeconds(interactionCooldown);

    //    interactable = true;
    //}
}
