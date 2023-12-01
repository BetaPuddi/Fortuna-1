using UnityEngine;
using TMPro;

namespace HUD
{
    public class HUDFunctionality : MonoBehaviour
    {
        public TextMeshProUGUI positionText;
        public CartLap player;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            SetPositionText();
        }

        private void SetPositionText()
        {
            switch (player.Position)
            {
                case 1:
                    positionText.text = player.Position.ToString() + "st";
                    break;
                case 2:
                    positionText.text = player.Position.ToString() + "nd";
                    break;
                case 3:
                    positionText.text = player.Position.ToString() + "rd";
                    break;
                default:
                    positionText.text = player.Position.ToString() + "th";
                    break;
            }
        }
    }
}
