﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleNPC : MonoBehaviour
{
    Animator m_Animator;
    public GameObject nextCucumberToDestroy;

    //Variables para responder al ataque de las cerezas
    public bool cherryHit = false;
    public bool hasReachedThePlayer = false;
    public float smoothTime = 3.0f;
    public Vector3 smoothVelocity = Vector3.zero;
    public HealthManager healthManager;
    public static BeetleManager manager;

    // Start is called before the first frame update
    void Start()
    {
        this.m_Animator = GetComponent<Animator>();
        this.healthManager = GameObject.Find("HealthSlider").GetComponent<HealthManager>();
        if (!manager)
        {
            manager = GameObject.Find("BeetlesValue").GetComponent<BeetleManager>();
        }
        manager.RecalculateBeetles();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.hasReachedThePlayer = true;
            this.healthManager.ReduceHealth();

            if (!this.cherryHit)
            {
                BeetlePatrol.isAttacking = true;
                GameObject thePlayer = collision.gameObject;
                Transform trans = thePlayer.transform;
                this.gameObject.transform.LookAt(trans);
                this.m_Animator.Play("Attack_OnGround");
                StartCoroutine("DestroyBeetle");
            }
            else
            {
                this.m_Animator.Play("Attack_Standing");
                StartCoroutine("DestroyBeetleStanding");
            }
        }
    }

    IEnumerator DestroyCucumber()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.nextCucumberToDestroy.gameObject);
        BeetlePatrol.isEating = false;
    }

    IEnumerator DestroyBeetle()
    {
        yield return new WaitForSecondsRealtime(4.0f);
        this.m_Animator.Play("Die_OnGround");
        Destroy(this.gameObject, 2.0f);
        this.hasReachedThePlayer = false;
        manager.RecalculateBeetles();
    }

    IEnumerator DestroyBeetleStanding()
    {
        yield return new WaitForSecondsRealtime(4.0f);
        this.m_Animator.Play("Die_Standing");
        Destroy(this.gameObject, 2.0f);
        this.cherryHit = false;
        this.hasReachedThePlayer = false;
        manager.RecalculateBeetles();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cucumber"))
        {
            this.nextCucumberToDestroy = other.gameObject;
            BeetlePatrol.isEating = true;
            this.m_Animator.Play("Eat_OnGround");
            StartCoroutine("DestroyCucumber");
        }

        if (other.gameObject.CompareTag("Cherry"))
        {
            print("Entry");
            BeetlePatrol.isAttacking = true;
            this.cherryHit = true;
            this.m_Animator.Play("Stand");
            PointsManager.AddPoints(25);
        }
    }
    private void Update()
    {
        if (this.cherryHit)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Transform trans = player.transform;
            this.gameObject.transform.LookAt(trans);
            if (!this.hasReachedThePlayer)
            {
                this.m_Animator.Play("Run_Standing");
            }
            this.transform.position = Vector3.SmoothDamp(this.transform.position, trans.position, ref this.smoothVelocity, this.smoothTime);
        }
    }
}
