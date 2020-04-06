using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{
    Text victoryText;

    private void Awake()
    {
        this.victoryText = GetComponent<Text>();
        this.victoryText.text = "";
        victoryText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BeetleManager.currentBeetleCount == 0)
        {
            victoryText.text = "¡Enhorabuena!\nHas ganado";
            this.victoryText.enabled = true;
        }

        if (CucumberManager.currentCucumberCount == 0 || PlayerManager.liveRemaining == 0)
        {
            this.victoryText.text = "Game Over";
            this.victoryText.enabled = true;
            this.victoryText.color = Color.red;
        }
    }
}
