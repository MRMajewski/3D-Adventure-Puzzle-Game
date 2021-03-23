using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMainMenu : MonoBehaviour
{

    public GameObject button1;

    public GameObject button2;

    public GameObject titlePanel;

    public GameObject cameraObject;

    public Transform cameraEndPoint;

    public CanvasGroup mainPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnEnable()
    {
        titleEnterTween();
        buttonsEnterTween();
    }

    public void titleEnterTween()
    {
        LeanTween.moveLocalY(titlePanel, 450f, 2f).setEaseInCubic();
    }


    public void buttonsEnterTween()
    {
        LeanTween.moveLocalX(button1, 0F, 2f).setEaseInBack();
        LeanTween.sequence().
            append(.5f).
            append(LeanTween.moveLocalX(button2, 0f, 2f).setEaseInBack());        
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

       // LeanTween.move(cameraObject, cameraEndPoint.position, 2f).setEaseInCirc();

       // SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    IEnumerator StartGameCoroutine()
    {
        LeanTween.alphaCanvas(mainPanel, 0f, 1f);

        LeanTween.move(cameraObject, cameraEndPoint.position, 2f).setEaseInCirc();


        

        yield  return  new WaitForSeconds(2f);

        SceneManager.LoadScene(1);

    }
}
