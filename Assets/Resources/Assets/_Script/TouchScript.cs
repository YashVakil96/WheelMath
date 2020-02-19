using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    #region Variable

    private GameObject[] Object;

    private Touch touch;
    private Vector3 TouchPos;
    private Vector3 PointA;
    private Vector3 PointB;
    private LineRenderer LineRenderer;
    #endregion


    #region System Methods

    private void Start()
    {
        Object = new GameObject[10];
        for (int i = 0; i <= 9; i++)
        {
            Object[i] = GameObject.Find(i.ToString());
        }
        LineRenderer = GetComponent<LineRenderer>();
        //LineRenderer.SetPosition(0)
    }

    private void Update()
    {
        if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            TouchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.DrawLine(Vector3.zero, TouchPos, Color.blue);
                    break;

                case TouchPhase.Moved:
                    Debug.DrawLine(Vector3.zero, TouchPos, Color.blue);
                    break;

                case TouchPhase.Stationary:
                    Debug.DrawLine(Vector3.zero, TouchPos, Color.blue);
                    break;

                case TouchPhase.Ended:
                    Debug.DrawLine(Vector3.zero, TouchPos, Color.blue);
                    break;
            }//switch
        }//If touch count

        if(Input.GetMouseButtonDown(0))
        {
            if(PointA==Vector3.zero)
            {
                PointA = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PointA.z = 0f;
            }
            else
            {
                PointB = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                PointB.z = 0f;
            }
            
        }
        else if(Input.GetMouseButton(0))
        {
            Debug.DrawLine(Vector3.zero, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.blue);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.DrawLine(Vector3.zero, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.blue);
        }
        if(PointA!=Vector3.zero && PointB!=Vector3.zero)
        {
            //Both place is filled animate line
            AnimateLine();
        }

    }//update

    #endregion


    #region User Define Methods
    void AnimateLine()
    {
        LineRenderer.SetPosition(0, PointA);
        LineRenderer.SetPosition(1, PointB);
        Debug.Log("Inside Animate Line");
    }
    #endregion
}//class
