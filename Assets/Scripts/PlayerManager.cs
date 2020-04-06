using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int liveRemaining;
    public static int currentCherryCount;
    public int tempCurrentCherryCount;
    public bool isCollectingCherries;

    private void Awake()
    {
        liveRemaining = 3;
        currentCherryCount = 0;
        this.tempCurrentCherryCount = 0;
        this.isCollectingCherries = false;
    }

    private void Update()
    {
        if (this.isCollectingCherries)
        {
            // Cada 60 frames
            if (this.tempCurrentCherryCount >= 60)
            {
                currentCherryCount++;
                this.tempCurrentCherryCount = 0;
                PointsManager.AddPoints(5);
            }
            else
            {
                //Aun no hemos llegado al frame numero 60
                this.tempCurrentCherryCount++;
            }
        }

        switch (liveRemaining)
        {
            case 2:
                this.ChangeColorImageLife("Life3");
                break;
            case 1:
                this.ChangeColorImageLife("Life3");
                this.ChangeColorImageLife("Life2");
                break;
            case 0:
                this.ChangeColorImageLife("Life3");
                this.ChangeColorImageLife("Life2");
                this.ChangeColorImageLife("Life1");
                break;
        }
    }

    private void ChangeColorImageLife(string image)
    {
        Image life3 = GameObject.Find(image).GetComponent<Image>();
        life3.color = Color.red;
        Color c = life3.color;
        c.a = 0.6f;
        life3.color = c;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CherryTree"))
        {
            this.isCollectingCherries = true;
            currentCherryCount++;
            PointsManager.AddPoints(5);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CherryTree"))
        {
            this.isCollectingCherries = false;
        }
    }
}
