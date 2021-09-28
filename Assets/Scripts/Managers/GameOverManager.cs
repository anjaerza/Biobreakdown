using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    Animator anim;
    bool win;
    [SerializeField]GameObject happyFire;
    AudioSource audiof;
    AudioSource audioi;
    GameObject[] generators;
    bool caninstantiate=true;
    int level;

    public bool Win { get => win; set => win = value; }
    private void Start()
    {
        level = GameObject.Find("GameManager").GetComponent<countdown>().nivel;
        if (level > 3)
        {
            audiof = GameObject.Find("EndMusicPlayer").GetComponent<AudioSource>();
            audioi = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        }
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Win)
        {
            Win = false;
            anim.SetBool("Win", true);
            if (level > 3)
            {
                if (!audiof.isPlaying)
                {
                    audioi.Stop();
                    audiof.Play();
                }
                generators = GameObject.FindGameObjectsWithTag("GeneratorOn");
                if (caninstantiate)
                {
                    caninstantiate = false;
                    for (int i = 0; i < generators.Length; i++)
                    {
                        Instantiate(happyFire, generators[i].transform.position, transform.rotation);
                    }
                }

            }
        }
       
    }
    

}

