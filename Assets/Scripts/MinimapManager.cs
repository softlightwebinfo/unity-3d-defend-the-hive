using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinimapManager : MonoBehaviour
{
    RawImage minimap;
    private void Awake()
    {
        this.minimap = GetComponent<RawImage>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            this.minimap.enabled = !this.minimap.enabled;
        }
    }
}
