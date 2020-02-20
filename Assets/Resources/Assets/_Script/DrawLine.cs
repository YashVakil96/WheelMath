using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    #region Variable

    public static bool Drawing;
    public static Transform PointA;
    public static Transform PointB;
    public static Vector3 AT;
    public static float Distance;//Distance between 2 points

    public int LineDrawSpeed=5;

    private float Counter;//Line Draw Counter
    private GameObject[] Object;
    private LineRenderer LineRenderer;
    private Vector3[] Positions;
    #endregion


    #region System Methods

    private void Start()
    {
        
        Object = new GameObject[10];
        Positions = new Vector3[Object.Length];
        for (int i = 0; i <= 9; i++)
        {
            Object[i] = GameObject.Find(i.ToString());
            Positions[i] = Object[i].transform.GetChild(1).transform.position;
        }
        LineRenderer = GetComponent<LineRenderer>();
        //LineRenderer.positionCount = 10;
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
        Debug.Log(PointA.name);
        Debug.Log(PointB.name);
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
        Debug.Log(Distance);
    }
    #endregion
}//class