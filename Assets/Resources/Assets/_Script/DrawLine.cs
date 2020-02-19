using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    #region Variable

    public static bool Drawing;

    public int LineDrawSpeed=5;
    public static Transform PointA;
    public static Transform PointB;
    public static Vector3 AT;


    private float Counter;//Line Draw Counter
    public static float Distance;//Distance between 2 points
    private GameObject[] Object;
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
        PointA = GameObject.Find("0").transform.GetChild(1).transform;
        //LineRenderer.SetPosition(0)
    }

    private void Update()
    {
        if(Drawing)
        {
            AnimateLine(PointA,Multiplication.DrawLineB);
        }

    }//update

    #endregion


    #region User Define Methods
    public void AnimateLine(Transform PointA, Transform PointB)
    {
        LineRenderer.SetPosition(0, PointA.position);
        if (Counter < Distance)
        {
            Counter += .1f / LineDrawSpeed;
            float x = Mathf.Lerp(0, Distance, Counter);
            Vector3 A = PointA.position;
            Vector3 B = PointB.position;

            AT = x * Vector3.Normalize(B - A) + A;
            LineRenderer.SetPosition(1, AT);
        }
        else
        {
            Drawing = false;
            Debug.Log("Here");
        }
    }//Animate line

    public static void CalculateDistance(Transform PointA, Transform PointB)
    {
        Distance = Vector3.Distance(PointA.position, PointB.position);
    }
    #endregion
}//class
