using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruc : MonoBehaviour
{
    [SerializeField]AudioClip pickUp;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickUp, transform.position);
            gameObject.SetActive(false);
            gameObject.GetComponent<MeshCollider>().enabled = false;

        }  
    }
}
