using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AverageDeviation_L_Hand : MonoBehaviour
{

    float sum_Pos_Y = 0;
    List<float> Position_Y = new List<float>();
    public float ReadData_Pos_Y = 0;
    int i = 0;


    void Update()
    {
        sum_Pos_Y = sum_Pos_Y + transform.position.y;
        Position_Y.Add(transform.position.y);

        i++;

        if (i == 10)
        {
            ReadData_Pos_Y = 0;
            ReadData_Pos_Y = AveDeviation_Hand(sum_Pos_Y, i, Position_Y);


            sum_Pos_Y = 0;
            Position_Y = new List<float>();
            i = 0;
        }
    }



    private float AveDeviation_Hand(float sum, int i, List<float> Array)
    {
        float means = 0;
        float means_diff = 0;
        float AverageDeviation = 0;
        means = sum / i;
        //Debug.Log("the means" + means);
        for (int j = 0; j < i; j++)
        {
            means_diff = means_diff + (Mathf.Abs(Array[j] - means));
        }
        //Debug.Log("the means diff : " + means_diff);
        AverageDeviation = means_diff / i;
        //Debug.Log("the AveDev: " + AverageDeviation);

        return AverageDeviation;
    }
}
