using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour {

	public Transform target;
	float lockRotation = 0;
	
	void Update()
	{		
		transform.LookAt(target);
		transform.position = new Vector3(target.position.x, 45f, target.position.z - 20f);
		transform.rotation = Quaternion.Euler(50f, lockRotation, lockRotation);
	}
}
