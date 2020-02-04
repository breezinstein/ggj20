using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LifeControl : MonoBehaviour
{
    public int MaximumLife = 3;
    public Image[] Hearts;
    public int Life = 0;
    public int progressBarValue = 0;
    public int progressBarValueMax = 100;
    public float progessPrecentage { get { return progressBarValue / (float)progressBarValueMax; } }

    void Start()
    {
        Life = MaximumLife;
    }
    public void SetProgressMax(int val)
    {
        progressBarValueMax = val;
    }
    public void DecreaseLife()
    {
        Life--;
        Hearts[Life].enabled = false;
    }

    public void DecreaseProgressBar(int Amount)
    {
        progressBarValue -= Amount;
        if(progressBarValue < 0)
        {
            progressBarValue = 0;
        }
        if(progressBarValue > progressBarValueMax)
        {
            progressBarValue = progressBarValueMax;
        }
        GameManager.Instance.UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
