using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text tx;
    void Update()
    {
        tx.text = player.position.z.ToString("0");
    }
}
