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
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            if (PlayerManager.currentCherryCount > 0)
            {
                this.ThrowCherry();
            }
        }
    }

    void ThrowCherry()
    {
        Ray cameraToWorldRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit m_hit = new RaycastHit();
        if (Physics.Raycast(cameraToWorldRay, out m_hit))
        {
            Vector3 directionToFire = m_hit.point - this.transform.position;

            Rigidbody cherryClone = (Rigidbody)Instantiate(this.m_rigibody, this.transform.position, this.transform.rotation);
            cherryClone.useGravity = true;
            cherryClone.constraints = RigidbodyConstraints.None;
            cherryClone.AddForce(directionToFire.normalized * this.throwDistance);
            Destroy(cherryClone.gameObject, this.timeToDestroy);
            PlayerManager.currentCherryCount--;
        }
    }
}
