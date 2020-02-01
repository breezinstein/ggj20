using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class SubLevelButton : MonoBehaviour
{
    public SubLevel levelInfo;
    private Button _button;
    public Image image;
    public Sprite completedButtonSprite;
    public Sprite incompleteButtonSprite;
    public TextMeshProUGUI levelIDText;
    // Start is called before the first frame update
    private void Start()
    {
        Init();
    }
    public void Init(UnityAction closeAction = null)
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            levelInfo.LoadLevel();
            UpdateUI();
        });
        UpdateUI();
    }


    void UpdateUI()
    {
        levelIDText.text = levelInfo.levelID.ToString();
        image.sprite = levelInfo.isSolved ? completedButtonSprite : incompleteButtonSprite;
    }
}

[System.Serializable]
public class SubLevel
{
    public bool isSolved;
    public int levelID;
    public void LoadLevel()
    {
        isSolved = true;
        //SceneManager.LoadScene(levelID);
    }
}
