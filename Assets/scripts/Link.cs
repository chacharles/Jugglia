using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour {

    public Neurone inNeurone = null;
    public Neurone outNeurone = null;
    public float weight;

    public void Init(Neurone n, Neurone m)
    {
        inNeurone = n;
        outNeurone = m;

        weight = Random.Range(-1.0f, 1.0f);
        Debug.Log("Weight=" + weight);

        GameObject obj = new GameObject("line");
        LineRenderer lineRenderer = obj.AddComponent<LineRenderer>();

        lineRenderer.material = Resources.Load("Unlit/Link") as Material;// new Material(Shader.Find("Particles/Additive"));
        //Debug.Log("Material " + lineRenderer.material.ToString());

        lineRenderer.widthMultiplier = 0.01f;
        lineRenderer.positionCount = 2;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        Color c1 = Color.yellow;
        Color c2 = Color.red;

        /*        float alpha = 1.0f;
                Gradient gradient = new Gradient();
                gradient.SetKeys(
                    new GradientColorKey[] {
                        new GradientColorKey(c1, 0.0f),
                        new GradientColorKey(c2, 1.0f),
        //                new GradientColorKey(Color.HSVToRGB(180.0f, weight * 1.0f, 1.0f), 0.0f),
        //                new GradientColorKey(Color.HSVToRGB(0.0f, weight * 1.0f, 1.0f), 1.0f)
                    },
                    new GradientAlphaKey[] {
                        new GradientAlphaKey(alpha, 0.0f),
                        new GradientAlphaKey(alpha, 1.0f)
                    }
                );
                lineRenderer.colorGradient = gradient;*/
        //Debug.Log("ColorGradient = " + lineRenderer.colorGradient.ToString());

        lineRenderer.material.color = Color.HSVToRGB(0.0f, weight, 1.0f);

        lineRenderer.SetPosition(0, new Vector3(inNeurone.GetPosx(), inNeurone.GetPosy(), 0.0f));
        lineRenderer.SetPosition(1, new Vector3(outNeurone.GetPosx(), outNeurone.GetPosy(), 0.0f));

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
 