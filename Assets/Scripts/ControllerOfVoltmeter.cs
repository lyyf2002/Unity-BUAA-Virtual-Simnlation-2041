using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerOfVoltmeter : MonoBehaviour
{
    // Start is called before the first frame update
    public int volt;
    public int mode;
    public int count;
    public Text text_volt, test_currency;
    public Text text_mode;
    public ControllerOfAmpere controllerOfAmpere;
    public int modeoftest;
    void Start()
    {
        count = 1;
        volt = 0;
        mode = 1;
        modeoftest = 1;
    }

    // Update is called once per frame
    void Update()
    {
        int temp = (int)(volt);
        if(temp >= 100)
            text_volt.text = (temp/10).ToString() + "." + (temp%10).ToString();
        else if(0 <= temp && temp < 100)
            text_volt.text = "0" + (temp / 10).ToString() + "." + (temp % 10).ToString();
        else if(temp > -10)
            text_volt.text = "-0" + (temp / 10).ToString() + "." + (-temp % 10).ToString();
        else
            text_volt.text ="-01.0";
        test_currency.text = "";
        temp = (int)(controllerOfAmpere.ampere * 10f);
      
            test_currency.text = (temp / 1000).ToString()  + ((temp / 100) % 10).ToString() + ((temp / 10) % 10).ToString() + "." + (temp %10).ToString();
        text_mode.text = modeoftest == 1 ? "当前模式：截止电压测试" : "当前模式：伏安特性测试";
    }
    public void setZero()
    {
        controllerOfAmpere.reset();
        UnityEditor.EditorUtility.DisplayDialog("提示", "调零完成", "开始实验");
    }
    public void addVolt()
    {
        if (!controllerOfAmpere.isReset)
        {
            UnityEditor.EditorUtility.DisplayDialog("提示", "请先进行调零", "确认");
            return;
        }
            if (modeoftest == 1? (volt + mode <= 200) : (volt + mode <= 500))
        {
            volt += mode;
        }
        controllerOfAmpere.updateRandomValue();
    }
    public void subVolt()
    {
        if (!controllerOfAmpere.isReset)
        {
            UnityEditor.EditorUtility.DisplayDialog("提示", "请先进行调零", "确认");
            return;
        }
        if (modeoftest == 1 ? (volt + mode >= 0) : (volt - mode >= -10))
        {
            volt -= mode;
        }
        controllerOfAmpere.updateRandomValue();
    }
    public void modeUp()
    {
        if (!controllerOfAmpere.isReset)
        {
            UnityEditor.EditorUtility.DisplayDialog("提示", "请先进行调零", "确认");
            return;
        }
        if (count < 3)
        {
            count++;
            mode *= 10;
        }
    }
    public void modeDown()
    {
        if (!controllerOfAmpere.isReset)
        {
            UnityEditor.EditorUtility.DisplayDialog("提示", "请先进行调零", "确认");
            return;
        }
        if (count > 1)
        {
            count--;
            mode /= 10;
        }
        //Debug.Log(mode);
    }
    public void changemode()
    {
        modeoftest = modeoftest == 1 ? 2 : 1;
    }
}
