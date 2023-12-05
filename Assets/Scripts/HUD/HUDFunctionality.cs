using PowerupSystem;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace HUD
{
    public class HUDFunctionality : MonoBehaviour
    {
        public TextMeshProUGUI /*positionText,*/ lapText;
        public Sprite[] powerupIcons;
        public Image currentPowerupIcon = null;
        public Sprite[] numberImages;
        public Image currentPlacementImage = null;
        public CartLap player;
        public GameObject playerObject;
        public PowerupContainer playerPowerupContainer;

        // Start is called before the first frame update
        void Start()
        {
            playerObject = GameObject.FindWithTag("Player");
            player = playerObject.GetComponent<CartLap>();
            playerPowerupContainer = playerObject.GetComponent<PowerupContainer>();
        }

        // Update is called once per frame
        void Update()
        {
            SetPositionText();
            SetLapText();
            SetPowerupIcon();
        }

        private void SetPositionText()
        {
            switch (player.Position)
            {
                case 1:
                    //positionText.text = player.Position.ToString() + "st";
                    currentPlacementImage.sprite = numberImages[1];
                    break;
                case 2:
                    //positionText.text = player.Position.ToString() + "nd";
                    currentPlacementImage.sprite = numberImages[2];
                    break;
                case 3:
                    //positionText.text = player.Position.ToString() + "rd";
                    currentPlacementImage.sprite = numberImages[3];
                    break;
                case 4:
                    currentPlacementImage.sprite = numberImages[4];
                    break;
                case 5:
                    currentPlacementImage.sprite = numberImages[5];
                    break;
                default:
                    //positionText.text = player.Position.ToString() + "th";
                    currentPlacementImage.sprite = numberImages[6];
                    break;
            }
        }

        private void SetLapText()
        {
            lapText.text = player.lapNumber + "/3";
        }

        private void SetPowerupIcon()
        {
            switch (playerPowerupContainer.currentPowerup)
            {
                case "Speed Boost":
                    currentPowerupIcon.sprite = powerupIcons[0];
                    break;
                case "Ball Projectile":
                    currentPowerupIcon.sprite = powerupIcons[1];
                    break;
                case "Crystal Trap":
                    currentPowerupIcon.sprite = powerupIcons[2];
                    break;
                case "Bone Trap":
                    currentPowerupIcon.sprite = powerupIcons[3];
                    break;
                case "Mind's Eye":
                    currentPowerupIcon.sprite = powerupIcons[4];
                    break;
                case "Catnip":
                    currentPowerupIcon.sprite = powerupIcons[5];
                    break;
                default:
                    currentPowerupIcon.sprite = powerupIcons[6];
                    break;
            }
        }
    }
}
