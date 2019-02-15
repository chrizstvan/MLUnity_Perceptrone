using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour 
{

	// Update is called once per frame
	void Update () 
    {
        if (gameObject.name == "Cube(Clone)" || gameObject.name == "Sphere(Clone)")
        {
            Destroy(gameObject, 2);
        }
	}
}
