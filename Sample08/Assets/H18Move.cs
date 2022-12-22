using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class H18Move : MonoBehaviour
{
    [SerializeField] private GameObject m_copsel;
    public GameObject Copsel { get { return m_copsel; } }

    [SerializeField] private UnityEngine.UI.Button m_UpButton;
    public UnityEngine.UI.Button UpButton { get { return m_UpButton; } }

  
    // Start is called before the first frame update
    void Start()
    {
        System.IDisposable UpButtonListener = UpButton.OnPointerDownAsObservable().Subscribe(_ =>
        {
            Vector3 posishon= Copsel.transform.position;
            posishon.z+=20.0f*Time.deltaTime; ;
            Copsel.transform.position=posishon;
        });
    

    }


    // Update is called once per frame
    void Update()
    {
    }
}
