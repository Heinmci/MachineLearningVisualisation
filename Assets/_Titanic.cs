using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class _Titanic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	

		//System.IntPtr coeff = trainWithMLPClassification();
		//guessWithMLPClassification(coeff);

		System.IntPtr coeffLinear = trainWithLinearClassification();
		guessWithLinearClassification(coeffLinear);

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private System.IntPtr trainWithMLPClassification() {
	var list = new List<double>();

	var maxage = 90.0;
	var maxprix = 93.5;

	using (var rd = new StreamReader("titanic_train_data.csv"))
	{
		while (!rd.EndOfStream)
		{
			var splits = rd.ReadLine().Split(',');
			var vivant = double.Parse(splits[0],System.Globalization.CultureInfo.InvariantCulture);
			var classe = double.Parse(splits[1],System.Globalization.CultureInfo.InvariantCulture);
			var sex = splits[2];
			var age = double.Parse(splits[3],System.Globalization.CultureInfo.InvariantCulture)/maxage;
			var prix = double.Parse(splits[4],System.Globalization.CultureInfo.InvariantCulture)/maxprix;
			list.Add(vivant ==0?-1:1);
			switch ((int)classe)
			{
				case 1:
					list.Add(1);
					list.Add(0);
					list.Add(0);
					break;
				case 2:
					list.Add(0);
					list.Add(1);
					list.Add(0);
					break;
				case 3:
					list.Add(0);
					list.Add(0);
					list.Add(1);
					break;
			}
			if(sex.Equals("male")){
				list.Add(1);
				list.Add(0);
			} else {
				list.Add(0);
				list.Add(1);
			}

			list.Add(age);
			list.Add(prix);
		}
		double[] inputs = list.ToArray();

        int[] size = {8,50,50,1};
		System.IntPtr coeff = LibWrapper.create_MLP(size,4);

		LibWrapper.mlp_train_classification(coeff,inputs, inputs.Length/8, inputs.Length,800000);
		
		return coeff;
	}   
}

private void guessWithMLPClassification(System.IntPtr coeff) {
	int nbErrors =0;
	int nbGood =0;

	var maxage = 90.0;
	var maxprix = 93.5;

	using (var rd = new StreamReader("titanic_test_data.csv"))
	{
		while (!rd.EndOfStream)
		{
			var list = new List<double>();
			var splits = rd.ReadLine().Split(';');
			var vivant = double.Parse(splits[0],System.Globalization.CultureInfo.InvariantCulture);
			var classe = double.Parse(splits[1],System.Globalization.CultureInfo.InvariantCulture);
			var sex = splits[2];
			var age = double.Parse(splits[3],System.Globalization.CultureInfo.InvariantCulture)/maxage;
			var prix = double.Parse(splits[4],System.Globalization.CultureInfo.InvariantCulture)/maxprix;
			switch ((int)classe)
			{
				case 1:
					list.Add(1);
					list.Add(0);
					list.Add(0);
					break;
				case 2:
					list.Add(0);
					list.Add(1);
					list.Add(0);
					break;
				case 3:
					list.Add(0);
					list.Add(0);
					list.Add(1);
					break;
			}
			if(sex.Equals("male")){
				list.Add(1);
				list.Add(0);
			} else {
				list.Add(0);
				list.Add(1);
			}

			list.Add(age);
			list.Add(prix);
			double[] inputs = list.ToArray();
			double result = LibWrapper.mlp_classify(coeff,inputs,7);
			vivant = (vivant==0)?-1:1;
			result = (result<0)?-1:1;
			if(result == vivant){
				nbGood++;
			} else {
				nbErrors++;
			}
		}
		double success = ((double)nbGood/(nbGood+nbErrors))*100;
		Debug.Log("bien trouvé : "+nbGood);
		Debug.Log("Erreur : "+nbErrors);
		Debug.Log("% réussite : "+ success+"%");

	}

}

private System.IntPtr trainWithLinearClassification() {
	var list = new List<double>();

	var maxage = 90.0;
	var maxprix = 93.5;

	using (var rd = new StreamReader("titanic_train_data.csv"))
	{
		while (!rd.EndOfStream)
		{
			var splits = rd.ReadLine().Split(',');
			var vivant = double.Parse(splits[0],System.Globalization.CultureInfo.InvariantCulture);
			var classe = double.Parse(splits[1],System.Globalization.CultureInfo.InvariantCulture);
			var sex = splits[2];
			var age = double.Parse(splits[3],System.Globalization.CultureInfo.InvariantCulture)/maxage;
			var prix = double.Parse(splits[4],System.Globalization.CultureInfo.InvariantCulture)/maxprix;
			list.Add(vivant ==0?-1:1);
			switch ((int)classe)
			{
				case 1:
					list.Add(1);
					list.Add(0);
					list.Add(0);
					break;
				case 2:
					list.Add(0);
					list.Add(1);
					list.Add(0);
					break;
				case 3:
					list.Add(0);
					list.Add(0);
					list.Add(1);
					break;
			}
			if(sex.Equals("male")){
				list.Add(1);
				list.Add(0);
			} else {
				list.Add(0);
				list.Add(1);
			}

			list.Add(age);
			list.Add(prix);
		}
		double[] inputs = list.ToArray();

        int[] size = {8,50,50,1};
		System.IntPtr coeff = LibWrapper.linear_create(8);

		LibWrapper.linear_train_classification(coeff,inputs, inputs.Length/8, inputs.Length);
		
		return coeff;
	}   
}

private void guessWithLinearClassification(System.IntPtr coeff) {
	int nbErrors =0;
	int nbGood =0;

	var maxage = 90.0;
	var maxprix = 93.5;

	using (var rd = new StreamReader("titanic_test_data.csv"))
	{
		while (!rd.EndOfStream)
		{
			var list = new List<double>();
			var splits = rd.ReadLine().Split(';');
			var vivant = double.Parse(splits[0],System.Globalization.CultureInfo.InvariantCulture);
			var classe = double.Parse(splits[1],System.Globalization.CultureInfo.InvariantCulture);
			var sex = splits[2];
			var age = double.Parse(splits[3],System.Globalization.CultureInfo.InvariantCulture)/maxage;
			var prix = double.Parse(splits[4],System.Globalization.CultureInfo.InvariantCulture)/maxprix;
			switch ((int)classe)
			{
				case 1:
					list.Add(1);
					list.Add(0);
					list.Add(0);
					break;
				case 2:
					list.Add(0);
					list.Add(1);
					list.Add(0);
					break;
				case 3:
					list.Add(0);
					list.Add(0);
					list.Add(1);
					break;
			}
			if(sex.Equals("male")){
				list.Add(1);
				list.Add(0);
			} else {
				list.Add(0);
				list.Add(1);
			}

			list.Add(age);
			list.Add(prix);
			double[] inputs = list.ToArray();
			double result = LibWrapper.classify_point(coeff,inputs,7);
			vivant = (vivant==0)?-1:1;
			result = (result<0)?-1:1;
			if(result == vivant){
				nbGood++;
			} else {
				nbErrors++;
			}
		}
		double success = ((double)nbGood/(nbGood+nbErrors))*100;
		Debug.Log("bien trouvé : "+nbGood);
		Debug.Log("Erreur : "+nbErrors);
		Debug.Log("% réussite : "+ success+"%");

	}

}
}
