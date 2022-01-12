using UnityEngine;

public class ShowQuestLog : MonoBehaviour
{
    [SerializeField] private GameObject questLog;
    [SerializeField] private GameObject scroll;
    
    private void PauseGame() => Time.timeScale = 0;
    public void UnpauseGame() => Time.timeScale = 1;

    public void HandleClickOnIcon() => SetQuestLogUIVisible(true);

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Q)) return;
        SetQuestLogUIVisible(!scroll.activeInHierarchy);
    }

    private void SetQuestLogUIVisible(bool isVisible)
    {
        scroll.SetActive(isVisible);
        questLog.SetActive(isVisible);
        if (isVisible) PauseGame();
        else UnpauseGame();
    }
}
