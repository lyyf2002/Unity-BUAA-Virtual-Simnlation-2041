using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    float speed = 20f;
    private Vector3 center = new Vector3(0f,0f,0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.eulerAngles.y);
        if (Input.GetKey(KeyCode.A))
        {
            if(transform.eulerAngles.y < 30f || transform.eulerAngles.y >180)
            transform.RotateAround(center, Vector3.up, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if((transform.eulerAngles.y>-30f&& transform.eulerAngles.y<180f) || transform.eulerAngles.y > 330f)
            transform.RotateAround(center, Vector3.up, -speed * Time.deltaTime);
        }
    }
}
