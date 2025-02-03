using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class Spawner : MonoBehaviour
{
    List<GameObject> spawnList = new List<GameObject>();
    [SerializeField] float frequency;
    WaitForSeconds delay;
    [SerializeField] string key = "Enemy";
    AsyncOperationHandle<IList<GameObject>> loadHandle;

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return delay;
            SpawnEntity(spawnList[(int)Random.Range(0, spawnList.Count)]);
        }
    }

    private void SpawnEntity(GameObject entity)
    {
        int r = Random.Range(0, spawnList.Count);
        Instantiate(spawnList[r], transform.position, transform.rotation).SetActive(true);
    }


    public IEnumerator Start()
    {
        delay = new WaitForSeconds(1 / frequency);
        loadHandle = Addressables.LoadAssetsAsync<GameObject>(key, obj =>
        {
            //Gets called for every loaded asset
            spawnList.Add(obj);
        });
        yield return loadHandle;
        Debug.Assert(spawnList.Count > 0);

        if (loadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            StartCoroutine(SpawnCoroutine());
        }
    }
}
