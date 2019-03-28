using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door


	private RoomTemplates templates;
	private int rand;
	private bool spawned = false;

	void Start()
	{
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.1f);
	}

	void Spawn(){
		if(spawned == false)
		{
			if (openingDirection == 1){
				// Need to spawn a room With BOTTOM door.
				rand = Random.Range(0, templates.BottomRooms.Length);
				Instantiate(templates.BottomRooms[rand], transform.position, templates.BottomRooms[rand].transform.rotation);
			}
			else if (openingDirection == 2){
				// Need to spawn a room With TOP door.
				rand = Random.Range(0, templates.TopRooms.Length);
				Instantiate(templates.TopRooms[rand], transform.position, templates.TopRooms[rand].transform.rotation);
			}
			else if (openingDirection == 3){
				// Need to spawn a room With LEFT door.
				rand = Random.Range(0, templates.LeftRooms.Length);
				Instantiate(templates.LeftRooms[rand], transform.position, templates.LeftRooms[rand].transform.rotation);
			}
			else if (openingDirection == 4){
				// Need to spawn a room With RIGHT door.
				rand = Random.Range(0, templates.RightRooms.Length);
				Instantiate(templates.RightRooms[rand], transform.position, templates.RightRooms[rand].transform.rotation);
			}
			spawned = true;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Spawn Point") && other.GetComponent<RoomSpawner>().spawned == true)
		{
			Destroy(gameObject);
		}
	}
}
