using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class LibWrapper {
	
	[DllImport("unity_rust")]
	public static extern System.IntPtr linear_create(int nbinputs);

	[DllImport("unity_rust")]
	public static extern int linear_train_classification(System.IntPtr coeff, double[] inputs, int nbexample, int lenght);

	[DllImport("unity_rust")]
	public static extern double classify_point(System.IntPtr coeff, double[] inputs, int lenght);

	[DllImport("unity_rust")]
	public static extern double get_weight(System.IntPtr coeff, int weight);

	[DllImport("unity_rust")]
	public static extern void linear_train_regression(System.IntPtr coeff, double[] points, int nbExample, int lenght);

	[DllImport("unity_rust")]
	public static extern double regress_point(System.IntPtr coeff, double[] point, int lenght);

	[DllImport("unity_rust")]
	public static extern System.IntPtr create_MLP(int[] mlp, int lenght);

	[DllImport("unity_rust")]
	public static extern void mlp_train_classification(System.IntPtr coeff, double[] points,int lenght, int itr);

	[DllImport("unity_rust")]
	public static extern double mlp_classify(System.IntPtr coeff, double[] point);
	
	[DllImport("unity_rust")]
	public static extern void mlp_train_regression(System.IntPtr coeff, double[] points,int lenght, int itr);

	[DllImport("unity_rust")]
	public static extern double mlp_regress(System.IntPtr coeff, double[] point);
	
}
