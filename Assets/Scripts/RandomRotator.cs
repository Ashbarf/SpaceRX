using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed = 15f;

    void Start()
    {
        
    }

    private void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, turnSpeed * Time.deltaTime);
    }
}