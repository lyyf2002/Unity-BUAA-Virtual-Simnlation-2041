using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerOfVoltmeter : MonoBehaviour
{
    // Start is called before the first frame update
    public float volt;
    public float mode;
    void Start()
    {
        volt = 0;
        mode = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addVolt()
    {
        volt += mode;
    }
    public void subVolt()
    {
        volt -= mode;
    }
}
