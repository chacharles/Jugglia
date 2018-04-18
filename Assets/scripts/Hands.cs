using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour {

    public Transform handPrefab;
    public Transform handLocation;

    // Use this for initialization
    void Start()
    {
        Instantiate(handPrefab, handLocation.position, handLocation.rotation);
    }

	
	// Update is called once per frame
	void Update () {
    }
}
