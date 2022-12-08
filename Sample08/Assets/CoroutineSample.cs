using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSample : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button m_Button;
    public UnityEngine.UI.Button Button { get { return m_Button; } }

    [SerializeField] private float m_Move = -300;
    public float Move { get { return m_Move; } }
    [SerializeField] float m_MoveTime = 1f;
    public float MoveTime { get { return m_MoveTime; } }

    [SerializeField] private RectTransform m_DogTransform;
    public RectTransform DogTransform { get { return m_DogTransform; } }
    // Start is called before the first frame update
    void Start()
    {
        Button.onClick.AddListener(() =>
        {
        StartCoroutine(Coroutine());
       
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Coroutine()
    {
        float elapeedTime = 0f;
        Vector2 dogPosition = DogTransform.anchoredPosition;
        float initialPosition=dogPosition.x;

        while(elapeedTime<MoveTime)
        {
            float scaledTime = elapeedTime / MoveTime;

            float moveValue = scaledTime * Move;
            dogPosition.x = initialPosition + moveValue;
            DogTransform.anchoredPosition = dogPosition;

            yield return null;
            elapeedTime += Time.deltaTime;
        }

    }
}
