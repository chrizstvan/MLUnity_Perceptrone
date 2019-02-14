using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingSet
{
    public double[] input;
    public double output;
}

public class Perceptron : MonoBehaviour 
{
    public TrainingSet[] trainingSets;

    double[] weight = { 0, 0 };
    double bias = 0;
    double totalError = 0;

    double DotProductBias(double[] weights, double[] input)
    {
        if (weights == null || input == null) return 1;
        if (weights.Length != input.Length) return 1;

        double d = 0;
        for (int x = 0; x < weights.Length; x++)
        {
            d += weights[x] * input[x];
        }

        d += bias;
        return d;
    }

    double CalcOutput(int i)
    {
        double dp = DotProductBias(weight, trainingSets[i].input);
        if (dp > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    double CalcOutput(double inp1, double inp2)
    {
        double[] input = new double[] { inp1, inp2 };
        double dp = DotProductBias(weight, input);

        if (dp > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    void InitialWeight()
    {
        for (int i = 0; i < weight.Length; i++)
        {
            weight[i] = Random.Range(-1.0f, 1.0f);
        }
        bias = Random.Range(-1.0f, 1.0f);
    }

    void UpdateWeight(int j)
    {
        double error = trainingSets[j].output - CalcOutput(j);
        totalError += Mathf.Abs((float)error);
        for (int i = 0; i < weight.Length; i++)
        {
            weight[i] += error * trainingSets[j].input[i];
        }
        bias += error;
    }

    void Train(int epochs)
    {
        InitialWeight();

        for (int e = 0; e < epochs; e++)
        {
            totalError = 0;
            for (int t = 0; t < trainingSets.Length; t++)
            {
                UpdateWeight(t);
                Debug.Log("W1: " + (weight[0]) + " W2: " + weight[1] + " B: " + bias);
            }
            Debug.Log("Total ERROR: " + totalError);
        }
    }

	// Use this for initialization
	void Start () 
    {
        Train(8);
        Debug.Log("Test 0 || 0: " + CalcOutput(0, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
