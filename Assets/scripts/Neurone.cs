using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neurone : MonoBehaviour {

    public static Transform neuronePrefab;

    public Link[] input;
    public Link[] output;
    public float weight;
    public float bias;
    int posx = 0;
    int posy = 0;
    Transform neurobj;
    

    public void Init(int nbLinkIn, int nbLinkOut, int nblayer, int nbNeurone) {
        weight = Random.Range(0.0f, 1.0f);
        bias = Random.Range(0.0f, 10.0f);

        input = new Link[nbLinkIn];
        output = new Link[nbLinkOut];
        posx = nblayer;
        posy = nbNeurone;

        neurobj = Instantiate(neuronePrefab, new Vector3( GetPosx(), GetPosy(), 0), Quaternion.identity);
        neurobj.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.5f, weight, 1.0f);
    }

    // Use this for initialization
    void Start () {
    }

    public override string ToString() {
        return "neurone px=" + posx + " py=" + posy + " inp=" + input.Length + " out=" + output.Length;
    }

    public float GetPosx()
    {
        return (float)(posx) / 1.0f - 3.0f;
    }

    public float GetPosy()
    {
        return 5.0f - (float)(posy) / 3.0f;
    }

    public void WeightChange() {
        neurobj.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.5f, weight, 1.0f);
    }

    // Update is called once per frame
    void Update () {
	}
}
