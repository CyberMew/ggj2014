
using UnityEngine;
using System.Collections;

public class PulseScript : MonoBehaviour { 
	public float startSize = 3;
	public float minSize = 1;
	public float maxSize = 6;
	
	public float speed = 1.0f;
	
	private Vector3 targetScale;
	private Vector3 baseScale;
	private float currScale;
	private bool isScalingUp = true;
	void Start() {
		baseScale = transform.localScale;
		transform.localScale = baseScale * startSize;
		currScale = startSize;
		targetScale = baseScale * startSize;
	}

	public void ChangeSize(bool bigger) {
		
		if (bigger)
						currScale += speed;//currScale++;
		else
						currScale -= speed;
		
		currScale = Mathf.Clamp (currScale, minSize, maxSize+1);
		
		targetScale = baseScale * currScale;
	}  

	void Update() {
		transform.localScale = Vector3.Lerp (transform.localScale, targetScale, Time.deltaTime); //speed * Time.deltaTime);
		
				// If you don't want an eased scaling, replace the above line with the following line
				//   and change speed to suit:
				// transform.localScale = Vector3.MoveTowards (transform.localScale, targetScale, speed * Time.deltaTime);
		
				if (isScalingUp) {
			if (currScale <= maxSize) {// (Input.GetKeyDown (KeyCode.UpArrow))
								ChangeSize (true);
						} else {
				isScalingUp = false; 
				//return;
						}
				} else { //(!isScalingUp )
			if (currScale > minSize) {
								ChangeSize (false);
						} else {
								isScalingUp = true;
						}
				}
	
  

		}
}