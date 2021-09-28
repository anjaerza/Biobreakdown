using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    // This element is not "public" because the enemies are instantiated during gameplay, so the reference to the player needs to be established at runtime.
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    Vector3 distanceBetween;
    Recolector recolector;
    float distance;
    [SerializeField]GameObject siguiendogenerador;
   
    [SerializeField]string type;
    [SerializeField]bool activated;
    [SerializeField] bool following;
    
    public GameObject[] donewalls;
    public GameObject[] generadores;
    public float[] wallsdistances;
    public float[] generatordistances;


    private Animator anim;
    bool dancing;
    
   


    void Awake ()
    {
        recolector = GameObject.FindGameObjectWithTag("Player").GetComponent<Recolector>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent>();
        anim= GetComponent<Animator>();
    }


    void Update ()
    {
        
        if (GameObject.Find("HUDCanvas").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("GameOverClip"))
        {
            anim.SetBool("Dance", true);
            dancing = true;
        }
        
            distanceBetween = player.position - transform.position;
        distanceBetween.y = 0;
        distance = distanceBetween.magnitude;
        if (distance <= 8.15789473684)
        {
           
            activated = true;
            following = true;
            anim.SetBool("Following",true);
           
        }
        if (distance > 8.15789473684)
        {
            activated = false;
            anim.SetBool("Following",false);

        }
       

        if (type == "Normal")
        {

            if (dancing ==false)
            {

                if (activated == false && ((recolector.Ventilacion1 == true || recolector.Ventilacion2 == true) || (recolector.Ventilacion1 == true && recolector.Ventilacion2 == true)))
                {

                    float mindistance = Mathf.Infinity;
                    generadores = GameObject.FindGameObjectsWithTag("GeneratorOn");

                    if (generadores.Length != 0)
                    {

                        generatordistances = new float[generadores.Length];
                        for (int i = 0; i < generadores.Length; i++)
                        {


                            generatordistances[i] = Vector3.Distance(gameObject.transform.position, generadores[i].transform.position);

                            if (generatordistances[i] < mindistance)
                            {

                                mindistance = generatordistances[i];
                                if (generatordistances[i] == mindistance)
                                {

                                    nav.SetDestination(generadores[i].transform.position);
                                    siguiendogenerador = generadores[i];

                                }
                            }





                        }
                    }

                }
                else if (following == true)
                {


                    nav.SetDestination(player.position);

                }
            }
            else if (dancing)
            {

                following = false;
                activated = true;
                nav.SetDestination(gameObject.transform.position);
            }

        }
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && following == true && type == "Big")
        {
            if (dancing == false)
            {


                donewalls = GameObject.FindGameObjectsWithTag("Capturing");
                wallsdistances = new float[donewalls.Length];

                if (donewalls.Length != 0)
                {
                    for (int i = 0; i < donewalls.Length; i++)
                    {


                        wallsdistances[i] = Vector3.Distance(gameObject.transform.position, donewalls[i].transform.position);
                        float min = Mathf.Infinity;
                        if (wallsdistances[i] < min)
                        {

                            min = wallsdistances[i];
                            if (wallsdistances[i] == min)
                            {

                                nav.SetDestination(donewalls[i].transform.position);
                            }
                        }





                    }
                }

                else
                {
                    nav.SetDestination(player.position);
                    
                }
            }
            else if (dancing)
            {
                nav.SetDestination(gameObject.transform.position);
            }
        }
        

    }
    
}
