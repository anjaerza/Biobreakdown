using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allahuAkbar : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    float time;

    [SerializeField] AudioClip boom;
    // Start is called before the first frame update
   

    // Update is called once per frame
   
 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Done" ||other.gameObject.tag == "Capturing")
        {

            Instantiate(explosion, transform.position, transform.rotation);
            StartCoroutine("Timer");

        }
        if(other.gameObject.tag == "limit")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            StartCoroutine("Timer");
        }
    }
    IEnumerator Timer()
    {
        AudioSource.PlayClipAtPoint(boom,transform.position,0.8f);
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);


    }
}
