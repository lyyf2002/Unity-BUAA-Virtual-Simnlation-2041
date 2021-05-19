using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerOfAmpere : MonoBehaviour
{
    // Start is called before the first frame update
    public float ampere;
    public DiaphragmController diaphragmController;
    public GameObject diaphragm;
    public GameObject mercuryLamp;
    public ControllerOfVoltmeter controllerOfVoltmeter;
    void Start()
    {
        this.ampere = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        this.ampere = getAmpere(diaphragmController, diaphragm, mercuryLamp, controllerOfVoltmeter);
    }
    public float getAmpere(DiaphragmController diaphragmController, GameObject diaphragm, GameObject mercuryLamp, ControllerOfVoltmeter controllerOfVoltmeter)
    {
        int _diaphragmSize = diaphragmController.diaphragmSize;//1: 2mm   2: 4mm     3: 8mm    0:null
        int _waveLength = diaphragmController.waveLength;//1:365.0nm   2:404.7nm     3:435.8nm     4:546.1nm     5:577.0nm    0:null
        
        float _length = diaphragm.transform.position.x - mercuryLamp.transform.position.x;

        float _volt = controllerOfVoltmeter.volt;

        //TODO
        return _volt;
    }
    
}
