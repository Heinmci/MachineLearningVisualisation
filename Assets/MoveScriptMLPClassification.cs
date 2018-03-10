using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptMLPClassification : MonoBehaviour {

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
			points[i*3] = (trainningExample[i].position.y > 0)?1:-1;
			points[i*3+1] = trainningExample[i].position.x /10;
			points[i*3+2] = trainningExample[i].position.z /10;
		} 
		LibWrapper.mlp_train_classification(coeff,points,trainningExample.Length,trainningExample.Length *3,800000);
		/*if(ok == 0) {
			Debug.Log("KO");
		} else {
			Debug.Log("OK");
		}*/
		foreach (var sphere in sphereTransforms){
			double[] point = {sphere.position.x/10,sphere.position.z/10};
			double result = LibWrapper.mlp_classify(coeff,point,2);
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
