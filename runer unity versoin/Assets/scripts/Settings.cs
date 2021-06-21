using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Settings : MonoBehaviour
{
    private void OnEnable()
    {
        FindObjectOfType<GameManager>().MovRaL();
    }
}
