using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialParticleSystemHandler : MonoBehaviour
{
    public static MaterialParticleSystemHandler Instance { get; private set; }

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
            if(single.IsMovementComplete())
            {
                singleList.RemoveAt(i);
                i--;
            }
        }
    }

    public void SpawnFragment(Vector3 position, Vector3 direction)
    {
        singleList.Add(new Single(position, direction, meshParticleSystem));
    }

    //Represents a single material fragment
    private class Single
    {
        private MeshParticleSystem meshParticleSystem;
        private Vector3 position;
        private Vector3 direction;
        private int quadIndex;
        private Vector3 quadSize;
        private float rotation;
        private float moveSpeed;

        public Single(Vector3 position, Vector3 direction, MeshParticleSystem meshParticleSystem)
        {
            this.position = position;
            this.direction = direction;
            this.meshParticleSystem = meshParticleSystem;

            quadSize = new Vector3(.2f, .2f);
            rotation = Random.Range(0, 360f);
            moveSpeed = Random.Range(4f, 12f);

            quadIndex = meshParticleSystem.AddQuad(position, rotation, quadSize, true, 0);
        }

        public void Update()
        {
            position += direction * moveSpeed * Time.deltaTime;
            rotation += 360f * (moveSpeed / 10f) * Time.deltaTime;
             
            meshParticleSystem.UpdateQuad(quadIndex, position, rotation, quadSize, true, 0);

            moveSpeed -= moveSpeed * 3.5f * Time.deltaTime;
        }

        public bool IsMovementComplete()
        {
            return moveSpeed < .1f;
        }
    }
}
