using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{

	[SerializeField]
	private Camera cameraMove;

	public QuestGiverScript questGiver;

	[SerializeField]
	private LayerMask layerMask;

	[SerializeField]
	private GameObject questPanel;

	public bool CanRecevieQuest = false;

	private Transform _selection;



	// Start is called before the first frame update
	void Start()
	{
		questPanel.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		SelectNPC();
	}

	private void SelectNPC()
	{
		if(_selection != null)
		{
			
			CanRecevieQuest = false;
			_selection = null;
			questPanel.SetActive(false);
		}


		Ray ray = cameraMove.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 4f, Color.red);

		RaycastHit hitInfo;

		if (Physics.Raycast(ray, out hitInfo, 4f)) 
		{
			var selection = hitInfo.transform;

			if (selection.GetComponent<NPCScript>() != null)
			{
				CanRecevieQuest = true;
				questPanel.SetActive(true);
				if (Input.GetKeyDown(KeyCode.Mouse0) && CanRecevieQuest)
				{
					questPanel.SetActive(false);
					questGiver.OpenQuestWindow();
					Debug.Log("NPC możliwy do zagadania");
					
				}
				

			}
			_selection = selection;
		}

	}
}
