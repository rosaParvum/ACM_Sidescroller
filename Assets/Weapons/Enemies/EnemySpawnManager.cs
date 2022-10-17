using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public float randomOffset;

    public Enemy[] enemyTypes;

    int clock;
    spawner[] spawners;

    bool spawnLoop = true;
    // Start is called before the first frame update
    void Start()
    {
        List<spawner> spawnList = new List<spawner>();
        foreach (Transform child in transform) {spawnList.Add(child.gameObject.GetComponent<spawner>());}
        spawners = spawnList.ToArray();
        StartCoroutine(secondClock());
    }

    // i have no idea what this does really
    IEnumerator secondClock() {
        yield return new WaitForSeconds(1.0f);
        while(spawnLoop){
            foreach(Enemy type in enemyTypes) {

                if ((clock % type.frequency) == 0) {
                    type.Spawn(spawners);
                    yield return null;
                    // ^^^ what???????
                    //that line does nothing but if i take it out the project wont run
                }
            }
            clock++;
            yield return new WaitForSeconds(1.0f+Random.Range(-randomOffset,randomOffset));
        }
    }
}
