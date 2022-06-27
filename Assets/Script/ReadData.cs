using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadData : MonoBehaviour
{
    float CheckAve;
    float CheckRot_Y;
    float CheckRot_Z;
    int distance = 1;
    public Transform target;
    AverageDeviation AverageDeviation;
    [SerializeField] GameObject Test;
    public Transform cameraForward;

    public float turnspeed = 0.000001f;
    Quaternion AngleGoal;
    Vector3 Direction;
    Quaternion temp;
    void Awake()
    {
       AverageDeviation = Test.GetComponent<AverageDeviation>();
       
    }

    private void Start()
    {
        InvokeRepeating("walking", 0.5f, 0.5f); // every 0.5 sec repeat 0.5
        //InvokeRepeating("walk",1f, 1f); // every 0.5 sec repeat 0.1
        transform.DetachChildren();


    }


    IEnumerator walk()
    {
        CheckAve = AverageDeviation.Ave_AveDeviation;
        CheckRot_Y = AverageDeviation.ReadData_Rot_Y;
        CheckRot_Z = AverageDeviation.ReadData_Rot_Z;


        //Debug.Log("the Check value : " + CheckAve);
       /* if (CheckAve > 0.001 && CheckAve < 0.004)
        {

            if (CheckRot_Y > 0.0002 && CheckRot_Y < 0.001 && CheckRot_Z > 0.001 && CheckRot_Z < 0.004)
            {*/
                Debug.Log("i'm in !");
                
                //transform.position += transform.forward * distance;
                //Camera.transform.position = transform.position + Camera.transform.right * distance * Time.deltaTime;
                //transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z + 1);
                yield return new WaitForSeconds(2);

            /*}

        //}*/
    }

    private void walking()
    {
        //transform.position += transform.forward * distance;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
    }

    void Update()
    {

        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, target.rotation.eulerAngles.y, transform.rotation.z));

        StartCoroutine(walk());

    }

    private void LateUpdate()
    {

    }
}
