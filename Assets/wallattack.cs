using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallattack : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeBetweenAttacks ;
    public int attackDamage ;

    Animator anim;



    bool playerInRange;
    float timer=0.5f;


    void Awake()
    {


        anim = GetComponent<Animator>();

    }
    public void Attackanim()
    {

        anim.SetBool("Attack", false);

    }


    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "GeneratorOn")
        {
            anim.SetBool("Attack", true);
            playerInRange = true;
            if (timer >= timeBetweenAttacks && playerInRange && other.gameObject.GetComponent<isActivated>().hpoints != 0)
            {
                if (GameObject.Find("HUDCanvas").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("GameOverClip"))
                {
                    return;
                }
               

                else if (other.gameObject.GetComponent<isActivated>().hpoints != 0)
                {
                    other.gameObject.GetComponent<isActivated>().TakeDamage(attackDamage);
                    
                }
                timer = 0f;
            }
        }

        if (other.gameObject.tag == "Done" || other.gameObject.tag == "Capturing")
        {
            playerInRange = true;
            if (timer >= timeBetweenAttacks && playerInRange && other.gameObject.GetComponent<destroywalls>().hpoints != 0)
            {
                if (GameObject.Find("HUDCanvas").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("GameOverClip"))
                {
                    return;
                }

                else if (other.gameObject.GetComponent<destroywalls>().hpoints != 0)
                {
                    other.gameObject.GetComponent<destroywalls>().TakeDamage(attackDamage);
                    anim.SetBool("Attack", true);
                }
                timer = 0f;
            }
        }
    }



    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Done" || other.gameObject.tag == "Capturing")
        {
            playerInRange = false;
        }
        if(other.gameObject.tag == "GeneratorOn")
        {
            playerInRange = false;
        }
       
    }


    void Update()
    {
        timer += Time.deltaTime;

        
    }


   
}
