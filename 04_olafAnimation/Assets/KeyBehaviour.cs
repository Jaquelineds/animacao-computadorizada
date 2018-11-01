using UnityEngine;

public class KeyBehaviour :  MonoBehaviour {

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
            changeAnimation();
        if (Input.GetKeyDown(KeyCode.R))
            restartAnimation();
        if (Input.GetKeyDown(KeyCode.B))
            backAnimation();
    }
    void changeAnimation() {
        if (index == anim.runtimeAnimatorController.animationClips.Length - 1)
            index = -1;
        else
            anim.Play(anim.runtimeAnimatorController.animationClips[++index].name);
        Debug.Log("Animação atual: " + anim.runtimeAnimatorController.animationClips[index].name);
    }

    void restartAnimation() {
        index = 0;
    }
    void backAnimation()
    {
        index--;
    }

}
