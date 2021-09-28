using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isActivated : MonoBehaviour
{
    public bool activated;
    public string generatornumber;
    Recolector player;
    public float hpoints;
    public float initialhp;
    [SerializeField]GameObject tubo1;
    [SerializeField] GameObject tubo2;
    [SerializeField] GameObject tubo3;
    [SerializeField] GameObject tubo4;
    [SerializeField] GameObject tubo5;
    [SerializeField] GameObject tubo6;
    generatorHealth gen;
    [SerializeField]Material activeMaterial;
    [SerializeField] Material notActiveMaterial;
    Material[] materials;
    Renderer renderer1;
    public Image pipo;
    public int numeropartes;
    public bool changecolor = false;
    [SerializeField]countdown gameManager;

    [SerializeField] AudioClip generator;


    // Start is called before the first frame update
    void Start()
    {
        renderer1 = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Recolector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hpoints <= 0)

        {
            AudioSource.PlayClipAtPoint(generator, transform.position);

            activated = false;
            if (generatornumber == "1")
            {
                player.Tubo1 = false;
                player.Tubo2 = false;
                if (numeropartes != 2)
                {
                    player.Tubo3 = false;
                }
                player.Ventilacion1 = false;
                if(tubo1!= null)
                {
                    tubo1.SetActive(true);
                }
                if (tubo2 != null)
                {
                    tubo2.SetActive(true);
                }
                if (tubo3 != null)
                {
                    tubo3.SetActive(true);
                }

                
                StartCoroutine("Timer");
               
            }
            if (gameManager.numeroGeneradores == 2)
            {


                if (generatornumber == "2")
                {
                    player.Tubo4 = false;
                    player.Tubo5 = false;
                    if (numeropartes != 2)
                    {
                        player.Tubo6 = false;
                    }
                    player.Ventilacion2 = false;
                    if (tubo4 != null)
                    {
                        tubo4.SetActive(true);
                    }
                    if (tubo5 != null)
                    {
                        tubo5.SetActive(true);
                    }
                    if (tubo6 != null)
                    {
                        tubo6.SetActive(true);
                    }
                    StartCoroutine("Timer");

                }
            }

        }
        
        if(generatornumber == "1" && player.Ventilacion1 == true)
        {
            activated = true;
        }
       
        if(generatornumber =="2" && player.Ventilacion2 == true)
        {
            activated = true;
        }
        
        if(activated == true)
        {
            gameObject.tag = "GeneratorOn";
            materials = renderer1.materials;
            materials[5] = activeMaterial;
            materials[4] = activeMaterial;
            renderer1.materials = materials;
        }
        else if( activated ==false)
        {
            gameObject.tag = "Generator";
            materials = renderer1.materials;
            materials[5] = notActiveMaterial;
            materials[4] = notActiveMaterial;
            renderer1.materials = materials;

        }

      

        
    }
    public void TakeDamage(float damage)
    {
        if(activated == true)
        {
            hpoints -= damage;       
        }     
    }

    IEnumerator Changecolor()
    {
       
        changecolor = true;
        
        yield return new WaitForSeconds(0.5f);
        changecolor = false;
    }
    IEnumerator Timer()
    {

      

        yield return new WaitForSeconds(0.1f);
        hpoints = initialhp;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (activated)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                StartCoroutine("Changecolor");
            }
        }
    }
}
