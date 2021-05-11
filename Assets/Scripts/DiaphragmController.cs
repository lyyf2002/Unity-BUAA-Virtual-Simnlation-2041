using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaphragmController : MonoBehaviour
{
    public int diaphragmSize;//1: 2mm   2: 4mm     3: 8mm    0:null
    public int waveLength;//1:365.0nm   2:404.7nm     3:435.8nm     4:546.1nm     5:577.0nm    0:null
    public Text wave;
    public Text size;

    public DiaphragmController(int diaphragmSize, int waveLength)
    {
        this.diaphragmSize = diaphragmSize;
        this.waveLength = waveLength;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.waveLength = 0;
        this.diaphragmSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(diaphragmSize == 1)
        {
            size.text = "当前孔径：2mm";
        }
        else if (diaphragmSize == 2)
        {
            size.text = "当前孔径：4mm";
        }
        else if (diaphragmSize == 3)
        {
            size.text = "当前孔径：8mm";
        }
        else
        {
            size.text = "当前孔径：未放置";
        }

        if(waveLength == 1)
        {
            wave.text = "当前光波长：365.0nm";
        }
        else if (waveLength == 2)
        {
            wave.text = "当前光波长：404.7nm";
        }
        else if (waveLength == 3)
        {
            wave.text = "当前光波长：435.8nm";
        }
        else if (waveLength == 4)
        {
            wave.text = "当前光波长：546.1nm";
        }
        else if (waveLength == 5)
        {
            wave.text = "当前光波长：577.0nm";
        }
        else
        {
            wave.text = "当前光波长：未放置";
        }

    }
    public void changeSize()
    {
        if (diaphragmSize == 3) diaphragmSize = 0;
        else diaphragmSize++;
    }
    public void changeWave()
    {
        if (waveLength == 5) waveLength = 0;
        else waveLength++;
    }
}
