using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] float alienSpeed = 1; 

    void Update()
    {
        transform.position += transform.forward * alienSpeed * Time.deltaTime; 
    }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false); 
    }
}
