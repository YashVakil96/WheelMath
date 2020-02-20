using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLine : MonoBehaviour
{
    #region Variables
    public static float NewDistance;
    public static Vector3 NewAT;
    public static bool NewDrawing;
    public static int StartLinePoint;
    public static int EndLinePoint;
    public static Transform PointA;
    public static Transform PointB;



    public float LineDrawSpeed=5;

    private LineRenderer line;
    private int PointCount=2;
    private float Counter;
    #endregion

    #region System Methods

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.startWidth=.1f;
        line.endWidth=.1f;
        line.positionCount = PointCount;
        line.SetPosition(0, GameObject.Find("0").transform.GetChild(1).transform.position);
        line.SetPosition(1, GameObject.Find("0").transform.GetChild(1).transform.position);

        StartLinePoint = 0;
        EndLinePoint = 1;
    }//start


    private void FixedUpdate()
    {
        if (NewDrawing)
        {
            NewAnimateLine(PointA, Multiplication.DrawLineB, line);
        }
    }//Update
    #endregion


    #region User Define Methods

    public static void NewCheckDistance(Transform A, Transform B)
    {
        NewDistance = Vector3.Distance(A.position, B.position);
        Debug.Log("NewLine Distance: "+NewDistance);
    }//NewCheckDistance

    public static void AssignNewPoint(LineRenderer line)
    {
        line.positionCount++;
        line.SetPosition (line.positionCount-1, line.GetPosition(line.positionCount-2));
        
    }//AssignNewPoint

    public void NewAnimateLine(Transform PointA, Transform PointB,LineRenderer line)
    {
        if (Counter < NewDistance)
        {
            //Debug.Log("IS RUNNING");
            Debug.Log(Counter);
            Counter += 1f /LineDrawSpeed;
            
            float x = Mathf.Lerp(0, NewDistance, Counter);
            Vector3 A = PointA.position;
            Vector3 B = PointB.position;

            NewAT = x * Vector3.Normalize(B - A) + A;
            line.SetPosition(EndLinePoint, NewAT);
        }
        else
        {
            Counter = 0;
            NewDrawing = false;
            int TempUnitTotal;
            StartLinePoint++;
            EndLinePoint++;
            AssignNewPoint(line);
            NewLine.PointA = PointB;
            if (Multiplication.StoredTotal >= 10)
            {
                TempUnitTotal = Multiplication.StoredTotal % 10;
                Debug.Log(TempUnitTotal);
            }
            else
            {

                TempUnitTotal = Multiplication.StoredTotal;
            }
        }
    }//Animate line
    #endregion
}//class
