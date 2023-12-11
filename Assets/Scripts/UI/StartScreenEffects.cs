using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class StartScreenEffects : MonoBehaviour
    {
        [SerializeField] private RectTransform logoShine;
        [SerializeField] private Vector2 shineEndPosition;
        private Vector2 _shineStartPosition;

        // Start is called before the first frame update
        void Start()
        {
            _shineStartPosition = logoShine.anchoredPosition;

        }

        // Update is called once per frame
        void Update()
        {
            if (Math.Abs(logoShine.anchoredPosition.x - shineEndPosition.x) > 0.1f)
            {
                var position = logoShine.anchoredPosition;
                position = new Vector2(Mathf.Lerp(position.x, shineEndPosition.x, (Time.deltaTime * 0.8f)), Mathf.Lerp(position.y, shineEndPosition.y, 1f));
                logoShine.anchoredPosition = position;
            }
            else
            {
                logoShine.anchoredPosition = _shineStartPosition;
            }
        }

    }
}
