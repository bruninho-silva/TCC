using UnityEngine;
using System.Collections;

public class mouseposition : MonoBehaviour {

	public Transform targetObject;
	public Vector2 screenPos;
	public float ratio = 0.005f;

	public Vector2 previousPosition;
	public float calculatedDistance;
	public float distance;

	private void Update()
	{
		// Get Angle in Radians
		float AngleRad = Mathf.Atan2(Input.mousePosition.y - transform.position.y, Input.mousePosition.x - transform.position.x);
		float AngleDeg = (180 / Mathf.PI) * AngleRad;
		transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
		calculatedDistance = Vector2.Distance(transform.position , Input.mousePosition);
		distance = calculatedDistance/50f; 
		transform.localScale = new Vector3(distance/2,1,1);
	}

	void OnGUI() {
		screenPos = Event.current.mousePosition;
	}
		
}
