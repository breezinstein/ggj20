using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    Collider2D MyCollider;
    void Awake()
    {
        MyCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.lifeControl.DecreaseProgressBar(2);
        MyCollider.enabled = false;
        StartCoroutine(PauseCollider());
    }

    IEnumerator PauseCollider()
    {
        yield return new WaitForSeconds(1);
        MyCollider.enabled = true;
    }
}
