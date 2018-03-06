using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class LibWrapper {
	[DllImport("unity_rust")]
	public static extern int random_classification(float y);

	[DllImport("unity_rust")]
	public static extern System.IntPtr linear_create();

	[DllImport("unity_rust")]
	public static extern void linear_train_classification(System.IntPtr coeff, double[] points);

	[DllImport("unity_rust")]
	public static extern int classify_point(System.IntPtr coeff, double[] point);
}
