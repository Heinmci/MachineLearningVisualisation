﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptClassification : MonoBehaviour {

	[SerializeField]
	private Transform[] sphereTransforms;
	[SerializeField]
	private Transform[] trainningExample;
	// Use this for initialization
	void Start () {
		int nbinputs = 3;
		System.IntPtr coeff = LibWrapper.linear_create(nbinputs);
	
		double[] points = new double[trainningExample.Length *3];
		for(int i =0; i<trainningExample.Length;i++) {
			points[i*3] = (trainningExample[i].position.y > 0)?1:-1;
			points[i*3+1] = trainningExample[i].position.x;
			points[i*3+2] = trainningExample[i].position.z;
		} 
		int ok = LibWrapper.linear_train_classification(coeff,points,trainningExample.Length,trainningExample.Length *3);
		if(ok == 0) {
			Debug.Log("KO");
		} else {
			Debug.Log("OK");
		}
		foreach (var sphere in sphereTransforms){
			double[] point = {sphere.position.x,sphere.position.z};
			double result = LibWrapper.classify_point(coeff,point, 2);
			//Debug.Log(result);
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
