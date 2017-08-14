using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds;

    private float distanceBetweenClouds = 3f;
    private float minX, maxX;
    private float lastCloudPositionY;

    private float controlX;

    [SerializeField]
    private GameObject[] collectables;

    private GameObject player;

    private void Awake()
    {
        SetMinAndMax();
        CreateClouds();
    }

    void SetMinAndMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, 0));
        //0.5f is padding to avoid the cloud spawns without sufficient span
        //on playable zone
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    void Shuffle(GameObject[] arrayToShuffle)
    {
        for (int i = 0; i < arrayToShuffle.Length; i++)
        {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
        // GameObject temp = arrayToShuffle[i];
        // arrayToShuffle[i] = 3; meaning  temp = 3;
        // arrayToShuffle[i] = arrayToShuffle[random]; it had a value of 3
        // let's say that arratyToShuffle[random] = 5; not arrayToShuffle[i] =5
        // then we save arrayToShuffle[random] = 3 so the value 3 is not lost
        // we are just shuffling the order of indexes
    }

    void CreateClouds()
    {
        float positionY = 0f;

        Shuffle(clouds);
        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;

            //This is to ensure clouds are not in the same side
            //creates a zig zag pattern for clouds
            if (controlX == 0)
            {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
            }
            else if (controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
            } else if (controlX==3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }

                lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
            positionY -= distanceBetweenClouds;
        }
    }



}
