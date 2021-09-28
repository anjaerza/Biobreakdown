using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class destroywalls : MonoBehaviour
{
    public float hpoints;
    [SerializeField] List<Collider> collidedObjects = new List<Collider>();
    public bool up = true;
    [SerializeField] Color colorGolpeado;
    [SerializeField] Color colorInicial;
    [SerializeField] Color awakeColor;

    float timer;
    [SerializeField] float timeToReachTarget;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    float actualHp;

    AudioSource globalSound;

    // Start is called before the first frame update
    private void Start()
    {
        globalSound = GameObject.Find("GlobalAudio").GetComponent<AudioSource>();
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();

        _propBlock.SetColor("_RimColor", colorGolpeado);
        _renderer.SetPropertyBlock(_propBlock);
    }

    // Update is called once per frame
    private void Update()
    {
        _renderer.GetPropertyBlock(_propBlock);


    }
    private void OnCollisionStay(Collision collision)
    {
        if (!collidedObjects.Contains(collision.collider) && collision.collider.tag == "Done")
        {
            collidedObjects.Add(collision.collider);
            StartCoroutine("Timer2");

        }


        if ((collision.gameObject.tag == "Done" && gameObject.tag == "Done" && hpoints <= 0) || (collision.gameObject.tag == "Capturing" && gameObject.tag == "Capturing" && hpoints <= 0))
        {
            collision.gameObject.GetComponent<destroywalls>().hpoints = 0;
            StartCoroutine("Timer");

        }
        if (collision.gameObject.tag == "Enemy")
        {
            colorGolpeado = Color.Lerp(colorInicial, Color.black, Mathf.PingPong(Time.time, 0.4f));

            _propBlock.SetColor("_RimColor", colorInicial);
            _renderer.SetPropertyBlock(_propBlock);
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _propBlock.SetColor("_RimColor", awakeColor);
            _renderer.SetPropertyBlock(_propBlock);
        }
    }
    public void TakeDamage(float damage)
    {




        hpoints -= damage;

    }

    IEnumerator Timer()
    {

        if (!globalSound.isPlaying)
        {
            globalSound.Play();
        }
        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);


    }
    IEnumerator Timer2()
    {
        yield return new WaitForSeconds(0.2f);
        if (gameObject.tag == "Done" && collidedObjects.Count < 2)
        {
            Destroy(gameObject);
        }
    }
}