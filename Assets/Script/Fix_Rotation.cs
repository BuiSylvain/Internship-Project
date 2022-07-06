using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fix_Rotation : MonoBehaviour
{
    Vector3 Ini_Rotation;
    Vector3 Ini_Position;
    void Start()
    {
        Ini_Rotation = transform.eulerAngles;
        Ini_Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Ini_Rotation.y = transform.eulerAngles.y;
        
        Ini_Position.x = transform.position.x;
        Ini_Position.z = transform.position.z;

        transform.eulerAngles = Ini_Rotation;
        transform.position = Ini_Position;
    }
}
