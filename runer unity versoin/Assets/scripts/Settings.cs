using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Settings : MonoBehaviour
{
    public void CheckRichtButton(string btn)
    {
        if (btn.Length == 1) FindObjectOfType<GameManager>().BtnsRight(btn);
    }
    public void CheckLeftButton(string btn)
    {
        if (btn.Length == 1) FindObjectOfType<GameManager>().BtnsLeft(btn);
    }
}
