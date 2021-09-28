﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isTouching : MonoBehaviour
{
    public int isTouchingg = 0;
    CreateWalls CreateWalls;
    public float timer;
    bool change;
    [SerializeField] float tiempoHastaquelaParedDesaparezca;
    WallManager wallManager;
    bool destruir;
    bool isFilling;

    public bool IsFilling { get => isFilling; set => isFilling = value; }
    public float TiempoHastaquelaParedDesaparezca { get => tiempoHastaquelaParedDesaparezca; set => tiempoHastaquelaParedDesaparezca = value; }

    private void Start()
    {

        CreateWalls = GameObject.Find("Player1").GetComponent<CreateWalls>();
        wallManager = GameObject.Find("EnemyManager").GetComponent<WallManager>();
    }
    // Start is called before the first frame update
    private void OnCollisionStay(Collision collision)
    {

        if (gameObject.tag == "firstWall" && collision.gameObject.tag == "lastWall")
        {

            isTouchingg = 1;
            if (change == true && (isTouchingg == 1 || isTouchingg == 0))
            {
                isTouchingg = 2;

            }


        }
        if (gameObject.tag == "lastWall" && collision.gameObject.tag == "firstWall")
        {

            isTouchingg = 1;
            if (change == true && (isTouchingg == 1 || isTouchingg == 0))
            {
                isTouchingg = 2;

            }

        }
        if (CreateWalls.creating == true && collision.gameObject.tag == "Enemy")
        {
            if (CreateWalls.wallClones.Count != 0 &&( gameObject.tag != "Done"&& gameObject.tag != "Capturing"))
            {
                StartCoroutine("Timer");

              
            }
        }
        if(gameObject.tag == "Done" && collision.gameObject.tag == "Capturing")
        {
            gameObject.tag = "Capturing";
        }



    }
    public void Update()
    {
       


            if (gameObject.tag == "lastWall" || gameObject.tag == "firstWall")
        {
            if (isTouchingg == 1 && CreateWalls.erase == true)
            {
                CreateWalls.wallClones[0].GetComponent<autoFillColor>().EnabledColor();
                foreach (GameObject wall in CreateWalls.wallClones)
                {

                    wall.tag = "Done";

                }
                
                Change();

                

                CreateWalls.wallClones.Clear();
                CreateWalls.erase = false;



            }
            if (CreateWalls.buttonpressed == false && isTouchingg == 0 && CreateWalls.erase == true && gameObject.tag != "Done")
            {

                if (CreateWalls.wallClones.Count != 0)
                {

                    if (CreateWalls.erase == true && isTouchingg == 0)
                    {


                        foreach (GameObject wall in CreateWalls.wallClones)
                        {

                            Destroy(wall);

                        }


                        CreateWalls.wallClones.TrimExcess();
                        CreateWalls.wallClones.Clear();
                        CreateWalls.erase = false;

                    }

                }
                else if (CreateWalls.wallClones.Count == 0)
                {
                    Destroy(gameObject);
                }


            }


        }
    }
    void Change()
    {
        change = true;
    }
    void findOthers()
    {

    }
    IEnumerator Timer()
    {
        isFilling = true;
        yield return new WaitForSeconds(1.4f);
        isFilling = false;

            destruir = true;
            if (destruir == true && (gameObject.tag != "Done" || gameObject.tag != "Capturing"))
            {


                foreach (GameObject wall in CreateWalls.wallClones)
                {

                    Destroy(wall);

                }
                CreateWalls.wallClones.TrimExcess();
                CreateWalls.wallClones.Clear();
                destruir = false;
            }

        
    }

    // Update is called once per frame

}
