using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntCamera : MonoBehaviour
{
	public Transform target;
	public float smoothing = 5f;
	Vector3 offset;

	// Use this for initialization
	void Start()
	{
		offset = transform.position - target.position;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");

		Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
		movementDirection.Normalize();

		if (movementDirection != Vector3.zero)
		{
			//Vector3 targetCamPos = target.position + offset;
			//transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
			transform.position += movementDirection * smoothing * Time.deltaTime;

		}
	}
}