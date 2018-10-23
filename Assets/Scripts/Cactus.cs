using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour {

    public float scrollSpeed;
    private Vector3 scroll = new Vector3();
    public bool canMove = true;


    private void Awake()
    {
        GameManager.instance.AddCactus(this);
    }

    // Use this for initialization
    void Start () {
        scroll = new Vector3(-scrollSpeed, 0f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            this.transform.Translate(scroll * Time.deltaTime);
        }

        if (this.transform.position.x <= -15f)
        {
            GameManager.instance.cactus.Remove(this);
            Destroy(this.gameObject);
        }
        
    }
}
