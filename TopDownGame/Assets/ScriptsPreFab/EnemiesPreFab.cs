﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPreFab : MonoBehaviour
{
    public GameObject preFab;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject charMain = Instantiate(preFab) as GameObject;
        charMain.transform.position = new Vector3(3, 2, 0);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
