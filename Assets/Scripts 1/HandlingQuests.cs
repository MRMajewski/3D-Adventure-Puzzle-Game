using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandlingQuests : MonoBehaviour
{
	public Quest quest;

	public GameObject GUI;
	public GameObject timer;
	public GameObject itemToFind;

	private TextMeshProUGUI timerMesh;
	private TextMeshProUGUI itemToFindMesh;

	private void Start()
	{
		timerMesh = timer.GetComponent<TextMeshProUGUI>();
		itemToFindMesh = itemToFind.GetComponent<TextMeshProUGUI>();
	}


	private void Update()
	{
		if (quest.isActive)
		{
			StartQuest();
			TimerStart();
		}
	}

	void StartQuest()
	{
		itemToFindMesh.text = quest.itemToFound.ToString();
		GUI.SetActive(true);
	}

	void TimerStart ()
	{
		float currentTime = quest.duration;

		while (currentTime > 0)
		{
			currentTime -= 1 * Time.deltaTime;
			timerMesh.text = currentTime.ToString("0");
		}
		timerMesh.text = currentTime.ToString();

	}
}
