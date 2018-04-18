using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanelia : MonoBehaviour {

    public Layer input;
    public Layer output;
    public Layer[] layer;

    public void Init(int nbInput,int nbOutput, int nbLayers,int nbNeurones)
    {
        Debug.Log("Initialising Layers " + nbInput + " " + nbOutput + " " + nbLayers + " " + nbNeurones);
        input = gameObject.AddComponent<Layer>();
        output = gameObject.AddComponent<Layer>();
        input.Init(0, nbInput, 0, nbNeurones);
        output.Init(nbLayers-1, nbOutput, nbNeurones, 0);
        layer = new Layer[nbLayers];
        layer[0] = input;
        layer[nbLayers - 1] = output;

        Debug.Log("Building Layers");
        for (int i = 1; i < nbLayers - 1; i++)
        {
            layer[i] = gameObject.AddComponent<Layer>();
            if (i == 1)
            {
                layer[i].Init(i, nbNeurones, nbInput, nbNeurones);
            }
            else if (i == nbLayers - 2) {
                layer[i].Init(i, nbNeurones, nbNeurones, nbOutput);
            } else {
                layer[i].Init(i, nbNeurones, nbNeurones, nbNeurones);
            }
        }

        Debug.Log("Building Links");
        for (int i = 0; i < nbLayers - 1; i++)
        {
            Layer l = layer[i];
            Layer p = layer[i + 1];
            for (int j = 0; j < l.neurones.Length; j++) {
                Neurone n = l.neurones[j];
                for (int k = 0; k < p.neurones.Length; k++)
                {
                    Debug.Log("create links for " + l.ToString() + " AND " + p.ToString());
                    Neurone m = p.neurones[k];
                    Link li = gameObject.AddComponent<Link>();
                    li.Init(n, m);
                    Debug.Log("adding output link to " + n.ToString());
                    n.output[k] = li;
                    Debug.Log("adding input link to " + m.ToString());
                    m.input[j] = li;
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
    }

    public void SetInput(float[] inputValues) {
        if (layer[0].neurones.Length < inputValues.Length)
        {
            Debug.Log("ERROR WRONG SIZE OF INPUT");
            return;
        }

        for (int i = 0; i < inputValues.Length; i++)
        {
            layer[0].neurones[i].weight = inputValues[i];
            layer[0].neurones[i].WeightChange();
        }
        Propagate(1);
    }

    void Propagate(int nLayer)
    {

        if (nLayer >= layer.Length) return;
        foreach (Neurone neurone in layer[nLayer].neurones)
        {
            neurone.weight = 0.0f;
            foreach (Link link in neurone.input) {
                neurone.weight += link.inNeurone.weight * link.weight;
            }

            //neurone.weight = Sigmoid(neurone.weight - neurone.bias);

            neurone.WeightChange();
        }

       Propagate(nLayer + 1);
    }

    /** TODO Propagation by pulling computation from the end */
    void PropagatePulling(int nLayer) {
        // TODO
    }

    /** Propagate backward for correction of neural network */
    void BackPropagate() {
        // TODO
    }

    public float Sigmoid(float x) {
        return 1f / ( 1f + Mathf.Exp( -x ) );
    }

    public float GetOutput(int n)
    {
        if (layer[layer.Length - 1].neurones.Length < n)
        {
            Debug.Log("ERROR WRONG SIZE OF OUTPUT");
            return 0.0f;
        }
        return layer[layer.Length - 1].neurones[n].weight;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
