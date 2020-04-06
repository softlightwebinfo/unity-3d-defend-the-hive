using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetlePatrol : MonoBehaviour
{
    public static bool isDead = false;
    public static bool isEating = false;
    public static bool isAttacking = false;
    public float speed = 5f;
    public float directionChangeInterval = 1.0f;
    public float maxHeadingChange = 30.0f;

    Animator beetleAnimator;
    CharacterController controller;
    float heading; //Angulo entre 0 y 360º
    Vector3 targetRotation;

    private void Start()
    {
        this.beetleAnimator = GetComponent<Animator>();
        this.controller = GetComponent<CharacterController>();
        this.heading = Random.Range(0, 360);
        this.transform.eulerAngles = new Vector3(0, this.heading, 0);
        StartCoroutine("NewHeading");
    }

    private void Update()
    {
        if (!isDead && !isEating && !isAttacking)
        {
            this.transform.eulerAngles = Vector3.Slerp(this.transform.eulerAngles, this.targetRotation, Time.deltaTime * this.directionChangeInterval);
            Vector3 forward = this.transform.TransformDirection(Vector3.forward);
            this.controller.SimpleMove(forward * this.speed);
        }
    }

    IEnumerator NewHeading()
    {
        while (true)
        {
            this.NewHeadingRoutine();
            yield return new WaitForSeconds(this.directionChangeInterval);
        }
    }

    void NewHeadingRoutine()
    {
        float floor = this.transform.eulerAngles.y - this.maxHeadingChange;
        float ceil = this.transform.eulerAngles.y + this.maxHeadingChange;

        this.heading = Random.Range(floor, ceil);
        this.targetRotation = new Vector3(0, this.heading, 0);
    }
}
