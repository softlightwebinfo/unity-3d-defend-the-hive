﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryManager : MonoBehaviour
{
    Text cherryTextCount;

    private void Awake()
    {
        this.cherryTextCount = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.cherryTextCount.text = PlayerManager.currentCherryCount.ToString();
    }
}
