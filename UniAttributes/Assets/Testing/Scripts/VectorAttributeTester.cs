using UniAttributes;
using UnityEngine;

namespace Testing.Scripts
{
    public class VectorAttributeTester : MonoBehaviour
    {
        public Vector2 _vector_1;
        [SerializeField] private Vector2 _vector_2;
        [Vector2Range(0f, 2f, 0f, 2f, false)]
        public Vector2 _vector_4;
        [Vector2Range(0f, 2f, 0f, 2f)]
        public Vector2 _vector_5;
        [Vector2Range(0f, 2f, 0f, 2f)]
        [SerializeField] private Vector2 _vector_6;
    }
}
