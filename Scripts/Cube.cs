using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Box))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    public float _liveTime;

    private WaitForSeconds _waitForSeconds;
    private bool _isCollision;

    public void SetCollisionValue()
    {
        _isCollision = false;
    }

    private void SetRandomLiveTime()
    {
        float maxTime = 6;
        float minTime = 2;

        _liveTime = Random.Range(minTime, maxTime);
    }

    private void SetRandomColor()
    {
        float maxValue = 1.0f;
        float randomValueR = Random.Range(0.0f, maxValue);
        float randomValueG = Random.Range(0.0f, maxValue);
        float randomValueB = Random.Range(0.0f, maxValue);

        GetComponent<Renderer>().material.color = new Color(randomValueR, randomValueB, randomValueG);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Platform>() != null)
        {
            if (_isCollision == false)
            {
                _isCollision = true;
                SetRandomColor();
            }

            SetRandomLiveTime();
            StartCoroutine(Coldown());
        }
    }

    private IEnumerator Coldown()
    {
        _waitForSeconds = new WaitForSeconds(_liveTime);

        yield return _waitForSeconds;

        gameObject.SetActive(false);
    }
}