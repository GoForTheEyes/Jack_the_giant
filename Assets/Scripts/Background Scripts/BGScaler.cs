using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	
	void Start () {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;
        float width = sr.sprite.bounds.size.x;

        //total height of camera
        float worldHeight = Camera.main.orthographicSize * 2f;
        //Worldwidth is worldheight * aspect ratio
        float worldWidth = worldHeight / Screen.height * Screen.width;

        //what is the scale the sprite needs to be
        //in the x coord to fill the screen
        tempScale.x = worldWidth / width;
        transform.localScale = tempScale;
    }
	

}
