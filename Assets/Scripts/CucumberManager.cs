using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CucumberManager : MonoBehaviour
{
    private string m_tag = "Cucumber";
    public static int currentCucumberCount = 0;
    Text cucumberTextCount;
    public GameObject[] cucumbers;

    private void Awake()
    {
        this.cucumberTextCount = GetComponent<Text>();
        currentCucumberCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        this.cucumbers = GameObject.FindGameObjectsWithTag(this.m_tag);
        currentCucumberCount = this.cucumbers.Length;
        this.cucumberTextCount.text = currentCucumberCount.ToString();
    }
}
