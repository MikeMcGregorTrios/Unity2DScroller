using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {


    public float scrollSpeed;
    private Vector3 scroll = new Vector3();
    public bool canMove = true;


    // Use this for initialization
    void Start () {
        scroll = new Vector3(-scrollSpeed, 0f, 0f);
        GameManager.instance.coins.Add(this);
    }

    
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            this.transform.Translate(scroll * Time.deltaTime);
        }

        if (this.transform.position.x <= -15f)
        {
            GameManager.instance.coins.Remove(this);
            Destroy(this.gameObject);
        }

    }
}
