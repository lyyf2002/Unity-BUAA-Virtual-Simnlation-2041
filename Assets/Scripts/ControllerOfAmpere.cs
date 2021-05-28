using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerOfAmpere : MonoBehaviour
{
    // Start is called before the first frame update
    public double ampere;
    public double randomValue;
    public bool isReset;
    public DiaphragmController diaphragmController;
    public GameObject diaphragm;
    public GameObject mercuryLamp;
    public ControllerOfVoltmeter controllerOfVoltmeter;

    void Start()
    {
        this.ampere = 0;
        this.isReset = false;
        updateRandomValue();
    }

    public void reset()
    {
        isReset = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.ampere = getAmpere(diaphragmController, diaphragm, mercuryLamp, controllerOfVoltmeter);
    }

    public void updateRandomValue()
    {
        System.Random rnd = new System.Random();
        this.randomValue = rnd.Next(-1, 1) * 0.1;
    }
    public double getAmpere(DiaphragmController diaphragmController, GameObject diaphragm, GameObject mercuryLamp, ControllerOfVoltmeter controllerOfVoltmeter)
    {
        if (!isReset) return 0;

        int _diaphragmSize = diaphragmController.diaphragmSize;//1: 2mm   2: 4mm     3: 8mm    0:null
        int _waveLength = diaphragmController.waveLength;//1:365.0nm   2:404.7nm     3:435.8nm     4:546.1nm     5:577.0nm    0:null

        if (_diaphragmSize == 0 || _waveLength == 0) return 0;

        // double _length = diaphragm.transform.position.x - mercuryLamp.transform.position.x;
        double _volt = (double)controllerOfVoltmeter.volt / 10f;
        double _volt2 = (double)controllerOfVoltmeter.volt2 / 1000f;
        int _int_volt = (int)_volt;

        if (controllerOfVoltmeter.modeoftest == 1)
        {
            //Debug.Log("test");
            double _zero_volt = 0;
            if (_waveLength == 1)
            {
                _zero_volt = 1.741;
            }
            else if (_waveLength == 2)
            {
                _zero_volt = 1.464;
            }
            else if (_waveLength == 3)
            {
                _zero_volt = 1.174;
            }
            else if (_waveLength == 4)
            {
                _zero_volt = 0.619;
            }
            else
            {
                _zero_volt = 0.519;
            }
            Debug.Log(_zero_volt);
            Debug.Log(_volt2);
            if (System.Math.Abs(_volt2 - _zero_volt) < 0.001) return 0;
            else return (_volt2 - _zero_volt) / 5 * 1000;
        }
        else
        {
            double ampere_1, ampere_2, ampere;

            if (_waveLength == 1)
            {
                double[] amperes = { 2.3, 10.4, 17.7, 23.5, 28.0, 31.2, 33.5, 35.2, 36.5, 37.7, 42.2, 42.2 };
                ampere_1 = _int_volt == -1 ? 0.7 : amperes[_int_volt / 5];
                ampere_2 = _int_volt == -1 ? 0.7 : amperes[_int_volt / 5 + 1];
            }
            else if (_waveLength == 2)
            {
                double[] amperes = { 1.0, 4.8, 8.1, 10.6, 12.5, 13.8, 15.7, 16.8, 15.7, 15.9, 15.7, 15.7 };
                ampere_1 = _int_volt == -1 ? 0.2 : amperes[_int_volt / 5];
                ampere_2 = _int_volt == -1 ? 0.2 : amperes[_int_volt / 5 + 1];
            }
            else if (_waveLength == 3)
            {
                double[] amperes = { 1.8, 8.5, 14.4, 19.7, 21.7, 23.5, 26.2, 27.6, 28.5, 27.0, 27.7, 27.7 };
                ampere_1 = _int_volt == -1 ? 0.2 : amperes[_int_volt / 5];
                ampere_2 = _int_volt == -1 ? 0.2 : amperes[_int_volt / 5 + 1];
            }
            else if (_waveLength == 4)
            {
                double[] amperes = { 0.3, 1.5, 1.9, 2.2, 2.7, 2.9, 2.8, 2.9, 2.9, 3.0, 3.1, 3.1 };
                ampere_1 = _int_volt == -1 ? 0.1 : amperes[_int_volt / 5];
                ampere_2 = _int_volt == -1 ? 0.1 : amperes[_int_volt / 5 + 1];
            }
            else
            {
                double[] amperes = { 0.2, 1.0, 1.4, 1.6, 1.8, 1.9, 2.0, 2.0, 2.1, 2.1, 2.1, 2.1 };
                ampere_1 = _int_volt == -1 ? 0.1 : amperes[_int_volt / 5];
                ampere_2 = _int_volt == -1 ? 0.1 : amperes[_int_volt / 5 + 1];
            }
            //Debug.Log((double)(_volt - ((int)_int_volt / 5 * 5)) / 5f * (ampere_2 - ampere_1));
            //Debug.Log(ampere_2);
            //Debug.Log(ampere_1);
            ampere = (double)(_volt - ((int)_int_volt / 5 * 5)) / 5f * (ampere_2 - ampere_1) + ampere_1;
            double d = (_diaphragmSize == 0) ? 0 :
                (_diaphragmSize == 1) ? 0.7 :
                (_diaphragmSize == 2) ? 0.85 : 1;
            return ampere*d + this.randomValue;

        }
    }
}
