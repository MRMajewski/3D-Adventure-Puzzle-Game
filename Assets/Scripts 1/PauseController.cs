using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public bool IsPaused = false;

    public FirstPersonLook cameraMove;

    [SerializeField]
    private GameObject PausePanel;

    public GameObject player;

    private NPCInteraction npcInteraction;
    private ItemInteraction ItemInteraction;

    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
        npcInteraction = player.GetComponent<NPCInteraction>();
        ItemInteraction = player.GetComponent<ItemInteraction>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        if (!IsPaused)
        {
        //    npcInteraction.enabled = false;
         //   ItemInteraction.enabled = false;

            Cursor.lockState = CursorLockMode.Locked;
            PausePanel.SetActive(true);
            IsPaused = true;
            Time.timeScale = 0;
            cameraMove.enabled = false;

        }
        else
        {
        //    npcInteraction.enabled = true;
        //    ItemInteraction.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            cameraMove.enabled = true;
            IsPaused = false;
            Time.timeScale = 1;
            PausePanel.SetActive(false);
            Cursor.visible = false;
        }
    }


}
