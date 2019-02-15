using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour 
{
    public GameObject spherePrefab;
    public GameObject cubePrefab;
    public Material green;
    public Material red;

    Perceptron _perceptron;

	// Use this for initialization
	void Start () 
    {
        _perceptron = GetComponent<Perceptron>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject benda = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
            benda.GetComponent<Renderer>().material = red;
            benda.GetComponent<Rigidbody>().AddForce(0, 0, 500);
            _perceptron.SendInput(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject benda = Instantiate(spherePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
            benda.GetComponent<Renderer>().material = green;
            benda.GetComponent<Rigidbody>().AddForce(0, 0, 500);
            _perceptron.SendInput(0, 1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject benda = Instantiate(cubePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
            benda.GetComponent<Renderer>().material = red;
            benda.GetComponent<Rigidbody>().AddForce(0, 0, 500);
            _perceptron.SendInput(1, 0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject benda = Instantiate(cubePrefab, Camera.main.transform.position, Camera.main.transform.rotation);
            benda.GetComponent<Renderer>().material = green;
            benda.GetComponent<Rigidbody>().AddForce(0, 0, 500);
            _perceptron.SendInput(1, 1, 1);
        }

	}
}
