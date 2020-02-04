using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Neighbourhood : MonoBehaviour
{
    public SubLevel[] subLevels = new SubLevel[6];
    public SubLevelButton subLevelButtonPrefab;
    public GridLayoutGroup grid;
    public GameObject subLevelHolder;
    public int levelID;
    public bool isRestored { get { return PlayerPrefs.HasKey($"{levelID }"); } }
    //public bool isRestored { get { return subLevels.All(x => x.isSolved == true); } }
    public SpriteRenderer spriteRenderer;
    //public Clickable clickable;
    public Sprite destroyedSprite;
    public Sprite repairedSprite;

    

    // Start is called before the first frame update
    private void Start()
    {
   //     clickable.SetupListeners(() => { }, () => { }, () => ShowSublevels(true));
        UpdateSprite();
    }
    public void ShowSublevels(bool val)
    {
        if (val == true)
        {
            var buttons = subLevelHolder.gameObject.GetComponentsInChildren<SubLevelButton>();
            var closeButton = subLevelHolder.gameObject.GetComponentInChildren<ActionButton>();
            closeButton.OnClickAction(()=>ShowSublevels(false));
            for (int i = 0; i < subLevels.Length; i++)
            {
                buttons[i].levelInfo = subLevels[i];
                buttons[i].Init();
            }
        }
        else
        {
            UpdateSprite();
        }

        subLevelHolder.SetActive(val);

    }

    public void LoadLevel()
    {
        GameManager.level = levelID;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Recycube");
    }
    void UpdateSprite()
    {
        spriteRenderer.sprite = isRestored ? repairedSprite : destroyedSprite;
    }
}
