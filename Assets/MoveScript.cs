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
		Debug.Log("azeaz");
		System.IntPtr coeff = LibWrapper.linear_create();
		double[] points = {trainningExample[0].position.x,trainningExample[0].position.z,-1,trainningExample[1].position.x,trainningExample[1].position.z,-1,trainningExample[2].position.x,trainningExample[2].position.z,1};
		Debug.Log(points[0]);
		Debug.Log(points[1]);
		Debug.Log(points[2]);
		Debug.Log(points[3]);
		Debug.Log(points[4]);
		Debug.Log(points[5]);
		Debug.Log(points[6]);
		Debug.Log(points[7]);
		Debug.Log(points[8]);
		LibWrapper.linear_train_classification(coeff,points);
		Debug.Log(LibWrapper.get_weight(coeff, 0));
		Debug.Log(LibWrapper.get_weight(coeff, 1));
		Debug.Log(LibWrapper.get_weight(coeff, 2));

		double[] point1 = {trainningExample[0].position.x,trainningExample[0].position.z};
		Debug.Log(LibWrapper.classify_point(coeff, point1));
		double[] point2 = {trainningExample[1].position.x,trainningExample[1].position.z};
		Debug.Log(LibWrapper.classify_point(coeff, point2));
		double[] point3 = {trainningExample[2].position.x,trainningExample[2].position.z};
		Debug.Log(LibWrapper.classify_point(coeff, point3));

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
