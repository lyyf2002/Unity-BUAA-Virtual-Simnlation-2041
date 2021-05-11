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
            size.text = "��ǰ�׾���2mm";
        }
        else if (diaphragmSize == 2)
        {
            size.text = "��ǰ�׾���4mm";
        }
        else if (diaphragmSize == 3)
        {
            size.text = "��ǰ�׾���8mm";
        }
        else
        {
            size.text = "��ǰ�׾���δ����";
        }

        if(waveLength == 1)
        {
            wave.text = "��ǰ�Ⲩ����365.0nm";
        }
        else if (waveLength == 2)
        {
            wave.text = "��ǰ�Ⲩ����404.7nm";
        }
        else if (waveLength == 3)
        {
            wave.text = "��ǰ�Ⲩ����435.8nm";
        }
        else if (waveLength == 4)
        {
            wave.text = "��ǰ�Ⲩ����546.1nm";
        }
        else if (waveLength == 5)
        {
            wave.text = "��ǰ�Ⲩ����577.0nm";
        }
        else
        {
            wave.text = "��ǰ�Ⲩ����δ����";
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
