using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene2 : MonoBehaviour
{
    [SerializeField] string scene;

    [SerializeField] float transitionTime = 1f;

    private Animator transitionAnimator;

    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();

        PlayerController pl = FindObjectOfType<PlayerController>();

        if (SceneManager.GetActiveScene().name == "MinijuegoMapa" || SceneManager.GetActiveScene().name == "Minijuego2")
            pl.gameObject.SetActive(false);
        else pl.gameObject.SetActive(true);
        try
        {
            pl.ResetPos();
        }
        catch { }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float interaction = Input.GetAxis("Interaction");

        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(SceneLoad());
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