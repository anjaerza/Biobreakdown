using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isEnemyNear : MonoBehaviour
{
    public GameObject[] generadores;
    [SerializeField]GameObject circle;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {

        
        generadores = GameObject.FindGameObjectsWithTag("GeneratorOn");

        if (generadores.Length == 0)
        {
            circle.GetComponent<MeshRenderer>().enabled = false;
        }
        if (generadores.Length != 0)
        {
            circle.GetComponent<MeshRenderer>().enabled = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (generadores.Length != 0)
        {
            if (other.gameObject.tag == "Enemy")
            {


                circle.GetComponent<Renderer>().sharedMaterial.SetFloat("_RimPower", 1.78f);
                circle.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
                circle.GetComponent<Renderer>().sharedMaterial.SetColor("_RimColor", new Color(1f, 0.00989685f, 0f, 1f));
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (generadores.Length != 0)
        {
            if (other.gameObject.tag == "Enemy")
            {
                circle.GetComponent<Renderer>().sharedMaterial.SetFloat("_RimPower", 1.78f);
                circle.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
                circle.GetComponent<Renderer>().sharedMaterial.SetColor("_RimColor", new Color(1f, 1f, 1f, 1f));
            }
        }
    }
}
