using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 1.3f;
    public float rotateSpeed = 2f;
    public GameObject Boom;
    public float timeCD = 1.5f;
    [SerializeField]
    private float timeCount = 2f;
    public Scriptable scriptable;
    

    
    public void Move()
    {
        
        float diChuyenDoc = Input.GetAxis("Vertical") * speed;
        float diChuyenNgang = Input.GetAxis("Horizontal") * speed;
       
        diChuyenDoc *= Time.deltaTime;
        diChuyenNgang *= Time.deltaTime;



        

        transform.Translate(0, diChuyenDoc, 0);
        transform.Translate(diChuyenNgang, 0, 0);


    }
    public void Rotate()
    {


        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
        
        
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        


    }

    

    public void DatBom()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (timeCount >= timeCD)
            {
                GameObject BoomInstan = Instantiate(Boom) as GameObject;
                BoomInstan.transform.position = transform.position;
                timeCount = 0;
                

            }

        }


        
        timeCount += Time.deltaTime;
    }







    //// Start is called before the first frame update
    void Start()
    {
        timeCD = scriptable._timneCd;
        rotateSpeed = scriptable._rotateSpeed;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Move();
    //    Rotate();
    //    DatBom();
    //}
}
