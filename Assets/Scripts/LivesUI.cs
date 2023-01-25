using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;
    public Text livesText1;

    public GameObject LivePanel;
    public GameObject ZeroLivePanel;

    void Update()
    {
        livesText.text = "TOWER LIVES\n" + PlayerStats.Lives.ToString();

        if(PlayerStats.Lives == 0)
        {
            ZeroLiveDisplay();
            livesText1.text = "TOWER LIVES\n" + "0";
        }
    }

    void ZeroLiveDisplay()
    {
        LivePanel.gameObject.SetActive(false);
        ZeroLivePanel.gameObject.SetActive(true);
    }
}
