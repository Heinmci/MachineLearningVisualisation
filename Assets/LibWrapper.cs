using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class LibWrapper {
	[DllImport("unity_rust")]
	public static extern int random_classification(float y);
}
