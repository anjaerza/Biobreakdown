﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = transform.parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
