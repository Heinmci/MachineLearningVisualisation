using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

	[SerializeField]
	private Transform[] sphereTransforms;
	// Use this for initialization
	void Start () {
		foreach (var sphere in sphereTransforms){
			int result = LibWrapper.random_classification(sphere.position.z);
			if(result <0) {
				sphere.position += Vector3.down;
			} else
			{
				sphere.position += Vector3.up;
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
