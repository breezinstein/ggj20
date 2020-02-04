using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }

    public LifeControl lifeControl;
    public int Score = 0;
    public float duration = 60f;
    private float timeLeft = 0f;

    [Header("UI")]
    public Slider progressSlider;
    public Text ScoreLabel;
    [Space]
    public GameObject gameoverScreen;
    public Button restartButtonG;
    public Button quitButtonG;
    [Space]
    public GameObject victoryScreen;
    public Button restartButtonV;
    public Button quitButtonV;
    [Space]
    public Button pauseButton;
    public GameObject pauseScreen;
    public Button resumeButtonP;
    public Button restartButtonP;
    public Button quitButtonP;
    bool isPaused = false;
    
    public TextMeshProUGUI timeText;
    bool lose = false;
    bool won = false;

    public static int level;

    [Header("LevelManagers")]
    public TrashSpawner trashSpawner;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
        lifeControl.SetProgressMax(50 * level);

        UnityAction restartAction = new UnityAction(() => { Time.timeScale = 1f; SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
        UnityAction quitAction = new UnityAction(() => { SceneManager.LoadScene("Level Select"); });

        quitButtonV.onClick.AddListener(quitAction);
        quitButtonG.onClick.AddListener(quitAction);

        restartButtonG.onClick.AddListener(restartAction);
        restartButtonV.onClick.AddListener(restartAction);

        pauseButton.onClick.AddListener(Pause);
        resumeButtonP.onClick.AddListener(UnPause);
        restartButtonP.onClick.AddListener(restartAction);
        quitButtonP.onClick.AddListener(quitAction);

        timeLeft = duration;

        UpdateUI();
        if (trashSpawner == null)
        {
            Debug.Log("No Trash Spawner");
        }
        trashSpawner.StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lose)
        {
            if (timeLeft > 0 && !won)
            {
                timeLeft -= Time.deltaTime;
                UpdateUI();
            }
            if (lifeControl.Life <= 0 || timeLeft < 0)
            {
                Lose();
            }
        }
        if (lifeControl.progressBarValue >= lifeControl.progressBarValueMax && !won)
        {
            Win();
        }
    }

    public void UpdateUI()
    {
        ScoreLabel.text = $"Score: {Score}";
        progressSlider.value = lifeControl.progessPrecentage;
        timeText.text = $"{(int)timeLeft}";
    }

    public void IncreaseScore(int Amount)
    {
        Score += Amount;
        UpdateUI();
    }

    public void Lose()
    {
        Debug.Log("You don die be that!");
        lose = true;
        gameoverScreen.SetActive(true);
        trashSpawner.StopSpawning();
    }

    public void Win()
    {
        won = true;
        Debug.Log("Win");
        victoryScreen.SetActive(true);
        trashSpawner.StopSpawning();
        PlayerPrefs.SetString($"{level}", "passed");
        PlayerPrefs.Save();
    }

    void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseScreen.SetActive(true);
    }

    void UnPause()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseScreen.SetActive(false);
    }
}
