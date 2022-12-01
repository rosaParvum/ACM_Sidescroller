using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public float randomOffset;

    public Enemy[] enemyTypes;

    int clock;
    [HideInInspector]
    public spawner[] spawners;

    public spawner[] SpecialSpawners;

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
        yield return new WaitForSeconds(2.0f);
        while(spawnLoop){
            //print(clock);
            foreach(Enemy type in enemyTypes) {
                //string [] deb = {type.ToString(), (clock%type.frequency).ToString()};
                //string [] deb = {(clock%type.frequency).ToString()};
                //print(string.Concat(deb));
                if ((clock % type.frequency) == 0) {
                    if (!type.special) {type.Spawn(spawners);}
                    if (type.special) {print("special"); type.SpecialSpawn(SpecialSpawners);}
                    yield return null;
                    // ^^^ what???????
                    //that line does nothing but if i take it out the project wont run
                }
            }
            clock++;
            yield return new WaitForSeconds(1+Random.Range(-randomOffset,randomOffset));
        }
    }
}
