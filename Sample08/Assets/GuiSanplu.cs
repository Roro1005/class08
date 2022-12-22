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
        //旧ボタンコールバック
        /*Button.onClick.AddListener(() =>
        {
            ButtonCount++;
            Text.text = ButtonCount + "回押されました";
            

            Color c = Image.color;
            c.a= 1;
            Image.color = c;
        });*/

        //UniRxを使ったボタンコールバック
        System.IDisposable EnableButtonListener = EnableButton.OnClickAsObservable().Subscribe(_ =>
        {
            ButtonsEnabled = !ButtonsEnabled;
            if (!ButtonsEnabled)
            {
                //いま無効になったのならボタンを無効にする
                Disposables.Clear();
                return;
            }
        
            //ここから下は有効になった時の処理
            System.IDisposable ButtonListenerA = ButtonA.OnClickAsObservable().Subscribe(_ =>
            {
                ButtonCount++;
                Text.text = ButtonCount + "回押されました";

            }).AddTo(Disposables);

            System.IDisposable ButtonListenerB = ButtonB.OnClickAsObservable().Subscribe(_ =>
            {
                Color c = Image.color;
                c.a = 1;
                Image.color = c;
            }).AddTo(Disposables);

        });
    //ボタンが押されたイベントの購読を解除
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
