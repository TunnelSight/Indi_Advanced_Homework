using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    public Button restartButton;
    public Button exitButton;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI clearText;
    public TextMeshProUGUI gameOverText;

    public float currentTime = 0;
    public bool isRunning = false;

    private void Awake()
    {
        if (instance == null) instance = this; else if (instance != null) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        HideUI();

        restartButton.onClick.AddListener(GameManager.instance.Restart);
        exitButton.onClick.AddListener(GameManager.instance.Exit);
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            UpdateTimeText();
        }
    }

    public void HideUI()
    {
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        clearText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }

    public void ShowUI()
    {
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void ShowClearText()
    {
        clearText.gameObject.SetActive(true);
    }

    public void ShowGameOverText()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        isRunning = false;
        currentTime = 0;
        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        timeText.text = "Time: " + currentTime.ToString("F2") + "s";
    }


}
