using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AverageDeviation : MonoBehaviour
{
    [SerializeField] GameObject target;
    int i = 0;
    float sum_Pos_X = 0;
    float sum_Pos_Y = 0;
    float sum_Pos_Z = 0;
    float sum_Rot_X = 0;
    float sum_Rot_Y = 0;
    float sum_Rot_Z = 0;
    List<float> Position_X = new List<float>();
    List<float> Position_Y = new List<float>();
    List<float> Position_Z = new List<float>();
    List<float> Rotation_X = new List<float>();
    List<float> Rotation_Y = new List<float>();
    List<float> Rotation_Z = new List<float>();
    float Sum_AveDeviation = 0;
    public float Ave_AveDeviation = 0;
    public float ReadData_Rot_Y = 0;
    public float ReadData_Rot_Z = 0;

    private void Update()
    {
        sum_Pos_X = sum_Pos_X + transform.position.x;
        sum_Pos_Y = sum_Pos_Y + transform.position.y;
        sum_Pos_Z = sum_Pos_Z + transform.position.z;
        sum_Rot_X = sum_Rot_X + transform.rotation.x;
        sum_Rot_Y = sum_Rot_Y + transform.rotation.y;
        sum_Rot_Z = sum_Rot_Z + transform.rotation.z;

        Position_X.Add(transform.position.x);
        Position_Y.Add(transform.position.y);
        Position_Z.Add(transform.position.z);
        Rotation_X.Add(transform.rotation.x);
        Rotation_Y.Add(transform.rotation.y);
        Rotation_Z.Add(transform.rotation.z);

        i++;
        
        if (i == 10)
        {
            Ave_AveDeviation = 0;
            ReadData_Rot_Y = 0;
            ReadData_Rot_Z = 0;
            Sum_AveDeviation = Sum_AveDeviation + AveDeviation(sum_Pos_X, i,Position_X);
            //Debug.Log("1 : " + Sum_AveDeviation);
           
            Sum_AveDeviation = Sum_AveDeviation + AveDeviation(sum_Pos_Y, i, Position_Y);
            //Debug.Log("2 : " + Sum_AveDeviation);
           
            Sum_AveDeviation = Sum_AveDeviation + AveDeviation(sum_Pos_Z, i, Position_Z);
            //Debug.Log("3 : " + Sum_AveDeviation);
            
            Sum_AveDeviation = Sum_AveDeviation + AveDeviation(sum_Rot_X, i, Rotation_X);
            
            //Debug.Log("5 : " + Sum_AveDeviation);*/
            Sum_AveDeviation = Sum_AveDeviation + AveDeviation(sum_Rot_Y, i, Rotation_Y);
            ReadData_Rot_Y = AveDeviation(sum_Rot_Y, i, Rotation_Y);

            //Debug.Log("6 : " + Sum_AveDeviation);
            Sum_AveDeviation = Sum_AveDeviation + AveDeviation(sum_Rot_Z, i, Rotation_Z);
            ReadData_Rot_Z = AveDeviation(sum_Rot_Z, i, Rotation_Z);
            //Debug.Log(ReadData_Rot_Z);

            Ave_AveDeviation = Sum_AveDeviation / 6;

            Position_X = new List<float>();
            Position_Y = new List<float>();
            Position_Z = new List<float>();
            Rotation_X = new List<float>();
            Rotation_Y = new List<float>();
            Rotation_Z = new List<float>();
            Sum_AveDeviation = 0;
            sum_Pos_X = 0;
            sum_Pos_Y = 0;
            sum_Pos_Z = 0;
            sum_Rot_X = 0;
            sum_Rot_Y = 0;
            sum_Rot_Z = 0;
            i = 0;
        }
    }


    private float AveDeviation(float sum, int i,List<float> Array)
    {
        float means = 0;
        float means_diff = 0;
        float AverageDeviation = 0;
        means = sum / i;
       //Debug.Log("the means" + means);
        for ( int j = 0; j < i; j++)
        {
            means_diff = means_diff + (Mathf.Abs(Array[j] - means));
        }
       //Debug.Log("the means diff : " + means_diff);
        AverageDeviation = means_diff / i;
      //Debug.Log("the AveDev: " + AverageDeviation);

        return AverageDeviation;
    }

}
