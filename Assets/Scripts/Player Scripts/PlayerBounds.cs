using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour {

    private float minX, maxX;

    private void Start()
    {
        SetMinAndMax();
    }


    // Update is called once per frame
    void Update () {
		if (transform.position.x < minX)
        {
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }
        else if (transform.position.x > maxX) 
        {
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
	}

    void SetMinAndMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, 0));
        float width = GetComponent<BoxCollider2D>().size.x; 
        //0.5f is padding to avoid the cloud spawns without sufficient span
        //on playable zone
        maxX = bounds.x - width/2;
        minX = -bounds.x + width/2;
    }

}
