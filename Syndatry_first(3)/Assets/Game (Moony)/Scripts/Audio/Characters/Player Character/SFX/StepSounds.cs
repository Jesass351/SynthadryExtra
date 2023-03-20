using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class StepSounds : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] stepSounds;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayStepSound()
    {
        audioSource.PlayOneShot(stepSounds[Random.Range(0, stepSounds.Length)]);
    }
}
