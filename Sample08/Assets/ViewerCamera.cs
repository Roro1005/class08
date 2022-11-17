using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    
    //‹ÂŠp
    private float Elevation { get; set; }
    
    //•ûˆÊŠp
    private float Azimuth { get; set; }

    //ƒJƒƒ‰‚ª‘_‚¤ˆÊ’u
    [SerializeField] private Vector3 m_TargetPosition;
    public Vector3 TargetPosition { get { return m_TargetPosition; } }
    
    //ƒJƒƒ‰‚Ü‚Å‚Ì‹——£
    [SerializeField] private float m_Distance = 10f;
    public float Distance { get { return m_Distance; } }

    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
            Elevation += 1f;
        if (Input.GetKey(KeyCode.DownArrow))
            Elevation -= 1f;
        if (Input.GetKey(KeyCode.LeftArrow))
            Azimuth -= 1f;
        if (Input.GetKey(KeyCode.RightArrow))
            Azimuth += 1f;

        if (Elevation > 89f)
        {
            Elevation = 89f;
        }
        if (Elevation < -89f)
        {
            Elevation = -89f;
        }

        Quaternion elevtionRotation = Quaternion.AngleAxis(-Elevation, new Vector3(1f, 0f, 0f));
        Quaternion azimuthRotation = Quaternion.AngleAxis(Azimuth, new Vector3(0f, 1f, 0f));

        Quaternion margedRotation = azimuthRotation * elevtionRotation;


        Vector3 cameraFromTarget=margedRotation*new Vector3(0f,0f,Distance);
        Vector3 cameraPosition = TargetPosition + cameraFromTarget;

        Quaternion cameraRotation=Quaternion.LookRotation(-cameraFromTarget);

        transform.position = cameraPosition;
        transform.rotation = cameraRotation;

    }
}
