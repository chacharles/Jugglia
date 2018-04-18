using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour {

    public Neurone[] neurones;
    int nLayer;

    public void Init(int nbLayer,int nb,int nbLinkIn, int nbLinkOut) {
        nLayer = nbLayer;
        Debug.Log("Layer " + nbLayer + "  with " + nb + " Neurones");
        neurones = new Neurone[nb];
        for ( int i = 0; i<nb; i++)
        {
            Debug.Log(" Layer " + nbLayer + " Neurones nb=" + i + " inp=" + nbLinkIn + " out=" + nbLinkOut);
            neurones[i] = gameObject.AddComponent<Neurone>();
            neurones[i].Init(nbLinkIn, nbLinkOut,nbLayer,i);
        }
    }

    // Use this for initialization
    void Start () {
    }
    
    public override string ToString()
    {
        return "Layer " + nLayer + " nbNeur=" + neurones.Length + " inp=" + neurones[0].input.Length + " out=" + neurones[0].output.Length;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
