using System.Collections;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour {

    public Animator anim;
    int index = -1;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeAnimation();
        if (Input.GetKeyDown(KeyCode.R))
            RestartAnimation();
        if (Input.GetKeyDown(KeyCode.B))
            BackAnimation();
        if (Input.GetKeyDown(KeyCode.L))
            AllAnimations();
    }
    void ChangeAnimation() {
        if (index == anim.runtimeAnimatorController.animationClips.Length - 1)
            RestartAnimation();
        else
            anim.Play(anim.runtimeAnimatorController.animationClips[++index].name);
        Debug.Log("Animação atual: " + anim.runtimeAnimatorController.animationClips[index].name);
    }

    void AllAnimations() {
        while (index < anim.runtimeAnimatorController.animationClips.Length - 1) {
            anim.Play(anim.runtimeAnimatorController.animationClips[++index].name);
            Debug.Log("Animação atual: " + anim.runtimeAnimatorController.animationClips[index - 1].averageDuration);
            WaitForAnimation(anim.runtimeAnimatorController.animationClips[++index].averageDuration);
        }
    }

    void RestartAnimation() {
        index = -1;
    }
    void BackAnimation()
    {
        index--;
    }
    private IEnumerator WaitForAnimation(float time)
    {
        yield return new WaitForSeconds(time);

    }
}
