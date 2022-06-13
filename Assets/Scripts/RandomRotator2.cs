using UnityEngine;
using System.Collections;

public class RandomRotator2 : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed = 15f;

    void Start()
    {
        
    }

    private void Update()
    {
        transform.Rotate(turnSpeed * Time.deltaTime, turnSpeed * Time.deltaTime, 0);
    }
}