using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldUI : MonoBehaviour
{
    public Text goldText;

    void Update()
    {
        goldText.text = PlayerStats.Money.ToString();
    }
}
