using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptRegression : MonoBehaviour {

	[SerializeField]
	private Transform[] sphereTransforms;
	[SerializeField]
	private Transform[] trainningExample;
	// Use this for initialization
	void Start () {
		System.IntPtr coeff = LibWrapper.linear_create(3);
	
		double[] points = new double[trainningExample.Length *3];
		for(int i =0; i<trainningExample.Length;i++) {
			points[i*3] = trainningExample[i].position.y;
			points[i*3+1] = trainningExample[i].position.x;
			points[i*3+2] = trainningExample[i].position.z;
		} 
		LibWrapper.linear_train_regression(coeff,points,trainningExample.Length,trainningExample.Length *3);
		
		foreach (var sphere in sphereTransforms){
			double[] point = {sphere.position.x,sphere.position.z};
			float result = (float)LibWrapper.regress_point(coeff,point,2);
			sphere.position += Vector3.up * result;			
		} 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
