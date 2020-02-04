using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleBin : MonoBehaviour
{
    public TrashType type;
    public int ScoreValue = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Trash>().type == type)
        {
            GameManager.Instance.IncreaseScore(ScoreValue);
            GameManager.Instance.lifeControl.progressBarValue += 5;
        }
        else if (collision.gameObject.GetComponent<Trash>().type != type)
        {
            GameManager.Instance.lifeControl.DecreaseLife();
        }
        GameManager.Instance.UpdateUI();
        Destroy(collision.gameObject);
    }
}
public enum TrashType { PAPER, METAL, PLASTIC }