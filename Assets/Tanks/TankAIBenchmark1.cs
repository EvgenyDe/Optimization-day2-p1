using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAIBenchmark1 : MonoBehaviour
{
    //GameObject[] tanks;
    public int numberOfTanks;
    public GameObject tankPrefab;

    [SerializeField] private MyUpdateManager _updateManager;
    private TankAI[] _tankAI;
    
    // Start is called before the first frame update
    void Start()
    {
        _tankAI = new TankAI[numberOfTanks];
        for (int i = 0; i < numberOfTanks; i++)
        {
            _tankAI[i] = Instantiate(tankPrefab).GetComponent<TankAI>();
            _tankAI[i].transform.position = new Vector3(Random.Range(-50,50), 0, Random.Range(-50,50));
            _updateManager.AddUpdatable(_tankAI[i]);
        }
    }

    // Update is called once per frame

}
