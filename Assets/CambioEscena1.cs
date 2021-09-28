using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena1 : MonoBehaviour
{
    
    [SerializeField] string escena;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("nivelActual", 1);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(escena);

        }
    }
}
