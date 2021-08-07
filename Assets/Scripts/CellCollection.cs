using UnityEngine;

[CreateAssetMenu(fileName = "New CellObject Collection", menuName = "CellObject Collection", order = 2)]
public class CellCollection : ScriptableObject
{
    [SerializeField] private CellObjectData[] _collection;

    public CellObjectData GetRandomData()
    {
        int index = Random.Range(0, _collection.Length);
        return _collection[index];
    }
}