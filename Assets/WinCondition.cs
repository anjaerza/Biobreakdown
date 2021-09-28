using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    GameObject[] walls;
    [SerializeField]int nivel;
    public bool wincondition1;
       public  bool wincondition2;

    public int Nivel { get => nivel; set => nivel = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Nivel == 1)
        {


            walls = GameObject.FindGameObjectsWithTag("Capturing");
            if (walls.Length > 0)
            {
                wincondition1 = true;
            }
            if (walls.Length == 0 && GameObject.Find("GameManager").GetComponent<countdown>().Timer <= 0)
            {
                SceneManager.LoadScene("Level Tutorial");
            }
        }
        if(Nivel == 3)
        {
            
            if(GameObject.Find("Generador").GetComponent<isActivated>().hpoints <=0)
            {
                SceneManager.LoadScene("Level Tutorial 2");
            }
            else if(GameObject.Find("Generador").GetComponent<isActivated>().hpoints > 0)
            {
                wincondition2 = true;
            }
        }
    }
}
