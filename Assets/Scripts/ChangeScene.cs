using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	[SerializeField] string scene;

    [SerializeField] float transitionTime = 1f;

    private Animator transitionAnimator;

    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
        try
        {
            PlayerController pl = FindObjectOfType<PlayerController>();
            pl.ResetPos();
        }
        catch { }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");

        if (collision.gameObject.CompareTag("Player")){
            if (interaction != 0)
            {
                if (gameObject.activeInHierarchy)
                {
                    StartCoroutine(SceneLoad());
                }
            }
        }
    }

    public IEnumerator SceneLoad()
    {
        transitionAnimator.SetTrigger("StartTransition");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }

}