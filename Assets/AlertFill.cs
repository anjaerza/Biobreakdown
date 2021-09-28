using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertFill : MonoBehaviour
{
    CreateWalls createWalls;
    isTouching[] walls;
    bool isFilling;
    Image imagen;
    float timer;
    Image alertaFill;
    Image alertaDraw;
    bool canAlert=true;
    
    [SerializeField]GameObject alertaDrawGO;
    // Start is called before the first frame update
    void Start()
    {
        alertaFill = gameObject.GetComponent<Image>();
        alertaDraw = alertaDrawGO.GetComponent<Image>();
        imagen = GetComponent<Image>();
        alertaFill.enabled = false;
        alertaDraw.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (isFilling)
        {
            alertaFill.enabled = true;
            alertaDraw.enabled = true;
            Fill();
        }

        if (isFilling==false)
        {
            alertaFill.enabled = false;
            alertaDraw.enabled = false;
            
        }
        walls = FindObjectsOfType(typeof(isTouching)) as isTouching[];
        for (int i = 0; i < walls.Length; i++)
        {
            if (canAlert == true)
            {


                if (walls[i].IsFilling == true)
                {

                    isFilling = true;
                    StartCoroutine("Revision");
                }
            }
        }
    }
    void Fill()
    {
        timer += Time.deltaTime;
        imagen.fillAmount = timer / 1.4f;
        
        
        if(imagen.fillAmount >= 1)
        {
            isFilling = false;
            timer = 0;
            
        }
        
    }
    IEnumerator Revision()
    {
        canAlert = false;
        yield return new WaitForSeconds(1.5f);
        canAlert = true;


    }
}
