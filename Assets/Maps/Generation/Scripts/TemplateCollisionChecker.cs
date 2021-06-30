using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateCollisionChecker : MonoBehaviour
{

    // If already places in level, don't delete
    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Debug.Log("COLLIDED TEMP SCRIPT");
        // Debug.Log("This: " + this.gameObject);
        // Debug.Log("Other: " + collider.gameObject);
        if (collider.GetType() != typeof(BoxCollider))
            return;
        if (collider.gameObject.tag == "Level" && startTime >= collider.gameObject.GetComponent<TemplateCollisionChecker>().startTime)
        {
            // Debug.Log("This: " + this.gameObject);
            // Debug.Log("Other: " + collider.gameObject);
            Destroy(this.gameObject);
        }
    }
}
