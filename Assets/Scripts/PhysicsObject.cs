using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]

public class PhysicsObject : MonoBehaviour
{
    [SerializeField]
    private Material _awakeMaterail;
    [SerializeField]
    private Material _asleepMaterial;

    private Rigidbody _rigidBody;
    private MeshRenderer _meshRenderer;
    private bool _wasSleeping = true;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    //private void Start()
    //{
    //    _wasSleeping = true;
    //    UpdateMeshRenderer();
    //}

    private void FixedUpdate()
    {

        _meshRenderer.material = _rigidBody.IsSleeping() ? _asleepMaterial : _awakeMaterail;

        UpdateMeshRenderer();
    }

    private void  UpdateMeshRenderer()
    {
        if (_rigidBody.IsSleeping() && !_rigidBody.IsSleeping() && _asleepMaterial != null)
        {
            _wasSleeping = true;
            _meshRenderer.material = _asleepMaterial;

        }
        if (!_rigidBody.IsSleeping() && _wasSleeping && _awakeMaterail != null)
        {
            _wasSleeping = false;
            _meshRenderer.material = _awakeMaterail;
        }
    }
}
