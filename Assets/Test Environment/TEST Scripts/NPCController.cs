using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A simple script for controlling NPC movements for animation testing purposes
 * 
 * Remember to remove it from the NPC after implementing AI
 */
public class NPCController : MonoBehaviour
{
    Animator anim;

    public float runSpeed = 0.2f;
    public float sprintSpeed = 0.4f;
    public float rotationSpeed = 10f;

    //destination
    Vector3 dest = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Manual Control when pressing the left control
        //if (Input.GetKey(KeyCode.LeftControl))
        //{
        //    float x = Input.GetAxis("Horizontal");
        //    float z = Input.GetAxis("Vertical");

        //    if (x != 0 || z != 0)
        //    {
        //        dest.x = transform.position.x + x;
        //        dest.z = transform.position.z + z;
        //        dest.y = transform.position.y;
        //        Debug.Log(dest);
        //    }

        //}

        //If click left mouse button, move self to the target position
        if (Input.GetMouseButtonDown(0))
        {
            //Fire ray from camera to mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                dest = hit.point;
            }
        }

        //does not consider jumping for now
        dest.y = 0;
        MoveTo(dest);
    }

    void MoveTo(Vector3 destination)
    {
        //move itself to the destination
        float distance = Vector3.Distance(dest, transform.position);

        //Cuz lazy, just used look at and forward
        transform.LookAt(dest);
        
        //Sprint if too far away
        if (distance > 10f)
        {
           
            anim.SetBool("isIdling", false);
            anim.SetBool("isSprinting", true);
            anim.SetBool("isRunning", false);
            transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
        }
        //Run if within 10 distance
        else if (distance > 0.5f)
        {
            anim.SetBool("isIdling", false);
            anim.SetBool("isSprinting", false);
            anim.SetBool("isRunning", true);
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);

        }
        //idle if at the destination
        else
        {
            anim.SetBool("isIdling", true);
            anim.SetBool("isSprinting", false);
            anim.SetBool("isRunning", false);
        }

        
    }
}
