using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public static CameraFollower sharedInstance;
    public GameObject followTarget;
    public float movementSmoothness = 1.0f;
    public float rotationSmoothness = 1.0f;
    public bool canFollow = true;

    private void Awake()
    {
        sharedInstance = this;
    }

    // Ultimo que se ejecuta en cada frame
    private void LateUpdate()
    {
        if (!this.followTarget || !this.canFollow)
        {
            return;
        }
        // Interpolacion lineal
        this.transform.position = Vector3.Lerp(this.transform.position, this.followTarget.transform.position, Time.deltaTime * this.movementSmoothness);

        // Interpolacion Esferica
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.followTarget.transform.rotation, Time.deltaTime * this.rotationSmoothness);
    }
}
