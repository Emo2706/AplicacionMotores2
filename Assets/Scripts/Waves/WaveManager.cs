using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : EnemyGlobalScript
{
    public WaveInfo[] wavesOrder_prefabs;

    public Wave[] waveOrder;
    int _activeWave;

    // Start is called before the first frame update
    protected override void Start()
    {
        for (int i = 0; i < wavesOrder_prefabs.Length; i++)
        {
            waveOrder[i] = Instantiate(wavesOrder_prefabs[i].WavePrefab);
            waveOrder[i].gameObject.SetActive(false);
        }
    }

    public void SetActiveWave()
    {
        waveOrder[_activeWave].gameObject.SetActive(true);
        _activeWave++;
    }
}
