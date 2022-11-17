using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{

    //‹ÂŠp
    private float Elevation { get; set; }
    //•ûˆÊŠp
    private float Azimuth { get; set; }

    private Vector3 previousMousePosition { get; set; }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        Vector3 mouseMove = currentMousePosition - previousMousePosition;
        previousMousePosition = currentMousePosition;

        Elevation += mouseMove.y;
        Azimuth += mouseMove.x;
        if(Elevation>90f)
        {
            Elevation = 90f;
        }
        if (Elevation < -90)
        {
            Elevation = -90;
        }

        Quaternion elevtionRotation=Quaternion.AngleAxis(-Elevation,new Vector3(1f,0f,0f));
        Quaternion azimuthRotation = Quaternion.AngleAxis(Azimuth, new Vector3(0f, 1f, 0f));

        transform.rotation = azimuthRotation * elevtionRotation;

        Vector3 move = new Vector3();

        if (Input.GetKey(KeyCode.W))
            move.z += 0.03f;
        if (Input.GetKey(KeyCode.S))
            move.z -= 0.03f;
        if (Input.GetKey(KeyCode.A))
            move.x -= 0.03f;
        if (Input.GetKey(KeyCode.D))
            move.x += 0.03f;

        Vector3 postion = transform.position;
        transform.position = postion + azimuthRotation * move;

    }
}
