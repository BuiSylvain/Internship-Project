using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadData : MonoBehaviour
{
    public float speed = 1;
    float CheckAve;
    float CheckRot_Y;
    float CheckRot_Z;
    float CheckPos_Y_L_Hand;
    float CheckPos_Y_R_Hand;
    public Transform target;
    public Transform testtarget;
    AverageDeviation AverageDeviation;
    AverageDeviation_L_Hand L_Hand_AverageDeviation;
    AverageDeviation_R_Hand R_Hand_AverageDeviation;

    [SerializeField] GameObject Test;
    [SerializeField] GameObject L_Hand;
    [SerializeField] GameObject R_Hand;

    private Animator animation;


    void Awake()
    {
       AverageDeviation = Test.GetComponent<AverageDeviation>();
       L_Hand_AverageDeviation = L_Hand.GetComponent<AverageDeviation_L_Hand>();
       R_Hand_AverageDeviation = R_Hand.GetComponent<AverageDeviation_R_Hand>();

        animation = GetComponent<Animator>();
        
    }

    private void Start()
    {
        //InvokeRepeating("walking", 0.25f, 0.25f);
    }

    private void Update()
    {
        CheckAve = AverageDeviation.Ave_AveDeviation;
        CheckRot_Y = AverageDeviation.ReadData_Rot_Y;
        CheckRot_Z = AverageDeviation.ReadData_Rot_Z;
        CheckPos_Y_L_Hand = L_Hand_AverageDeviation.ReadData_Pos_Y;
        CheckPos_Y_R_Hand = R_Hand_AverageDeviation.ReadData_Pos_Y;
        Debug.Log("The AveAverage deviation : " + CheckAve);
        Debug.Log("The Average deviation of Rot_Y = : " + CheckRot_Y);
        Debug.Log("The Average deviation of Rot_Z = : " + CheckRot_Z);
        Debug.Log("The Average deviation of Pos_Y_L_Hand = : " + CheckPos_Y_L_Hand);
        Debug.Log("The Average deviation of Pos_Y_R_Hand = : " + CheckPos_Y_R_Hand);
        Debug.Log("--------------------------------------------------");
    

        float step = speed * Time.deltaTime;

        //Debug.Log("the Check value : " + CheckAve);
        if (CheckPos_Y_L_Hand > 0.01 && CheckPos_Y_L_Hand < 0.4 || CheckPos_Y_R_Hand > 0.01 && CheckPos_Y_R_Hand < 0.4)
        {
            if (CheckAve > 0.01 && CheckAve < 0.02)
            {
                if (CheckRot_Y > 0.001 && CheckRot_Y < 0.02 && CheckRot_Z > 0.005 && CheckRot_Z < 0.02)
                {
                    transform.position = Vector3.MoveTowards(transform.position, testtarget.position, step);
                    //animation.SetBool("Run", true);
                    //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                }

            }
        }
        //animation.SetBool("Run", false);
    }


}
