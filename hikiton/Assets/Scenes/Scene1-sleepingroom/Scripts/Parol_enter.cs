using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parol_enter : MonoBehaviour
{
    private string right_str = "7519455";
    private string real_str = "";
    public GameObject text;


    public void Start()
    {
        ChangeText();
    }
    public void AddSumbol(string str)
    {
        if(real_str.Length < right_str.Length)
        {
            real_str += str;
            ChangeText();
        }
    }

    void ChangeText()
    {
        string star_text = real_str;
        for (int i = 0; i < right_str.Length - real_str.Length; i++) 
        {
            star_text += "*"; 
        }
        text.GetComponent<Text>().text = star_text;
    }

    public void Delete_code()
    {
        real_str = "";
        ChangeText();
    }

    public void Try_code()
    {
        if (real_str == right_str) { End(); }
        else Delete_code();
    }
    void End()
    {
        real_str = "Complete";
        ChangeText();
    }
}
