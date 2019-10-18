using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerControl player { get; private set; }
    public Scriptable scriptable;
    
    void Start()
    {
       
        player = GetComponent<PlayerControl>();
        player.speed = scriptable.playerSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        player.Move();
        player.Rotate();
        player.DatBom();


    }

    

}
