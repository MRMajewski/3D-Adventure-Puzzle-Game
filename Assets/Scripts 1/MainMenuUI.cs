using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    GameObject title;

    [SerializeField]
    GameObject title2;

    [SerializeField]
    GameObject btnPanel;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(title, Vector3.zero, 0f);
        LeanTween.scale(title, Vector3.one, 2f).setEaseInBounce();

        LeanTween.rotateZ(title2, 720, .5f).setLoopPingPong(3);

        LeanTween.sequence()
             .append(LeanTween.scale(title, Vector3.zero, 0f).setEaseOutCirc())
            .append(LeanTween.scale(title2, Vector3.zero, 0f).setEaseOutCirc())
            .append(LeanTween.scale(title, Vector3.one, 1f).setEaseOutCirc())
            .append(1f)  
            .append(LeanTween.scale(title2, Vector3.one, 1f).setEaseOutCirc())
            
            .append(0.5f)
            .append(LeanTween.scale(btnPanel, new Vector3(0.5f,0.5f,0.5f), 1f).setLoopPingPong().setEaseInBack());

        
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


}
