using UnityEngine;
using System.Collections;
public class Path : MonoBehaviour {
	public bool bDebug = true;
	public float Radius = 2.0f;
	public Vector3[] pointA;

	//pointA[0] = new Vector3(0.0f,0.0f,0.0f);            
	//pointA[1] = new Vector3(0.1f,0.1f,0.1f);
	//pointA[2] = new Vector3(0.2f,0.3f,0.4f);
	//pointA[3] = new Vector3(0.5f,0.5f,0.5f);


	//Vector3[] pointA = new [] { new Vector3(0f,0f,0f), new Vector3(1f,1f,1f),
	//							new Vector3(2f,2f,2f), new Vector3(5f,7f,3f) };

	public float Length {
		get {
			return pointA.Length;
		}
	}
	public Vector3 GetPoint(int index) {
		return pointA[index];
	}
	void OnDrawGizmos() {
		if (!bDebug) return;
		for (int i = 0; i <pointA.Length; i++) {
			if (i + 1<pointA.Length) {
				Debug.DrawLine(pointA[i], pointA[i + 1],
				               Color.red);
			}
		}
	}
}