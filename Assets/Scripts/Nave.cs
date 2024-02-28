using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField] float playerSpeed = 30f;

    [SerializeField] Transform repositoryPosition;
    [SerializeField] int mineType = 0;
    
    void Update()
    {        
        float horizontalDisplacement = Input.GetAxis("Horizontal");

        Vector3 displacement = new Vector3(horizontalDisplacement, 0f, 0f);
        transform.Translate(displacement * playerSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Fire1"))
        {
        GameObject repository = PoolManagerNave.Instance.GetPooledObjects(mineType, repositoryPosition.position, repositoryPosition.rotation);
        if(repository != null)
            {
                repository.SetActive(true);
            }
        else
            {
                Debug.LogError("Pool es demasiado pequeño");
            }
        }
    }
}