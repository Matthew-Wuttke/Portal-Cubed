using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour {

	//rotate a cube
	void Update () {
        gameObject.transform.Rotate(new Vector3(10, -10, -10)* Time.deltaTime);
	}
}
