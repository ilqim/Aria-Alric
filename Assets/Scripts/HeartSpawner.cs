using UnityEngine;
using System.Collections;

public class HeartSpawner : MonoBehaviour
{
    public stork ilkim;

    public GameObject Kalp;
    public float height;

    private void Start(){
        StartCoroutine(SpawnObject());
    }

    public IEnumerator SpawnObject(){
        yield return new WaitForSeconds(20f);

        while(!ilkim.isDead){
            Instantiate(Kalp, new Vector3(3, Random.Range(-height, height), 0), Quaternion.identity);
            yield return new WaitForSeconds(10f);
        }
    }
}
