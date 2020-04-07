using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryControl : MonoBehaviour
{
    public Rigidbody m_rigibody;
    public float throwDistance = 10000.0f;
    public float timeToDestroy = 4.0f;
    private GameObject player;

    private void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                if (PlayerManager.currentCherryCount > 0)
                {
                    this.ThrowCherry();
                }
            }
        }
    }

    void ThrowCherry()
    {
        Ray cameraToWorldRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(cameraToWorldRay, out hit))
        {
            Debug.DrawLine(transform.position, hit.point);
            Vector3 directionToFire = hit.point - this.transform.position;
            Rigidbody cherryClone = (Rigidbody)Instantiate(this.m_rigibody, transform.position,
                                                           transform.rotation);
            cherryClone.useGravity = true;
            cherryClone.constraints = RigidbodyConstraints.None;
            cherryClone.AddForce(directionToFire.normalized * throwDistance);
            Destroy(cherryClone.gameObject, timeToDestroy);
            PlayerManager.currentCherryCount -= 1;
        }
    }
}
