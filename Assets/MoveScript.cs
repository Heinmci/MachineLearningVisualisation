using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

	[SerializeField]
	private Transform[] sphereTransforms;
	[SerializeField]
	private Transform[] trainningExample;
	// Use this for initialization
	void Start () {
		System.IntPtr  coeff = LibWrapper.linear_create();
		double[] points = {trainningExample[0].position.x,trainningExample[0].position.z,-1,trainningExample[0].position.x,trainningExample[0].position.z,-1,trainningExample[0].position.x,trainningExample[0].position.z,1};
		
		LibWrapper.linear_train_classification(coeff,points);
		foreach (var sphere in sphereTransforms){
			double[] point = {sphere.position.x,sphere.position.z};
			int result = LibWrapper.classify_point(coeff,point);
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
