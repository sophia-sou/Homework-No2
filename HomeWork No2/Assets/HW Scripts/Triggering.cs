using UnityEngine;

public class Triggering : MonoBehaviour
{
    public GameObject Prefab;
    private GameObject InstantiatedPrefab;
    private void OnTriggerEnter(Collider other)
    {
        // when entering instantiate prefab
        // at triggers (empty) position 
        // no rotation
        InstantiatedPrefab = Instantiate(Prefab, transform.position, Quaternion.identity);
    }
    private void OnTriggerExit(Collider other)
    {
        // stop prefab insatiation when exiting

        if (InstantiatedPrefab != null) ;
        {
            Destroy(InstantiatedPrefab);
        }
    }

}
