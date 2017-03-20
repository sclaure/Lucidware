using UnityEngine;
using System.Collections;

public class TunnelGen : MonoBehaviour {

	public int numRow = 25;
	public int heightTunnel = 25;
	public float disFromView = 7;
	public float timeScale = 4f;
	public float removalThreshold = 0.1f;
	public float pokeFrequency = 0.5f;

	private GameObject[,] cubes;
	UnityEngine.Random rand = new UnityEngine.Random();


	private ArrayList currentCubes = new ArrayList();
	private int counter = 0;

	// Use this for initialization
	void Start () {
		cubes = new GameObject[(int)numRow,(int)heightTunnel];
		int halfHeight = heightTunnel/2;
		int halfRow = numRow/2;
		float incrementAngle = 90.0f/halfRow;
		float angle = -90.0f; 

		for(int h = 0; h < heightTunnel; h++)
		{
			angle = -90.0f; 
			for(int i = 0; i < numRow; i++)
			{
				cubes[i,h] = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cubes[i,h].transform.parent = transform;
				//cube.transform.localPosition = new Vector3(i, h, 20);
				cubes[i,h].transform.localPosition = 
					new Vector3(disFromView * Mathf.Sin(Mathf.Deg2Rad * angle), 
					            (h - halfHeight), 
					            disFromView * Mathf.Cos(Mathf.Deg2Rad * angle));
				//cube.transform.localPosition = new Vector3(i*20*Mathf.Cos(angle), h, 20*Mathf.Cos(angle));
				cubes[i,h].transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,1,0));
				//cube.transform.localScale = new Vector3(2,2,2);

				CubeProperties prop = cubes[i,h].AddComponent<CubeProperties>();
				prop.SetXY(i,h);

				float c = h + i;
				angle += incrementAngle;
				//Debug.Log(angle);
				//cubes[i,h].GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
			}
		}

		InvokeRepeating("PokeRandomCube", 0f, pokeFrequency);
	}
	
	// Update is called once per frame
	void Update () {

//		counter++;
//		if(counter != 60)
//			return;
//		counter = 0;

		ArrayList tempAddCubes = new ArrayList();
		ArrayList tempRemoveCubes = new ArrayList();
		foreach(CubeLocation prop in currentCubes)
		{
			Renderer cubeRenderer = cubes[prop.x, prop.y].GetComponent<Renderer>();
			Color cubeColor = cubeRenderer.material.color;
			Color newColor = Color.Lerp(cubeColor,Color.white,Time.deltaTime * timeScale);
			Vector3 test1 = new Vector3(newColor.r, newColor.g, newColor.b);
			Vector3 test2 = new Vector3(Color.white.r, Color.white.b, Color.white.g);

			if((test2 - test1).magnitude < removalThreshold) 
			{
				cubeRenderer.material.color = Color.white;
				tempRemoveCubes.Add(prop);
			}
			else
			{
				cubeRenderer.material.color = newColor;
			}

			if(prop.y <= 0)
				continue;

			Renderer nextCubeRenderer = cubes[prop.x, prop.y-1].GetComponent<Renderer>();
			if(nextCubeRenderer.material.color == Color.white)
			{
				nextCubeRenderer.material.color = cubeColor;
				tempAddCubes.Add(new CubeLocation(prop.x, prop.y-1));
			}
		}
		foreach(CubeLocation prop in tempRemoveCubes)
			currentCubes.Remove(prop);
		currentCubes.AddRange(tempAddCubes);
	}

	void PokeRandomCube()
	{
		//Debug.Log("Poking Cube");
		int h = UnityEngine.Random.Range(0, heightTunnel);
		int i = UnityEngine.Random.Range(0, numRow);

		DripCube(i, h, new Color(Random.value, Random.value, Random.value));
	}

	void DripCube(int x, int y, Color color)
	{
		cubes[x,y].GetComponent<Renderer>().material.color = color;
		currentCubes.Add(new CubeLocation(x,y));
	}
}
