using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Threading;
public class ControllerOfVoltmeter : MonoBehaviour
{
    // Start is called before the first frame update
    public int volt, volt2;
    public int mode,mode2;
    public int count, count2;
    public Text text_volt0, text_volt1, text_volt2, text_volt3, text_volt4, text_volt5, text_volt12, text_volt22, text_volt32, text_volt42, text_volt52, test_currency;
    public Text text_mode;
    public ControllerOfAmpere controllerOfAmpere;
    public int modeoftest;
    public int blink;
    void Start()
    {
        count = 1;
        volt = 0;
        mode = 1;
        count2 = 1;
        volt2 = 0;
        mode2 = 1;
        modeoftest = 1;
        blink = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(modeoftest == 1)
        {
            text_volt12.text = "";
            text_volt22.text = "";
            text_volt32.text = "";
            text_volt42.text = "";
            text_volt52.text = "";
            text_volt0.text = "";
            blink = (blink + 1) % 300;
            int temp = (int)(volt2);
            text_volt1.text = (temp / 1000).ToString();
            text_volt2.text = ".";
            text_volt3.text = ((temp % 1000)/100).ToString();
            text_volt4.text = ((temp % 100) / 10).ToString();
            text_volt5.text = (temp % 10).ToString();
            if (blink > 150)
            {

                if (mode2 == 1)
                {
                    text_volt5.text = "_";
                }
                if (mode2 == 10)
                {
                    text_volt4.text = "_";
                }
                if (mode2 == 100)
                {
                    text_volt3.text = "_";
                }
                if (mode2 == 1000)
                {
                    text_volt1.text = "_";
                }
            }
        }
        else
        {
            text_volt0.text = "";
            text_volt1.text = "";
            text_volt2.text = "";
            text_volt3.text = "";
            text_volt4.text = "";
            text_volt5.text = "";
            blink = (blink + 1) % 300;
            int temp = (int)(volt);
            if (temp < 0) { text_volt12.text = "-"; temp = -temp; } else text_volt12.text = "";
            text_volt22.text = (temp / 100).ToString();
            text_volt32.text = ((temp % 100) / 10).ToString();
            text_volt42.text = ".";
            text_volt52.text = (temp % 10).ToString();
            if (blink > 150)
            {

                if (mode == 1)
                {
                    text_volt52.text = "_";
                }
                if (mode == 10)
                {
                    text_volt32.text = "_";
                }
                if (mode == 100)
                {
                    text_volt22.text = "_";
                }

            }
        }

        int temp2;
        test_currency.text = "";
        temp2 = (int)(controllerOfAmpere.ampere * 10f);
         if(temp2 < 0)
        {
            temp2 = -temp2;
            test_currency.text = "-" + (temp2 / 1000).ToString() + ((temp2 / 100) % 10).ToString() + ((temp2 / 10) % 10).ToString() + "." + (temp2 % 10).ToString();
        }
            else test_currency.text = (temp2 / 1000).ToString() + ((temp2 / 100) % 10).ToString() + ((temp2 / 10) % 10).ToString() + "." + (temp2 % 10).ToString();
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
            if (modeoftest == 1? (volt2 + mode2 <= 2000) : (volt + mode <= 500))
        {
            if(modeoftest == 1)
            {
                volt2 += mode2;
            }
            else
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
        if (modeoftest == 1 ? (volt2 - mode2 >= 0) : (volt - mode >= -10))
        {

            if (modeoftest == 1)
            {
                volt2 -= mode2;
            }
            else
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
        if(modeoftest == 1)
        {
            if (count2 < 4)
            {
                count2++;
                mode2 *= 10;
            }
        }
        else
        {
            if (count < 3)
            {
                count++;
                mode *= 10;
            }
        }
        
    }
    public void modeDown()
    {
        if (!controllerOfAmpere.isReset)
        {
            UnityEditor.EditorUtility.DisplayDialog("提示", "请先进行调零", "确认");
            return;
        }
        if (modeoftest == 1)
        {
            if (count2 > 1)
            {
                count2--;
                mode2 /= 10;
            }
        }
        else
        {
            if (count > 1)
            {
                count--;
                mode /= 10;
            }
        }
        //Debug.Log(mode2);
    }
    public void changemode()
    {
        modeoftest = modeoftest == 1 ? 2 : 1;
    }
}
