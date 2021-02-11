using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool IsPaused = false;

    public FirstPersonLook cameraMove;

    [SerializeField]
    private GameObject PausePanel;

    public Button throwingButton;

    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
        throwingButton.image.fillAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();         
        }
    }

    private void Pause()
    {
        if (!IsPaused)
        {
          //  Cursor.lockState = CursorLockMode.Locked;
            PausePanel.SetActive(true);
            IsPaused = true;
            Time.timeScale = 0;
            cameraMove.enabled = false;

        }
        else
        {
         //  Cursor.lockState = CursorLockMode.None;
            cameraMove.enabled = true;    
            IsPaused = false;
            Time.timeScale = 1;
            PausePanel.SetActive(false);
            Cursor.visible = false;
        }
    }

    public void ThrowingUI(float throwPower, float maxPower)
    {
        throwingButton.image.fillAmount= throwPower / maxPower;

    }


}
