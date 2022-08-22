using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private ObjectPool _prefab;
    [Space(height:10)] [SerializeField] private Transform _container;
    [SerializeField] private int _minCapacity;
    [SerializeField] private int _maxCapacity;
    [Space(height:10)] [SerializeField] private bool _autoExpand;

    private List<ObjectPool> _pool;

    private void OnValidate()
    {
        if(_autoExpand)
        {
            _maxCapacity = Int32.MaxValue;
        }
    }

    private void CreatePool()
    {
        _pool = new List<ObjectPool>(_minCapacity);

        for(int i = 0; i < _minCapacity; i++)
        {
            CreateElement();
        }
    }

    private ObjectPool CreateElement(bool isActiveByDefault = false)
    {
        var createdObject = Instantiate(_prefab, _container);
        createdObject.gameObject.SetActive(false);

        _pool.Add(createdObject);

        return createdObject; 
    }

    public bool TryGetElement(out ObjectPool element)
    {
        foreach(var item in _pool)
        {
            if(!item.gameObject.activeInHierarchy)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public ObjectPool GetFreeElement(Vector3 position)
    {
        var element = GetFreeElement();
        element.transform.position = position;
        return element;
    }

    public ObjectPool GetFreeElement(Vector3 position, Quaternion rotation)
    {
        var element = GetFreeElement(position);
        element.transform.rotation = rotation;
        return element;
    }

    public ObjectPool GetFreeElement()
    {
        if(TryGetElement(out var element))
        {
            return element;
        }

        if(_autoExpand)
        {
            return CreateElement(true);
        }

        if(_pool.Count < _maxCapacity)
        {
            return CreateElement(isActiveByDefault:true);
        }

        throw new Exception(message: "Pool is over!");
    }
}
