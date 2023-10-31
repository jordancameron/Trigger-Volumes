using UnityEngine;

public class AnimationButton : MonoBehaviour
{
    public Animator animator; // Assign the Animator component of the object with the animation.
    public string animationTrigger = "Activate"; // The trigger parameter name to activate the animation.

    private bool isPlayerOnButton = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnButton = true;
            PlayAnimation();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnButton = false;
            PlayAnimation();
        }
    }

    void PlayAnimation()
    {
        if (animator != null)
        {
            if (isPlayerOnButton)
            {
                animator.SetTrigger(animationTrigger);
            }
            else
            {
                animator.ResetTrigger(animationTrigger);
            }
        }
    }
}
