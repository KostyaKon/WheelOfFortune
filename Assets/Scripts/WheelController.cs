using UnityEngine;
using System.Collections;

public class WheelController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isPlay = false;
    private AudioSource wheelTurn;

    public static bool isStopWheel = false;
    public AudioSource audioScen;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wheelTurn = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isPlay && rb.IsSleeping())
        {
            isStopWheel = true;
            isPlay = false;
        }
        if (rb.IsSleeping() && wheelTurn.isPlaying)
        {
            wheelTurn.Stop();
            audioScen.volume = 0.7f;
        }
    }
    public void WheelRotete()
    {
        if (rb.IsSleeping())
        {
            rb.AddTorque(Random.Range(2000f, 5000f));
            StartCoroutine(IsPlay());
            if (!wheelTurn.isPlaying)
            {
                wheelTurn.Play();
                audioScen.volume = 0.2f;      
            }
        }
    }

    IEnumerator IsPlay()
    {
        yield return new WaitForSeconds(0.3f);
        isPlay = true;
    }

    public bool IsWheelPlay()
    {
        return isPlay;
    }
}
