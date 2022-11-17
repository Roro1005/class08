using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample08
{
    public class Sample : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private int m_SampleInt = 0;
        public int SampleInt { get { return m_SampleInt; } }

        [UnityEngine.SerializeField]
        private string m_SampleString = "";
        public string SampleString { get { return m_SampleString; } }



        void Start()
        {
            int square = SampleInt * SampleInt;
            UnityEngine.Debug.Log("2èÊÇÕ" + square + "Ç≈Ç∑");
        }

        void Update()
        {
            //UnityEngine.Debug.Log("update");
        }
    }
}