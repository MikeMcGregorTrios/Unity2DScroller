using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawn : MonoBehaviour {

    public float minTime;
    public float maxTime;
    public float spawnTime;

    public float timer = 0f;

    public GameObject cactus;

	// Use this for initialization
	void Start () {
        Random.InitState(Mathf.RoundToInt(Time.time));
        spawnTime = Random.Range(minTime, maxTime);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= spawnTime && GameManager.instance.isAlive)
        {
            timer = 0f;
            spawnTime = Random.Range(minTime, maxTime);

            Instantiate(cactus);
            cactus.transform.position = this.transform.position;
        }
	}
}
