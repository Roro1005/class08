using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiSanplu : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button m_Button;
    public UnityEngine.UI.Button Button { get { return m_Button; } }

    [SerializeField] private UnityEngine.UI.Image m_Image;
    public UnityEngine.UI.Image Image { get { return m_Image; } }

    [SerializeField] private TMPro.TMP_Text m_Text;
    public TMPro.TMP_Text Text { get { return m_Text; } }

    private int ButtonCount { get; set; } = 0;
    // Start is called before the first frame update
    void Start()
    {
        Button.onClick.AddListener(() =>
        {
            ButtonCount++;
            Text.text = ButtonCount + "‰ñ‰Ÿ‚³‚ê‚Ü‚µ‚½";

            Color c = Image.color;
            c.a = 1;
            Image.color = c;
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        Color c = Image.color;
        c.a -= 0.01f;
        Image.color = c;

    }
}
