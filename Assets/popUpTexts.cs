using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class popUpTexts : MonoBehaviour
{
    [SerializeField]Text[] textos;
    [SerializeField] GameObject[] generators;
    [SerializeField]List<GameObject> activeGens;
    [SerializeField] List<GameObject> distinct;

    [SerializeField] int counter;
    [SerializeField]countdown gameManager;
    float showtime1;
    float showtime2;
    float showtime3;
    float showtime4;
    float showtime5;
    float showtime6;

    bool canReset1 = false;
    bool canReset2 = false;
    bool canReset3 = false;
    bool canReset4 = false;
    bool canReset5 = false;
    bool canReset6 = false;

    bool AllGensActivated;
    bool GeneratorGamaged;
    bool GeneratorDestroyed;
    bool GeneratorActivated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        //FIRST MESSAGE
        showtime1 += Time.deltaTime;
       
        foreach (Text texto in textos)
        {
            if (texto.name == "BegginingMessage1")
            {
                if (canReset1 == false)
                {
                    canReset1 = true;
                    texto.enabled = true;
                    texto.GetComponent<TypeOutScript>().reset = true;
                    texto.GetComponent<TypeOutScript>().On = true;

                   
                }
                if (showtime1 >= 5)
                {
                    texto.enabled = false;
                }
            }
            


        }

        //SECOND MESSAGE

        showtime2 += Time.deltaTime;

        foreach (Text text in textos)
        {
            if (text.name == "BegginingMessage2" && showtime2 >= 5)
            {
                if (canReset2 == false)
                {




                    canReset2 = true;
                    text.enabled = true;

                    text.GetComponent<TypeOutScript>().reset = true;
                    text.GetComponent<TypeOutScript>().On = true;



                }
                if (showtime1 >= 10)
                {
                    text.enabled = false;
                }


            }
            

        }
        // Generator destroyed
        for (int i = 0; i < generators.Length; i++)
        {
            if( generators[i].GetComponent<isActivated>().hpoints <= 0)
            {
                GeneratorDestroyed = true;
            }
        }
        if(GeneratorDestroyed)
        {
            showtime6 = 40;
            showtime3 += Time.deltaTime;
            
           
            for (int i = 0; i < textos.Length; i++)
            {
               
                if (textos[i].name == "DestroyedGenerator")
                {
                   textos[i].enabled = true;
                    if (canReset3 == false)
                    {
                        canReset3 = true;
                        textos[i].GetComponent<TypeOutScript>().reset = true;
                        textos[i].GetComponent<TypeOutScript>().On = true;
                        // las acciones que quieres que se cancelen
                        showtime4 = 5;
                        showtime6 = 40;
                       
                    }
                    if (showtime3 >= 5)
                    {
                        textos[i].GetComponent<TypeOutScript>().reset = true;
                        showtime3 = 0;
                       
                        textos[i].enabled = false;
                        GeneratorDestroyed = false;
                        canReset3 = false;

                    }

                }
                   
                
               

            }
        }
        // Generator with low hp
        for (int i = 0; i < generators.Length; i++)
        {
            if (generators[i].GetComponent<isActivated>().hpoints <= (70) * (generators[i].GetComponent<isActivated>().initialhp) / (100) && generators[i].GetComponent<isActivated>().hpoints>0)
            {
                GeneratorGamaged = true;
            }
        }
        if (GeneratorGamaged)
        {
            showtime4 += Time.deltaTime;


            for (int i = 0; i < textos.Length; i++)
            {

                if (textos[i].name == "GenWithLowHP")
                {
                    textos[i].enabled = true;
                    if (canReset4 == false)
                    {
                        canReset4 = true;
                        textos[i].GetComponent<TypeOutScript>().reset = true;
                        textos[i].GetComponent<TypeOutScript>().On = true;
                        showtime6 = 5;

                    }
                    if (showtime4 >= 5||GeneratorDestroyed)
                    {
                       
                        
                        textos[i].GetComponent<TypeOutScript>().reset = true;

                        textos[i].enabled = false;
                        GeneratorGamaged = false;
                        canReset4 = false;
                        showtime4 = 0;

                    }

                }




            }
        }
        // AllPartsPickedUp1
        if (gameManager.numeroGeneradores != 1)
        {
            for (int i = 0; i < generators.Length; i++)
            {
                if (generators[i].GetComponent<isActivated>().activated)
                {
                    GeneratorActivated = true;
                }
            }
            if (GeneratorActivated)
            {
                showtime5 += Time.deltaTime;


                for (int i = 0; i < textos.Length; i++)
                {

                    if (textos[i].name == "AllPartsPickedUp1")
                    {
                        textos[i].enabled = true;
                        if (canReset5 == false)
                        {
                            canReset5 = true;
                            textos[i].GetComponent<TypeOutScript>().reset = true;
                            textos[i].GetComponent<TypeOutScript>().On = true;
                            showtime1 = 10;
                            showtime2 = 5;
                            showtime3 = 5;
                            showtime4 = 5;
                        }
                        if (showtime5 >= 5)
                        {


                            textos[i].GetComponent<TypeOutScript>().reset = true;

                            textos[i].enabled = false;
                            GeneratorActivated = false;

                            showtime5 = 0;

                        }

                    }




                }
            }
        }
        // AllGeneratorsActivated
        for (int i = 0; i < generators.Length; i++)
        {
           


                if (generators[i].GetComponent<isActivated>().activated)
                {
                    activeGens.Add(generators[i]);
                    
                    if (activeGens.Contains(generators[i]))
                    {


                    distinct = activeGens.Distinct().ToList();
                }
                
                 }
            
        }
      
        if (distinct.Count == gameManager.numeroGeneradores)
        {
            AllGensActivated = true;
            activeGens.Clear();

        }
        if (AllGensActivated)
        {
            showtime6 += Time.deltaTime;
            showtime4 = 5;

            for (int i = 0; i < textos.Length; i++)
            {

                if (textos[i].name == "AllGeneratorsActivated")
                {
                    textos[i].enabled = true;
                    if (canReset6 == false)
                    {
                        canReset6 = true;
                        textos[i].GetComponent<TypeOutScript>().reset = true;
                        textos[i].GetComponent<TypeOutScript>().On = true;
                        showtime1 = 10;
                        showtime2 = 5;
                        showtime3 = 5;
                        
                        showtime5 = 5;
                    }
                    if (showtime6 >= 40||distinct.Count != gameManager.numeroGeneradores)
                    {


                        textos[i].GetComponent<TypeOutScript>().reset = true;

                        textos[i].enabled = false;
                        AllGensActivated = false;
                        canReset6 = false;
                        showtime6 = 0;

                    }

                }




            }
        }
    }
}
