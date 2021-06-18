using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class CoinCouter : MonoBehaviour
{
    public Text tx;

    private void Update()
    {
        tx.text = FindObjectOfType<GameManager>().CountCoin.ToString();
    }
}
