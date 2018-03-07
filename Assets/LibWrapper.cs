﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class LibWrapper {
	
	[DllImport("unity_rust")]
	public static extern System.IntPtr linear_create();

	[DllImport("unity_rust")]
	public static extern void linear_train_classification(System.IntPtr coeff, double[] points,int lenght);

	[DllImport("unity_rust")]
	public static extern int classify_point(System.IntPtr coeff, double[] point);

	[DllImport("unity_rust")]
	public static extern double get_weight(System.IntPtr coeff, int weight);

	[DllImport("unity_rust")]
	public static extern void linear_train_regression(System.IntPtr coeff, double[] points, int lenght);

	[DllImport("unity_rust")]
	public static extern double regress_point(System.IntPtr coeff, double[] point);
	
}
