using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    Equation equation;
    
    public void ButtonClick()
    {
        equation = FindObjectOfType<Equation>();
        int buttontext=int.Parse(transform.GetComponentInChildren<TMP_Text>().text);
        if (buttontext==equation.Answer)
        {
            //Videolink
            Application.OpenURL("https://youtu.be/FUj6DunfelUhttps://youtu.be/FUj6DunfelUhttps://youtu.be/FUj6DunfelU");
            Debug.Log("true");
        }

        else
        {
            equation.CreateEquation();
        }
        Debug.Log(transform.GetComponentInChildren<TMP_Text>().text);
    }
}//class