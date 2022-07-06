using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadData_Hand : MonoBehaviour
{
    AverageDeviation AverageDeviation;
    [SerializeField] GameObject hand;
    void Awake()
    {
        AverageDeviation = hand.GetComponent<AverageDeviation>();

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
