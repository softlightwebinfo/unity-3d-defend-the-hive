using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int liveRemaining;
    public static int currentCherryCount;
    public int tempCurrentCherryCount;
    public bool isCollectingCherries;
    public Transform[] spawningZones;
    public static bool hasDead;
    private void Awake()
    {
        liveRemaining = 3;
        currentCherryCount = 20;
        this.tempCurrentCherryCount = 0;
        this.isCollectingCherries = false;
        hasDead = false;
    }

    private void Start()
    {
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("SpawnZone");
        List<Transform> spawnsList = new List<Transform>();
        foreach (GameObject spawn in spawns)
        {
            spawnsList.Add(spawn.transform);
        }
        this.spawningZones = spawnsList.ToArray();
        spawnsList.Clear();
    }

    private void Update()
    {
        if (this.isCollectingCherries)
        {
            // Cada 60 frames
            if (this.tempCurrentCherryCount >= 60)
            {
                currentCherryCount++;
                this.tempCurrentCherryCount = 0;
                PointsManager.AddPoints(5);
            }
            else
            {
                //Aun no hemos llegado al frame numero 60
                this.tempCurrentCherryCount++;
            }
        }
        if (HealthManager.currentHealth <= 0 && !hasDead)
        {
            hasDead = true;
            liveRemaining--;
            switch (liveRemaining)
            {
                case 2:
                    this.ChangeColorImageLife("Life3");
                    GetComponent<Animator>().Play("CM_Die");
                    StartCoroutine(RespawnPlayer());
                    break;
                case 1:
                    this.ChangeColorImageLife("Life3");
                    this.ChangeColorImageLife("Life2");
                    GetComponent<Animator>().Play("CM_Die");
                    StartCoroutine(RespawnPlayer());
                    break;
                case 0:
                    this.ChangeColorImageLife("Life3");
                    this.ChangeColorImageLife("Life2");
                    this.ChangeColorImageLife("Life1");
                    break;
            }
        }
    }

    IEnumerator RespawnPlayer()
    {
        // Calculamos aleatoriamente en que posicion debemos aparecer
        int randomPos = Random.Range(0, this.spawningZones.Length);
        // Esperamos 4 segundos a que termine la animacion de la muerte
        yield return new WaitForSecondsRealtime(4.0f);
        // Movemos al jugador a la zona de spawning
        this.transform.position = this.spawningZones[randomPos].transform.position;
        // Volvemos a poner al jugador con su animacion de quieto
        GetComponent<Animator>().Play("CM_Idle");
        Slider slider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        HealthManager.currentHealth = slider.maxValue;
        hasDead = false;
    }

    private void ChangeColorImageLife(string image)
    {
        Image life3 = GameObject.Find(image).GetComponent<Image>();
        life3.color = Color.red;
        Color c = life3.color;
        c.a = 0.6f;
        life3.color = c;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CherryTree"))
        {
            this.isCollectingCherries = true;
            currentCherryCount++;
            PointsManager.AddPoints(5);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CherryTree"))
        {
            this.isCollectingCherries = false;
        }
    }
}
