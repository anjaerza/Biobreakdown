using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generatorHealth : MonoBehaviour
{
    Image healthbar;
    private float maxhealth;
    public GameObject Generator;
    float health;
    Animation an;
    public Gradient gradient;
    public Image fill;


    // Start is called before the first frame update
    void Start()
    {
        maxhealth = Generator.GetComponent<isActivated>().initialhp;
        healthbar = GetComponent<Image>();
        an = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        health = Generator.GetComponent<isActivated>().hpoints;
        healthbar.fillAmount = health / maxhealth;

        fill.color = gradient.Evaluate(healthbar.fillAmount);
    }

}
