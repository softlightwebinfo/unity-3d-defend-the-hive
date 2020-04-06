using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CucumberManager : MonoBehaviour
{
    private string m_tag = "Cucumber";
    public int currentCucumberCount = 0;
    Text cucumberTextCount;
    public GameObject[] cucumbers;

    private void Awake()
    {
        this.cucumberTextCount = GetComponent<Text>();
        this.currentCucumberCount = 0;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.cucumbers = GameObject.FindGameObjectsWithTag(this.m_tag);
        this.currentCucumberCount = this.cucumbers.Length;
        this.cucumberTextCount.text = this.currentCucumberCount.ToString();
    }
}
