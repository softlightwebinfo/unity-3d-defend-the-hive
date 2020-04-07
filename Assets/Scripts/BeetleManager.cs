using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BeetleManager : MonoBehaviour
{
    private string m_tag = "Beetle";
    public static int currentBeetleCount = 0;
    Text beetleTextCount;
    public GameObject[] beetles;

    private void Awake()
    {
        this.beetleTextCount = GetComponent<Text>();
        currentBeetleCount = 1;
        this.RecalculateBeetles();
    }

    public void RecalculateBeetles()
    {
        this.beetles = GameObject.FindGameObjectsWithTag(this.m_tag);
        currentBeetleCount = this.beetles.Length;
        this.beetleTextCount.text = currentBeetleCount.ToString();
    }
}
