﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool IsPaused = false;

    public FirstPersonLook cameraMove;

    [SerializeField]
    private GameObject PausePanel;

    [SerializeField]
    private GameObject HUDPanel;

    [SerializeField]
    private GameObject GUIPanel;

    [SerializeField]
    private CanvasGroup BlackPanel;


    public Button throwingButton;

    public Button jumpingButton;

    [SerializeField]
    private GameObject OnRoomEnterPanel;

    [SerializeField]
    private TextMeshProUGUI OnRoomEnterText;



    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
        HUDPanel.SetActive(true);
        throwingButton.image.fillAmount = 0;
        StartCoroutine(FadeCoroutine(3f));

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

    public void JumpingUI(float jumpPower, float jumpMaxPower)
    {
        jumpingButton.image.fillAmount = jumpPower / jumpMaxPower;

    }


    public void RoomEnterUIAnimation(string text)
    {
        var sizeY = GUIPanel.GetComponentInChildren<RectTransform>().rect.height;
        Debug.Log(sizeY);

        OnRoomEnterText.text = text;
        LeanTween.sequence()
        //  .append(LeanTween.moveLocalY(OnRoomEnterPanel, 295f, 1f).setEaseOutCirc())
        .append(LeanTween.moveLocalY(OnRoomEnterPanel, sizeY * 0.45f, 1f).setEaseOutCirc())


        .append(1f)
       .append(LeanTween.moveLocalY(OnRoomEnterPanel, sizeY * .6f, 1f).setEaseOutCirc());
        // .append(LeanTween.moveLocalY(OnRoomEnterPanel, 345, 1f).setEaseOutCirc());
        Debug.Log(sizeY * 0.1f);
    }

    public void RespawnAnim()
    {
        StartCoroutine(FadeCoroutine());
    }


    public void EndGameAnim()
    {
        StartCoroutine(FadeCoroutineEndGame(0.5f));
    }


    IEnumerator FadeCoroutine()
    {
        BlackPanel.alpha = 1f;
     
        float progress = 0f;

        while(progress<1.0f)
        {
            BlackPanel.alpha = Mathf.Lerp(1, 0, progress);
            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime;
        }
        
    }


    IEnumerator FadeCoroutine(float time)
    {
        BlackPanel.alpha = 1f;

       float progress = 0f;

        while (progress < time)
        {
            BlackPanel.alpha = Mathf.Lerp(1, 0, progress);
            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime;
        }

    }


    IEnumerator FadeCoroutineEndGame(float time)
    {
        BlackPanel.alpha = 0f;

        float progress = 0f;

        while (progress < time)
        {
            BlackPanel.alpha = Mathf.Lerp(0, 1, progress);
            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime;
        }

    }



}
