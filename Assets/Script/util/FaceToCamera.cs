using UnityEngine;
using System.Collections;

public class FaceToCamera : MonoBehaviour {
	public Vector3 rotation;
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		if(renderer==null)transform.rotation = Camera.main.transform.rotation*Quaternion.Euler(rotation);
	}
	// Update is called once per frame
	void OnWillRenderObject () {
		transform.rotation = Camera.current.transform.rotation*Quaternion.Euler(rotation);
	}
}
