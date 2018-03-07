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
		System.IntPtr coeff = LibWrapper.linear_create();
	
		double[] points = new double[trainningExample.Length *3];
		for(int i =0; i<trainningExample.Length;i++) {
			points[i*3] = trainningExample[i].position.x;
			points[i*3+1] = trainningExample[i].position.z;
			points[i*3+2] = (trainningExample[i].position.y > 0)?1:-1;
		} 
		Debug.Log(points[0]);
		Debug.Log(points[1]);
		Debug.Log(points[2]);
		Debug.Log(points[3]);
		Debug.Log(points[4]);
		//double[] points= {trainningExample[0].position.x,trainningExample[0].position.z,(trainningExample[0].position.y > 0)?1:-1,trainningExample[1].position.x,trainningExample[1].position.z,(trainningExample[1].position.y > 0)?1:-1,trainningExample[2].position.x,trainningExample[2].position.z,(trainningExample[2].position.y > 0)?1:-1,trainningExample[3].position.x,trainningExample[3].position.z,(trainningExample[3].position.y > 0)?1:-1};
		
		LibWrapper.linear_train_classification(coeff,points,12);
		
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
