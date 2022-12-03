using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepParticleSystemHandler : MonoBehaviour
{
    public static FootstepParticleSystemHandler Instance { get; private set; }

    public MeshParticleSystem meshParticleSystem;
    private List<Single> singleList;

    private byte UVindex = 0;

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
        singleList.Add(new Single(position, direction, meshParticleSystem, UVindex));
        UVindex++;
        if (UVindex > 1)
        {
            UVindex = 0;
        }
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

        private byte thisUVindex;

        public Single(Vector3 position, Vector3 direction, MeshParticleSystem meshParticleSystem, byte UVindex)
        {
            this.position = position;
            this.direction = direction;

            rotation = Mathf.Atan2(this.direction.y, this.direction.x) * Mathf.Rad2Deg;
            rotation -= 90;
             if (rotation < 0) rotation += 360;

            this.meshParticleSystem = meshParticleSystem;

            quadSize = new Vector3(.1f, .2f);

            quadIndex = meshParticleSystem.AddQuad(position, rotation, quadSize, true, UVindex);
            thisUVindex = UVindex;
        }

        public void Update()
        {
            meshParticleSystem.UpdateQuad(quadIndex, position, rotation, quadSize, true, thisUVindex);
        }

        public bool IsSpawned()
        {
            return true;
        }
    }
}
