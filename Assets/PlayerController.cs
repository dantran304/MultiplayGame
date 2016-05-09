using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 100;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 100;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
	}
}
