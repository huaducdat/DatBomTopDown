using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemies enemies = collision.GetComponent<Enemies>();
        if(enemies != null)
        {
            enemies.KillBoom();
        }



    }





    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
