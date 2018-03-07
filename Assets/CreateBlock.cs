using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour {
    public GameObject Block;

    [SerializeField]
    private float _Interval = 1f;
    [SerializeField]
    private float _MaxClones = 30f;
    private float _CurrentClones = 0f;

    private void Start()
    {
        StartCoroutine(SpawnBlock());
    }

    private IEnumerator SpawnBlock()
    {
        while (true)
        {
            if (_CurrentClones <= _MaxClones)
            {
                Debug.Log(_CurrentClones);
                _CurrentClones = _CurrentClones + 1f;
                Instantiate(Block, transform.position, transform.rotation);
                yield return new WaitForSeconds(_Interval);

            } else {
                Destroy(GameObject.FindWithTag("Clones"));
                _CurrentClones = 0f;
                yield return new WaitForSeconds(1f);
            }
            
        }
        
    }
}
// Update is called once per frame
//void Update ()
// {
//for (int i = 1; i <= 20; i++)
// {
//  SpawnBlock();
//  new WaitForSeconds(1f);
// }
//}