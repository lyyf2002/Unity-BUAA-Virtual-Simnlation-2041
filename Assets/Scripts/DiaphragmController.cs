using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaphragmController : MonoBehaviour
{
    private int diaphragmSize;//1: 2mm   2: 4mm     3: 8mm    0:null
    private int waveLength;//1:365.0nm   2:404.7nm     3:435.8nm     4:546.1nm     5:577.0nm    0:null

    public DiaphragmController(int diaphragmSize, int waveLength)
    {
        this.diaphragmSize = diaphragmSize;
        this.waveLength = waveLength;
    }

    public int DiaphragmSize { get => diaphragmSize; set => diaphragmSize = value; }
    public int WaveLength { get => waveLength; set => waveLength = value; }

    // Start is called before the first frame update
    void Start()
    {
        this.waveLength = 0;
        this.diaphragmSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
