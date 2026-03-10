using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseUnpause();
        }
    }

    public void MenuButton() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void PauseUnpause() {
        if (isPaused) {
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        } else {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
