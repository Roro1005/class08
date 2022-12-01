using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixidFrameRate : MonoBehaviour
{
    //ターゲットの移動速度
    [SerializeField] private float m_Speed = 3.0f;
    public float Speed { get { return m_Speed; } }

    //可変フレームレートか固定フレームレートかの切り替え
    [UnityEngine.SerializeField] private bool m_VariableFrameRate = false;
    public bool VariableFrameRate { get { return m_VariableFrameRate; } }

    [UnityEngine.SerializeField] private bool m_FrameRateDropDown = false;
    public bool FrameRateDropDown { get { return m_FrameRateDropDown; } }

    //固定フレームレートの場合の次のフレームまでの経過時間
    public const float FixedFrameRate = 1f / 60f;
   
    void Update()
    {


        if(FrameRateDropDown)
        {
            Application.targetFrameRate = 20;
        }
        else
        {
            Application.targetFrameRate = 60;
        }
        Vector3 move = new Vector3();
        float movePosition ;

        if(VariableFrameRate)
        {
            movePosition = Speed * Time.deltaTime;
        }
        else
        {
            movePosition = Speed*FixedFrameRate;

        }

        if (Input.GetKey(KeyCode.UpArrow))
            move.z += movePosition;
        if (Input.GetKey(KeyCode.DownArrow))
            move.z -= movePosition;
        if (Input.GetKey(KeyCode.LeftArrow))
            move.x -= movePosition;
        if (Input.GetKey(KeyCode.RightArrow))
            move.x += movePosition;

        Vector3 currentPosition = transform.position;
        currentPosition += move;
        transform.position = currentPosition;

    }
}
