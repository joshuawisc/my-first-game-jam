using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostNPCController : MonoBehaviour
{
    public SphereCollider sight;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " Entered Sight");
        if (other.CompareTag("Player"))
        {
            anim.SetBool("isIdling", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("isIdling", false);
            anim.SetBool("isRunning", true);
            anim.SetBool("isAttacking", false);
        }

    }
}
