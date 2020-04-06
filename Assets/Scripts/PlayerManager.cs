using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int currentCherryCount;
    public int tempCurrentCherryCount;
    public bool isCollectingCherries;

    private void Awake()
    {
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
