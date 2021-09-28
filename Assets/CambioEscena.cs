using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    int nivelActual;
    
    // Start is called before the first frame update
    void Start()
    {
        nivelActual = PlayerPrefs.GetInt("nivelActual", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(nivelActual == 1)
            {
                SceneManager.LoadScene("Level Tutorial");
            }
            if (nivelActual == 2)
            {
                SceneManager.LoadScene("Level Tutorial 3");
            }
            if (nivelActual == 3)
            {
                SceneManager.LoadScene("Level Tutorial 2");
            }
            if (nivelActual == 4)
            {
                SceneManager.LoadScene("Level1");
            }
            if (nivelActual == 5)
            {
                SceneManager.LoadScene("Level2");
            }
            if (nivelActual == 6)
            {
                SceneManager.LoadScene("Level3");
            }
            if (nivelActual == 7)
            {
                SceneManager.LoadScene("Level4");
            }
            if (nivelActual == 8)
            {
                SceneManager.LoadScene("Level5");
            }
            if (nivelActual == 9)
            {
                SceneManager.LoadScene("Level6");
            }
            if (nivelActual == 10)
            {
                SceneManager.LoadScene("Level7");
            }

        }
    }
}
