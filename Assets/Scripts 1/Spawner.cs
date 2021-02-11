using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject[] items;

    private Vector3 respawnLocation;


	void Awake()
	{
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
	}

	// Start is called before the first frame update
	void Start()
    {
        items = Resources.LoadAll<GameObject>("Items");
        
        if(items.Length <= spawnLocations.Length)
		{
            SpawnItems();
		}
		else
		{
            Debug.Log("Za duzo itemów za mało spawnów");
		}

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItems()
	{
        List<int> listOfRandSpawns = new List<int>();
        int spawn;
        for(int i=0; i < items.Length; i++)
		{
            do
            {
                spawn = Random.Range(0, spawnLocations.Length);

            } while (listOfRandSpawns.Contains(spawn));
            listOfRandSpawns.Add(spawn);
        }

        int x = 0;
        foreach (GameObject item in items)
        {
            
            GameObject.Instantiate(item, spawnLocations[listOfRandSpawns[x]].transform.position, Quaternion.identity);
            x++;
        }

    }
}
