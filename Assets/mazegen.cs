using UnityEngine;
using System.Collections;

public class mazegen : MonoBehaviour {

	//declaracion de variables
	public int  sizer = 10;
	public int iteration = 10;
	
	public void paint(int[,] arreglo, int sizer)
	{
		for (int i = 0; i < sizer + 2; i++)
		{
			for (int j = 0; j < sizer + 2; j++)
			{
			}
		}
	}// Use this for initialization


	public void generatewall(int[,] arreglo, int sizer)
	{
		Random p = new Random();
		int line = Random.Range (1, sizer+1);  
		int ini =  Random.Range (1, sizer);//int ini =  Random.Range (1, sizer+1);
		int door = Random.Range (1,ini);
		int hv =   Random.Range (1,3);
		
		for (int i = ini; i < sizer + 1; i++)
		{
			if (hv == 1)
			{
				if (arreglo[i, line] == 0) { i = 10000000; }
				else{
				arreglo[i, line] = 0;
				}
				Debug.Log ("lelelel");
			}
			else
			{
				if (arreglo[line, i] == 0) { i = 10000000; }
				else{
				arreglo[line, i] = 0;
				}
			}
		}
		if (hv == 1)
			arreglo[door, line] = 1;
		else
			arreglo[line, door] = 1;
		
	}

	public void relog(){
		//Debug.Log ("lelelel");

		int[,] arreglo = new int[sizer + 2, sizer + 2];
		for (int i = 1; i < sizer + 1; i++)
		{
			for (int j = 1; j < sizer + 1; j++)
			{
				arreglo[i, j] = 1;
			}
		}
		//paint(arreglo, sizer);
		
		for (int i = 0; i < iteration; i++)
		{
			//paint(arreglo, sizer);
			generatewall(arreglo, sizer);
		}
		GameObject prefab = Resources.Load ("wall") as GameObject;
		GameObject instance;
		for (int i = 0; i < sizer + 2; i++)
		{
			for (int j = 0; j < sizer + 2; j++)
			{
				if(arreglo[i, j] == 0)
					instance = Instantiate(prefab, new Vector3(i ,j, 0), new Quaternion()) as GameObject;
			}
		}
	}

	void Start () {
		relog ();
						
	}

	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Space)){
			GameObject[] gameObjects =  GameObject.FindGameObjectsWithTag ("wall");
			
			foreach(GameObject p in gameObjects){
				Destroy(p);
			}
			relog();
		}
	}
}
