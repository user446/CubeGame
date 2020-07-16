using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnvironmentManager : MonoBehaviour
{
    [Tooltip("List of possible environments which will be used")]
    public List<GameObject> environmentsPossible;

    [Tooltip("List of current environments available at runtime")]
    public List<GameObject> environmentsCurrent;
    private Environment startEnvironment;

    /// <summary>
    /// Here Environment Manager should find first environment, which will be our journey begin
    /// </summary>
    void Start()
    {
        startEnvironment = FindObjectOfType<Environment>();
        startEnvironment.halfwayPassed += CreateNewEnvironment;
        environmentsCurrent.Add(startEnvironment.gameObject);
    }

    /// <summary>
    /// Creates new environment on New Environment Spawner position of current environment
    /// </summary>
    void CreateNewEnvironment()
    {
        var new_env_ref = environmentsPossible[Random.Range(0, environmentsPossible.Count())];
        Debug.Log("Got a reference for new environment " + new_env_ref);
        var new_env = Instantiate(new_env_ref, gameObject.transform);
        new_env.transform.position = environmentsCurrent.First().GetComponent<Environment>().GetNextSpawnTransform().position;
        new_env.GetComponent<Environment>().halfwayPassed += CreateNewEnvironment;
        new_env.GetComponent<Environment>().environmentEntered += RemoveOldEnvironment;
        environmentsCurrent.Add(new_env);
    }

    /// <summary>
    /// Destroys previous environment on trigger environmentEntered
    /// </summary>
    void RemoveOldEnvironment()
    {
        Destroy(environmentsCurrent.First());
        environmentsCurrent.Remove(environmentsCurrent.First());
    }
    
}
