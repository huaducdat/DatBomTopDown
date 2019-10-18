using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject player;
   
    public float speedCap = 0.8f;
    public int count = 0;
    public Scriptable scriptable;
    public float capDistance;
    public float distanceCollision;
    public Transform boom;
    public float speedRotate = 100;
    
    void Rotate()
    {


        //Vector3 relativePos = player.transform.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(relativePos);
        //rotation.x = transform.rotation.x;
        //rotation.y = transform.rotation.y;

        //transform.rotation = rotation;


        //Vector3 offset = player.transform.position - transform.position;

        //// Construct a rotation as in the y+ case.
        //Quaternion rotation = Quaternion.LookRotation(Vector3.forward,offset);

        //// Apply a compensating rotation that twists x+ to y+ before the rotation above.
        //transform.rotation = rotation * Quaternion.Euler(0, 0, 180);

        var newRotation = Quaternion.LookRotation(transform.position - player.transform.position, Vector3.forward);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * speedRotate);

        //float step = speedRotate * Time.deltaTime;
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, player.transform.rotation, step);

    }


    void Duoi()
    {

        Vector3 cap = player.transform.position - transform.position;
        float distance = Vector3.Distance(player.transform.position, transform.position);
        
        if (distance < capDistance)
        {
            //Vector3 direction = new Vector3(cap.x, cap.y, 0);
            //transform.Translate(direction * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedCap * Time.deltaTime);

        }
    }

    public void Kill()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < distanceCollision)
        {
            //StopCoroutine("Duoi");
            //Destroy(this);
            
            count = 1;
            
        }               
    }

    public void KillBoom()
    {
        
          
            count = 1;
       
    }

    
  
    void CheckRun()
    {
        if (count < 1)
        {
            Duoi();
            Rotate();
        }
    }
    // Start is called before the first frame update


    void Start()
    {
        capDistance = scriptable.DistanceCap;
        distanceCollision = scriptable.DistanceCollision;
        speedRotate = scriptable._rotateSpeed;


    }

  

    // Update is called once per frame
    void Update()
        {
        

        CheckRun();

        Kill();
       
       
        }
    }

