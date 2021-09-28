using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{
    [SerializeField] bool paused;
    [SerializeField] private float timer;
    public Text textbox;
    Recolector rec;
    WinCondition condition;
    public ParticleSystem system;
    public int numeroGeneradores;
    public PlayerHealth playerHealth;
    public int nivel;
    Animator anim;

    public float Timer { get => timer; set => timer = value; }

    // Start is called before the first frame update
    void Start()
    {
        paused=false;


        if (nivel == 1 || nivel == 3)
        {
            condition = GameObject.Find("WinCondition").GetComponent<WinCondition>();
        }
        textbox.text = Timer.ToString();
        rec = GetComponent<Recolector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            paused=!paused;

        }

        

        if(paused==true)
        {
            Time.timeScale=0;
        }
        else
        {
            Time.timeScale=1;
        }

        Timer -= Time.deltaTime;
        textbox.text = Mathf.Round(Timer).ToString();
        if (playerHealth.currentHealth <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
        if (nivel == 1 && condition.Nivel == 1 && condition.wincondition1 == true)
        {
            GameObject.Find("HUDCanvas").GetComponent<GameOverManager>().Win = true;
            if (GameObject.Find("HUDCanvas").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("AnimationEnded"))
            {
                PlayerPrefs.SetInt("nivelActual", 2);
                SceneManager.LoadScene("Level Tutorial 3");
            }
        }
        if (Timer <= 0 )
        {
            GameObject[] generadores =GameObject.FindGameObjectsWithTag("GeneratorOn");

            if(generadores.Length == numeroGeneradores)
            {
                GameObject.Find("HUDCanvas").GetComponent<GameOverManager>().Win = true;
                if (GameObject.Find("HUDCanvas").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("AnimationEnded"))
                {
                   
                    if (nivel == 2 )
                    {
                        PlayerPrefs.SetInt("nivelActual", 3);
                        SceneManager.LoadScene("Level Tutorial 2");
                    }
                    if (nivel == 3)
                    {
                        PlayerPrefs.SetInt("nivelActual", 4);
                        SceneManager.LoadScene("Level1");
                    }
                    if (nivel == 4)
                    {
                        PlayerPrefs.SetInt("nivelActual", 5);
                        SceneManager.LoadScene("Level2");
                    }
                    if (nivel == 5)
                    {
                        PlayerPrefs.SetInt("nivelActual", 6);
                        SceneManager.LoadScene("Level3");
                    }
                    if (nivel == 6)
                    {
                        PlayerPrefs.SetInt("nivelActual", 7);
                        SceneManager.LoadScene("Level4");
                    }
                    if (nivel == 7)
                    {
                        PlayerPrefs.SetInt("nivelActual", 8);
                        SceneManager.LoadScene("Level5");
                    }
                    if (nivel == 8)
                    {
                        PlayerPrefs.SetInt("nivelActual", 9);
                        SceneManager.LoadScene("Level6");
                    }
                    if (nivel == 9)
                    {
                        SceneManager.LoadScene("Victoria");
                    }
                }

                Debug.Log("Ganaste");
            }
            if (generadores.Length != numeroGeneradores)
            {
                SceneManager.LoadScene("Derrota");
                Debug.Log("Perdiste por generadores");
            }

            Timer = 0;
        }
    }

    
}
