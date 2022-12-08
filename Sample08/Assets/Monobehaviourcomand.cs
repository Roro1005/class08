using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monobehaviourcomand : MonoBehaviour
{
    public float s = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("Awake");
    }
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

}
