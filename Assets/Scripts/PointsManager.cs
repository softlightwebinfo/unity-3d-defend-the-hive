using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointsManager : MonoBehaviour
{
    public static int currentPoints;
    Text pointsText;

    private void Awake()
    {
        this.pointsText = GetComponent<Text>();
        currentPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.pointsText.text = currentPoints.ToString();
    }

    public static void AddPoints(int points)
    {
        currentPoints += points;
    }
}
