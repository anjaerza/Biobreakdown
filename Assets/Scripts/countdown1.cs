using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class countdown1 : MonoBehaviour
{
    [SerializeField] private float timer;
    public Text textbox;
    Recolector rec;
    public int numeroGeneradores;
    public PlayerHealth playerHealth;
    [SerializeField] string escena;

    // Start is called before the first frame update
    void Start()
    {

        textbox.text = timer.ToString();
        rec = GetComponent<Recolector>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        textbox.text = Mathf.Round(timer).ToString();
        if (playerHealth.currentHealth <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }

        if (timer <= 0)
        {
            GameObject[] generadores = GameObject.FindGameObjectsWithTag("GeneratorOn");
            if (generadores.Length == numeroGeneradores)
            {
                SceneManager.LoadScene(escena);
                Debug.Log("Ganaste");
            }
            if (generadores.Length != numeroGeneradores)
            {
                SceneManager.LoadScene("Derrota");
                Debug.Log("Perdiste por generadores");
            }

            timer = 0;
        }
    }
}
