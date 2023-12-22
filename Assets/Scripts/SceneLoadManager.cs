using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] float transitionTime = 1f;

    private Animator transitionAnimator;
    // Start is called before the first frame update
    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SceneLoad(string sceneName)
    {
        transitionAnimator.SetTrigger("StartTransition");

        yield return new WaitForSeconds(transitionTime);


    }
}
