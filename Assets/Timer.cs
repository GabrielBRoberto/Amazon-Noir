using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public Slider slider;
    [SerializeField]
    public Image fill;

    public int maxTimer;
    public float currentTimer;

    public Animator animator;

    private void Start()
    {
        currentTimer = maxTimer;
        SetMaxValueTimer(maxTimer);
    }

    private void Update()
    {
        if(currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }

        SetTimer(currentTimer);

        if(currentTimer < 0)
        {
            animator.SetBool("TimeEnded", true);
        }
    }

    public void SetMaxValueTimer(int timer)
    {
        slider.maxValue = timer;
        slider.value = timer;
    }

    public void SetTimer(float timer)
    {
        slider.value = timer;
    }
}
