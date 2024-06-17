using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        if (instance == null) instance = this; else if (instance != null) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public TextMeshProUGUI restartButton;
    public TextMeshProUGUI exitButton;

    private TextMeshProUGUI timeText;
    private TextMeshProUGUI clearText;
    private TextMeshProUGUI gameOverText;








}
