using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI ui;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text coinText;
    private int coinCount;

    private void Awake()
    {
        if (ui == null) ui = this;
        else Destroy(this);
    }

    public void SetLives(int amount)
    {
        livesText.text = amount.ToString();
    }

    public void ShowCoinCount(int amount)
    {
        coinText.text = amount.ToString();
    }

    public void AddCoin()
    {
        coinCount++;
        coinText.text = coinCount.ToString();
    }
}
