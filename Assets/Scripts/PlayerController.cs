using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
		public float RunSpeed = 9;		
		public float TurnSpeed = 100f;
		
		public float ThumbStickDeadZone = 0.15f;
		
		[HideInInspector]
		public float CurSpeed = 0;
		
		private Vector3 MoveDirection = Vector3.zero;
		private float Angle;
		private Transform NewTransform;
		private CharacterController Ccontroller;
		
		private void Awake()
		{
			Ccontroller = GetComponent<CharacterController>();
			NewTransform = transform;
		}
		
		public void Update()
		{
			var x = Input.GetAxis("Horizontal");
			var y = Input.GetAxis("Vertical");
			
			CurSpeed = 0;
			
			MoveDirection.y -= Time.deltaTime;
			
			if (Mathf.Abs(y) > ThumbStickDeadZone || (Mathf.Abs(x) > ThumbStickDeadZone))
			{
				Angle = Mathf.Atan2(x, y) * (180 / Mathf.PI);
				CurSpeed = RunSpeed;
			}
			
			if (Ccontroller.isGrounded)
			{
				MoveDirection = NewTransform.TransformDirection(Vector3.forward) * CurSpeed;
			}
			
			Ccontroller.Move(MoveDirection * Time.deltaTime);
			NewTransform.rotation = Quaternion.Lerp(NewTransform.rotation, Quaternion.Euler(new Vector3(0, Angle, 0)), Time.deltaTime * TurnSpeed);
		}
}
