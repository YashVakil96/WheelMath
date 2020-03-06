using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Equation : MonoBehaviour
{
    #region Variable
    int Number1, Number2, Number3, Answer;

    public TMP_Text n1,n2,n3,o1,o2,a1,a2,a3;
    #endregion

    #region System Methods
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateEquation();
        }
    }//update
    #endregion

    #region User Define Methods
    void CreateEquation()
    {
        Number1 = Random.Range(1, 10);
        Debug.Log(Number1);
        n1.text = Number1.ToString();
        Number2 = Random.Range(1, 10);
        n2.text = Number2.ToString();
        Debug.Log(Number2);
        Number3 = Random.Range(1, 10);
        Debug.Log(Number3);
        if(Number2 > Number1)
        {
            Answer = Number1 + Number2;
            o1.text = "+";
            o2.text = "=";
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
            o2.text = "=";
        }
        switch (Random.Range(0,3))
        {
            case 0:
                a1.text = Answer.ToString();
                a2.text = Answer+2.ToString();
                a3.text = Answer+3.ToString();

                break;

            case 1:
                a2.text = Answer.ToString();
                a3.text = Answer + 2.ToString();
                a1.text = Answer + 3.ToString();
                break;

            case 2:
                a3.text = Answer.ToString();
                a1.text = Answer + 2.ToString();
                a2.text = Answer + 3.ToString();
                break;
        }
        Debug.Log(Answer);

        //if(Answer%Number3==0)
        //{
        //    Answer = Answer / Number3;
        //}

        //else
        //{
        //    Answer = Answer * Number3;
        //}

        //Debug.Log(Answer);


    }//Create Equation
    #endregion

}//class