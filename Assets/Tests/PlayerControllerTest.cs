using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerControllerTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void PlayerControllerTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayerControllerTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterControllerInstantiation(string key)
    {
        SceneManager.LoadScene(1);
        GameObject go = null;
        AsyncOperationHandle<GameObject> loadHandle = Addressables.LoadAssetAsync<GameObject>(key); 
        yield return loadHandle;
        if (loadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject obj = loadHandle.Result;
            go = GameObject.Instantiate(obj);
        }
        Assert.That(go, Is.Not.Null);
        yield return null;
    }
}
