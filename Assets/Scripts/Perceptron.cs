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
    //public TrainingSet[] trainingSets;
    List<TrainingSet> trainingSets = new List<TrainingSet>();

    double[] weight = { 0, 0 };
    double bias = 0;
    double totalError = 0;

    //Variable game object for simulation
    public GameObject npc;

    //Method to relate ML alogarythm with game object
    public void SendInput(double input_1, double input_2, double output)
    {
        //React
        double result = CalcOutput(input_1, input_2);
        Debug.Log(result);

        if (result == 0) // duck for cover
        {
            npc.GetComponent<Animator>().SetTrigger("Crouch");
            npc.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            npc.GetComponent<Rigidbody>().isKinematic = true;
        }

        TrainingSet s = new TrainingSet();
        s.input = new double[2] { input_1, input_2 };
        s.output = output;
        trainingSets.Add(s);
        Train();
    }


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
        return ActivationFunction(DotProductBias(weight, trainingSets[i].input));
        //double dp = DotProductBias(weight, trainingSets[i].input);
        //if (dp > 0)
        //{
        //    return 1;
        //}
        //else
        //{
        //    return 0;
        //}
    }

    double CalcOutput(double inp1, double inp2)
    {
        double[] input = new double[] { inp1, inp2 };
        return ActivationFunction(DotProductBias(weight, input));

        //double dp = DotProductBias(weight, input);

        //if (dp > 0)
        //{
        //    return 1;
        //}
        //else
        //{
        //    return 0;
        //}
    }

    //Refactor calc input
    double ActivationFunction(double dp)
    {
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

    //void Train(int epochs)
    //{
    //    InitialWeight();

    //    for (int e = 0; e < epochs; e++)
    //    {
    //        totalError = 0;
    //        for (int t = 0; t < trainingSets.Length; t++)
    //        {
    //            UpdateWeight(t);
    //            Debug.Log("W1: " + (weight[0]) + " W2: " + weight[1] + " B: " + bias);
    //        }
    //        Debug.Log("Total ERROR: " + totalError);
    //    }
    //}

    void Train()
    {
        for (int t = 0; t < trainingSets.Count; t++)
        {
            UpdateWeight(t);
            Debug.Log("W1: " + (weight[0]) + " W2: " + weight[1] + " B: " + bias);
        }
    }

    // Use this for initialization
    void Start()
    {
        //Module 1 lecture
        //Train(8);
        //Debug.Log("Test 0 || 0: " + CalcOutput(0, 0));

        //modul 3 lecture
        InitialWeight();

    }

    // Update is called once per frame
    void Update()
    {

    }
}