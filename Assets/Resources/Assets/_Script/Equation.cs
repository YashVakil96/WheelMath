using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Equation : MonoBehaviour
{
    #region Variable

    public int Number1, Number2, Number3, Answer;

    public TMP_Text n1,n2,n3,ans,o1,o2,o3,a1,a2,a3;
    #endregion

    #region System Methods
    private void Start()
    {
        CreateEquation();
    }//update
    #endregion

    #region User Define Methods
    public void CreateEquation()
    {
        Number1 = Random.Range(1, 10);
        Debug.Log(Number1);
        n1.text = Number1.ToString();
        Number2 = Random.Range(1, 10);
        n2.text = Number2.ToString();
        Debug.Log(Number2);
        Number3 = Random.Range(1, 10);
        n3.text = Number3.ToString();
        Debug.Log(Number3);
        o3.text = "=";
        if(Number2 > Number1)
        {
            Answer = Number1 + Number2;
            o1.text = "+";
        }

        else
        {
            if(Random.Range(0, 2) == 0)
            {
                //Add
                Answer = Number1 + Number2;
                o1.text = "+";
            }

            else
            {
                //Sub
                Answer = Number1 - Number2;
                o1.text = "-";
            }
        }
        
        Debug.Log(Answer);

        if (Answer % Number3 == 0)
        {
            Answer = Answer / Number3;
            o2.text = "/";
        }

        else
        {
            Answer = Answer * Number3;
            o2.text = "*";
        }

        Debug.Log(Answer);


        switch (Random.Range(0, 3))
        {
            case 0:
                a1.text = Answer.ToString();
                a2.text = (Answer + 2).ToString();
                a3.text = (Answer + 3).ToString();

                break;

            case 1:
                a2.text = Answer.ToString();
                a3.text = (Answer + 2).ToString();
                a1.text = (Answer + 3).ToString();
                break;

            case 2:
                a3.text = Answer.ToString();
                a1.text = (Answer + 2).ToString();
                a2.text = (Answer + 3).ToString();
                break;
        }//switch


    }//Create Equation
    #endregion

}//class