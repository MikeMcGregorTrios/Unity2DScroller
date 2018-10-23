using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    // The speed at which this layer should move.
    public float scrollSpeed;

    private Vector3 scroll = new Vector3();
    //The end point reached where the image should jump back to the end of the line.
    public Vector3 endPos = new Vector3();
    // How many tiles or images are in the lineup for this layer.
    public int numTiles;
    private SpriteRenderer image;

    // Used to pause movement 
    public bool canMove = true;
    

    // Use this for initialization
    void Start () {
        GameManager.instance.AddMoving(this);
        image = GetComponent<SpriteRenderer>();
        scroll = new Vector3(-scrollSpeed, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        // Can we move ?
        if (canMove)
        {
            // Are we past the point of the end Position?
            if (this.transform.position.x <= endPos.x - (image.bounds.size.x))
            {
                // Move to the start of the line.
                this.transform.Translate(new Vector3(((image.bounds.size.x * numTiles) * 0.99f), 0f, 0f));
               
            }
            this.transform.Translate(scroll * Time.deltaTime);
        }
            
	}
}
