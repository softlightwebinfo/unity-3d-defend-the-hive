using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BeetleManager : MonoBehaviour
{
    private string m_tag = "Beetle";
    public int currentBeetleCount = 0;
    Text beetleTextCount;
    public GameObject[] beetles;

    private void Awake()
    {
        this.beetleTextCount = GetComponent<Text>();
        this.currentBeetleCount = 0;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.beetles = GameObject.FindGameObjectsWithTag(this.m_tag);
        this.currentBeetleCount = this.beetles.Length;
        this.beetleTextCount.text = this.currentBeetleCount.ToString();
    }
}
