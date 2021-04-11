using UnityEngine;
using System.Collections;

public class WheelController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isPlay = false;
    public static bool isStopWheel = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isPlay && rb.IsSleeping())
        {
            isStopWheel = true;
            isPlay = false;
        }
    }
    public void WheelRotete()
    {
        if (rb.IsSleeping())
        {
            rb.AddTorque(Random.Range(2000f, 5000f));
            //isPlay = true;
            StartCoroutine(IsPlay());
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
