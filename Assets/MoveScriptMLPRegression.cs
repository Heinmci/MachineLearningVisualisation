using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptMLPRegression : MonoBehaviour {

	[SerializeField]
	private Transform[] sphereTransforms;
	[SerializeField]
	private Transform[] trainningExample;
	// Use this for initialization
	void Start () {
		int[] size = {2,10,10,1};
		System.IntPtr coeff = LibWrapper.create_MLP(size,4);
	
		double[] points = new double[trainningExample.Length *3];
		for(int i =0; i<trainningExample.Length;i++) {
			points[i*3] = trainningExample[i].position.y /10;
			points[i*3+1] = trainningExample[i].position.x /10;
			points[i*3+2] = trainningExample[i].position.z/10;
		} 
		LibWrapper.mlp_train_regression(coeff,points,trainningExample.Length, trainningExample.Length *3,800000);
		/*if(ok == 0) {
			Debug.Log("KO");
		} else {
			Debug.Log("OK");
		}*/
		foreach (var sphere in sphereTransforms){
			double[] point = {sphere.position.x/10,sphere.position.z/10};
			float result = (float)LibWrapper.mlp_regress(coeff,point,2);
			sphere.position += Vector3.up * result*10;
			
		} 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
