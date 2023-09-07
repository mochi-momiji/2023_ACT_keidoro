using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACT_TargetInput : MonoBehaviour
{
    ACT_TargetController controller;

    // Start is called before the first frame update
    void Start()
    {
        InitInformation();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void InitInformation()
    {
        controller = GetComponent<ACT_TargetController>();

        if (controller != null)
        {
            controller.Init();
        }
        else
        {
            return;
        }
    }

    void Movement()
    {
        controller.SetMovement();
        controller.SetRotation();
    }
}
