using UnityEngine;

namespace UI
{
    public class MinimapIcon : MonoBehaviour
    {
        private GameObject _player;
        // Start is called before the first frame update
        void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            var transform1 = transform;
            var position = _player.transform.position;
            transform1.position = new Vector3(position.x, transform1.position.y, position.z);
        }
    }
}
