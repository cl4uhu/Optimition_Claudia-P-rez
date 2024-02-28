using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] float mineSpeed = 8; 

    void Update()
    {
        transform.position += transform.forward * mineSpeed * Time.deltaTime; 
    }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false); 
    }
}