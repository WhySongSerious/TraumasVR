using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class XRFootstepLoop : MonoBehaviour
{
    public float moveThreshold = 0.01f; 
    private AudioSource footstepAudio;
    private Vector3 lastPosition;

    void Start()
    {
        footstepAudio = GetComponent<AudioSource>();
        footstepAudio.loop = true;
        footstepAudio.playOnAwake = false;

        lastPosition = transform.position;
    }

    void Update()
    {
        float moveAmount = Vector3.Distance(transform.position, lastPosition);

        // 움직이고 있다면 발소리 재생
        if (moveAmount > moveThreshold)
        {
            if (!footstepAudio.isPlaying)
                footstepAudio.Play();
        }
        else
        {
            if (footstepAudio.isPlaying)
                footstepAudio.Pause(); 
        }

        lastPosition = transform.position;
    }
}
