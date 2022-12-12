using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI text;
    [SerializeField]
    private Image hpBar;

    // Start is called before the first frame update
    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        GetComponentInParent<IHealth>().OnHPPctChanged += HandleHPPctChanged;
        text.text = "NPC";
    }

    private void HandleHPPctChanged(float pct)
    {
        Debug.Log("HpBar: " + pct);
        hpBar.fillAmount = pct;
    }

    /*
    public TextMeshProUGUI nameText;
    public Image bar;
    private float maxValue;

    public void Initialize(string text, int maxVal)
    {
        nameText.text = text;
        maxValue = maxVal;
        bar.fillAmount = 1.0f;
    }

    // Start is called before the first frame update
    private void Start()
    {
        GetComponentInParent<IHealth>().OnHPPctChanged += HandleHPPctChanged;

    }

    private void HandleHPPctChanged(float pct)
    {
        bar.fillAmount = pct;
    }*/
}
