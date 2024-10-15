using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private GameObject exitButton;

    [SerializeField]
    private GameObject titlePanel;

    [SerializeField]
    private GameObject cameraObject;

    [SerializeField]
    private Transform cameraEndPoint;

    [SerializeField]
    private CanvasGroup mainPanel;

    [SerializeField]
    private AudioManager audio;

 
    private void OnEnable()
    {
        TitleEnterTween();
        ButtonsEnterTween();
    }

    public void TitleEnterTween()
    {
        LeanTween.moveLocalY(titlePanel, 450f, 2f).setEaseInCubic();
    }

    public void ButtonsEnterTween()
    {
        LeanTween.moveLocalX(startButton, 0F, 2f).setEaseInBack();
        LeanTween.sequence().
            append(.5f).
            append(LeanTween.moveLocalX(exitButton, 0f, 2f).setEaseInBack());        
    }

    public  void OnPointerEnter(GameObject obj)
    {
        LeanTween.scale(obj, new Vector3(1.2f, 1.2f), .5f);
    }

    public void OnPointerExit(GameObject obj)
    {
        LeanTween.scale(obj, new Vector3(1f, 1f), .5f);
    }

    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator StartGameCoroutine()
    {
        audio.Play("Start");
        LeanTween.alphaCanvas(mainPanel, 0f, 1f);

        LeanTween.move(cameraObject, cameraEndPoint.position, 2f).setEaseInCirc();
      
        yield  return  new WaitForSeconds(2f);

        SceneManager.LoadScene(1);
    }
}
