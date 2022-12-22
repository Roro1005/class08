using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GuiSanplu : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button m_ButtonA;
    public UnityEngine.UI.Button ButtonA { get { return m_ButtonA; } }

    [SerializeField] private UnityEngine.UI.Button m_ButtonB;
    public UnityEngine.UI.Button ButtonB { get { return m_ButtonB; } }

    [SerializeField] private UnityEngine.UI.Button m_EnableButton;
    public UnityEngine.UI.Button EnableButton { get { return m_EnableButton; } }

    [SerializeField] private UnityEngine.UI.Image m_Image;
    public UnityEngine.UI.Image Image { get { return m_Image; } }

    [SerializeField] private TMPro.TMP_Text m_Text;
    public TMPro.TMP_Text Text { get { return m_Text; } }

    private int ButtonCount { get; set; } = 0;

    private CompositeDisposable Disposables { get; set; } = new CompositeDisposable();
    private bool ButtonsEnabled { get; set; } = false;

    private System.IDisposable EnableButtonListener { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        //���{�^���R�[���o�b�N
        /*Button.onClick.AddListener(() =>
        {
            ButtonCount++;
            Text.text = ButtonCount + "�񉟂���܂���";
            

            Color c = Image.color;
            c.a= 1;
            Image.color = c;
        });*/

        //UniRx���g�����{�^���R�[���o�b�N
        System.IDisposable EnableButtonListener = EnableButton.OnClickAsObservable().Subscribe(_ =>
        {
            ButtonsEnabled = !ButtonsEnabled;
            if (!ButtonsEnabled)
            {
                //���ܖ����ɂȂ����̂Ȃ�{�^���𖳌��ɂ���
                Disposables.Clear();
                return;
            }
        
            //�������牺�͗L���ɂȂ������̏���
            System.IDisposable ButtonListenerA = ButtonA.OnClickAsObservable().Subscribe(_ =>
            {
                ButtonCount++;
                Text.text = ButtonCount + "�񉟂���܂���";

            }).AddTo(Disposables);

            System.IDisposable ButtonListenerB = ButtonB.OnClickAsObservable().Subscribe(_ =>
            {
                Color c = Image.color;
                c.a = 1;
                Image.color = c;
            }).AddTo(Disposables);

        });
    //�{�^���������ꂽ�C�x���g�̍w�ǂ�����
    //ButtonListenerA.Dispose();

}

    private void OnDestroy()
    {
        EnableButtonListener?.Dispose();
        Disposables.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        Color c = Image.color;
        c.a -= 0.01f;
        Image.color = c;

    }
}
