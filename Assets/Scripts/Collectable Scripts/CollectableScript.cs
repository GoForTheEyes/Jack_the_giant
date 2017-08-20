using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour {

    //Player has set time to collect

    private void OnEnable()
    {
        Invoke("DestroyCollectable",6f);
    }

    void DestroyCollectable()
    {
        gameObject.SetActive(false);
    }



}
