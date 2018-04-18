using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugglia : MonoBehaviour
{

    public Transform neuronePrfab;

    Kanelia kanelia;

    // Use this for initialization
    void Start()
    {
        Random.InitState((int)Time.time);

        Neurone.neuronePrefab = neuronePrfab;

        Debug.Log("Before brain creation");

        kanelia = gameObject.AddComponent<Kanelia>();
        kanelia.Init(6, 3, 4, 6);
//        kanelia.Init(6, 4, 8, 10);
        Debug.Log("After brain creation");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject baballe = GameObject.Find("Ball(Clone)");
        if (baballe != null) {
            float[] inputValues = {
                    baballe.GetComponent<Rigidbody>().position.x,
                    baballe.GetComponent<Rigidbody>().position.y,
                    baballe.GetComponent<Rigidbody>().position.z,
                    baballe.GetComponent<Rigidbody>().velocity.x,
                    baballe.GetComponent<Rigidbody>().velocity.y,
                    baballe.GetComponent<Rigidbody>().velocity.z
            };
            kanelia.SetInput( inputValues );
        }

        GameObject hand = GameObject.Find("Hand(Clone)");
        hand.transform.position = new Vector3(
            kanelia.GetOutput(0) / 10.0f,
            kanelia.GetOutput(1) / 10.0f,
            kanelia.GetOutput(2) / 10.0f
        );
    }
}
