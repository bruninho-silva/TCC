using UnityEngine;
using System.Collections;

//calculate which side of the box there is a collision
public class BoxRaycasting : MonoBehaviour {

	//fields
	public bool collisionUp;
	public bool collisionDown;
	public bool collisionLeft;
	public bool collisionRight;

	//show rays debug
	public bool showRays = false;

	//ray cast fields
	public float rayDistance;

	//the tile that hit the object
	RaycastHit TileHit;
	Vector3 pos;

	//box rays
	Ray LFloorRay;
	Ray RFloorRay;
	Ray LCeilingRay;
	Ray RCeilingRay;
	Ray LWallTopRay;
	Ray LWallBottomRay;
	Ray RWallTopRay;
	Ray RWallBottomRay;

	//floor
	public GameObject bottomLeft;
	public GameObject bottomRight;

	//wall Left
	public GameObject leftTop;
	public GameObject leftBottom;

	//wall right
	public GameObject rightTop;
	public GameObject rightBottom;

	//ceiling
	public GameObject topLeft;
	public GameObject topRight;

	public GameObject Rightobj;
	public GameObject Leftobj;

	public bool isCollided = false;
	void Start(){

	}

	// Update is called once per frame
	void Update()
	{
		checkCollision ();
		//debug
		if (showRays)
			drawRaycast();
	}

	//debug functions
	void drawRaycast()
	{
		//draw left floor
		//Debug.DrawLine(bottomLeft.gameObject.transform.position, new Vector3(bottomLeft.gameObject.transform.position.x, bottomLeft.gameObject.transform.position.y - rayDistance, bottomLeft.gameObject.transform.position.z), Color.red);

		//draw right floor
		//Debug.DrawLine(bottomRight.gameObject.transform.position, new Vector3(bottomRight.gameObject.transform.position.x, bottomRight.gameObject.transform.position.y - rayDistance, bottomLeft.gameObject.transform.position.z), Color.red);

		//draw left ceiling
		//Debug.DrawLine(topLeft.gameObject.transform.position, new Vector3(topLeft.gameObject.transform.position.x, topLeft.gameObject.transform.position.y + rayDistance, bottomLeft.gameObject.transform.position.z), Color.red);

		//draw right ceiling
		//Debug.DrawLine(topRight.gameObject.transform.position, new Vector3(topRight.gameObject.transform.position.x, topRight.gameObject.transform.position.y + rayDistance, bottomLeft.gameObject.transform.position.z), Color.red);

		//draw left wall top
		Debug.DrawLine(leftTop.gameObject.transform.position, new Vector3(leftTop.gameObject.transform.position.x - rayDistance, leftTop.gameObject.transform.position.y, leftTop.gameObject.transform.position.z), Color.red);

		//draw left wall bottom
		//Debug.DrawLine(leftBottom.gameObject.transform.position, new Vector3(leftBottom.gameObject.transform.position.x - rayDistance+4f, leftBottom.gameObject.transform.position.y, leftBottom.gameObject.transform.position.z), Color.red);

		//draw right wall top
		Debug.DrawLine(rightTop.gameObject.transform.position, new Vector3(rightTop.gameObject.transform.position.x + rayDistance, rightTop.gameObject.transform.position.y, rightTop.gameObject.transform.position.z), Color.red);

		//draw right wall bottom
		//Debug.DrawLine(rightBottom.gameObject.transform.position, new Vector3(rightBottom.gameObject.transform.position.x + rayDistance-4f, rightBottom.gameObject.transform.position.y, rightBottom.gameObject.transform.position.z), Color.red);
	}

	void checkCollision()
	{
		//Collision Detection (with Raycast)
		/*LFloorRay = new Ray(new Vector3(bottomLeft.gameObject.transform.position.x, bottomLeft.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.down);
		RFloorRay = new Ray(new Vector3(bottomRight.gameObject.transform.position.x, bottomRight.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.down);

		LCeilingRay = new Ray(new Vector3(topLeft.gameObject.transform.position.x, topLeft.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.up);
		RCeilingRay = new Ray(new Vector3(topRight.gameObject.transform.position.x, topRight.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.up);*/

		LWallTopRay = new Ray(new Vector3(leftTop.gameObject.transform.position.x, leftTop.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.left);
		LWallBottomRay = new Ray(new Vector3(leftBottom.gameObject.transform.position.x, leftBottom.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.left);

		RWallTopRay = new Ray(new Vector3(rightTop.gameObject.transform.position.x, rightTop.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.right);
		RWallBottomRay = new Ray(new Vector3(rightBottom.gameObject.transform.position.x, rightBottom.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.right);

		TileHit = new RaycastHit();

		//check floor(down)
		/*if (Physics.Raycast(LFloorRay, out TileHit, rayDistance+4f + .001f) || Physics.Raycast(RFloorRay, out TileHit, rayDistance-4f + .001f))
		{
			collisionDown = true;
		}
		else
			collisionDown = false;

		//check ceiling (up)
		if (Physics.Raycast(LCeilingRay, out TileHit, rayDistance + .001f) || Physics.Raycast(RCeilingRay, out TileHit, rayDistance + .001f))
		{
			collisionUp = true;
		}
		else
			collisionUp = false;
		*/
		if (rayDistance < 100f) {
			rayDistance += Time.deltaTime*500f;
		}

		//check wall left
		if (Physics.Raycast(LWallTopRay, out TileHit, rayDistance + .001f))
		{
			collisionLeft = true;
			if (TileHit.collider.tag == "posed") {
				Leftobj = TileHit.collider.gameObject;
			}
			//transform.localPosition = Vector3.Lerp (transform.localPosition, new Vector3 (transform.localPosition.x + 65f, 0, 0), Time.deltaTime * 20f);
		}
		else
			collisionLeft = false;

		//check right wall
		if (Physics.Raycast(RWallTopRay, out TileHit, rayDistance + .001f))
		{
			collisionRight = true;
			if (TileHit.collider.tag == "posed") {
				Rightobj = TileHit.collider.gameObject;
			}
			//transform.localPosition = Vector3.Lerp (transform.localPosition, new Vector3 (transform.localPosition.x - 65f, 0, 0), Time.deltaTime * 20f);

		}
		else
			collisionRight = false;

	}

}