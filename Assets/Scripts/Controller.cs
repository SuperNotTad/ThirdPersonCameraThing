using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	public float speed = 6.0F;
	private Vector3 moveDirection = Vector3.zero;
		
	void Update() {
		
	
	if (transform.rigidbody.velocity != Vector3.zero)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(transform.rigidbody.velocity.x,0,transform.rigidbody.velocity.z)), Time.deltaTime);
		}
	}
}
	
	

