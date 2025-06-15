using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public stork ilkim;

    public GameObject Borular;
    public float height;

    private void Start(){
        StartCoroutine(SpawnObject());
    }
    public IEnumerator SpawnObject(){

        while(!ilkim.isDead){
            Instantiate(Borular, new Vector3(9.5f, Random.Range(-height, height), 0), Quaternion.identity);
            yield return new WaitForSeconds(4f);
        }
    }
}
