using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepParticleSystemHandler : MonoBehaviour
{
    public static FootstepParticleSystemHandler Instance { get; private set; }

    public MeshParticleSystem meshParticleSystem;
    private List<Single> singleList;

    private void Awake()
    {
        Instance = this;
        singleList = new List<Single>();
    }

    private void Update()
    {
        for (int i = 0; i < singleList.Count; i++)
        {
            Single single = singleList[i];
            single.Update();
            if(single.IsSpawned())
            {
                singleList.RemoveAt(i);
                i--;
            }
        }
    }

    public void SpawnFootprint(Vector3 position, Vector3 direction)
    {
        singleList.Add(new Single(position, direction, meshParticleSystem));
    }

    //Represents a single Footprint
    private class Single
    {
        private MeshParticleSystem meshParticleSystem;
        private Vector3 position;
        private Vector3 direction;
        private int quadIndex;
        private Vector3 quadSize;
        private float rotation;

        public Single(Vector3 position, Vector3 direction, MeshParticleSystem meshParticleSystem)
        {
            this.position = position;
            this.direction = direction;
            this.meshParticleSystem = meshParticleSystem;

            quadSize = new Vector3(.2f, .2f);

            quadIndex = meshParticleSystem.AddQuad(position, rotation, quadSize, true, 0);
        }

        public void Update()
        {
            meshParticleSystem.UpdateQuad(quadIndex, position, rotation, quadSize, true, 0);
        }

        public bool IsSpawned()
        {
            return true;
        }
    }
}
