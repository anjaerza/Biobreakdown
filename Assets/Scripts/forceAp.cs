using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceAp : MonoBehaviour
{

    /*private float force = -50f;*/
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        float force = 100;

        if (c.gameObject.tag == "Done" || c.gameObject.tag == "Capturing")
        {
            Vector3 dir = c.contacts[0].point - transform.position;            
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }
}
