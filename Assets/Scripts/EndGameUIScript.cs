using UnityEngine;

public class EndGameUIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject EndGamePanel;

    private void OnTriggerEnter(Collider other)
    {
        EndGamePanel.SetActive(true);
        LeanTween.scale(EndGamePanel, Vector3.zero, 0f);
        LeanTween.scale(EndGamePanel, Vector3.one, 2f).setEaseOutSine();
    }
}
