using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{
    Canvas helpCanvas;

    private void Awake()
    {
        this.helpCanvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            this.helpCanvas.enabled = !this.helpCanvas.enabled;
            if (this.helpCanvas.enabled)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}
