using UnityEngine;
using System.Collections;
using System;
public class blockSpawner : MonoBehaviour
{
    public GameObject block;
    private Vector3 blockPosition;
    public float delay = 1f;
    public bool isRunning = true;
    // Update is called once per frame
    System.Random random = new System.Random();

    public void startFalling(){
        StartCoroutine(spawnNewBlock());
    }
    IEnumerator spawnNewBlock(){
        while (true)
        {
            if(isRunning){
                yield return new WaitForSeconds(delay);
                blockPosition = new Vector3(random.Next(-11,11),8,0);
                Instantiate(block,blockPosition,Quaternion.identity);
                yield return null;
            }else{
                break;
            }
        }
    }
}
