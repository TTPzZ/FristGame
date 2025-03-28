using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
        public static UI Instance;
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TMP_Text healthText;
        void Awake()
        {
            if(Instance != null && Instance != this){
                Destroy(this);
            }else{
                Instance = this;
            }
        }

        public void UpdateHealthBar()
        {
            healthSlider.maxValue = Player_controller.Instance.MaxHealth;
            healthSlider.value = Player_controller.Instance.Health;

            healthText.text = healthSlider.value + "/" + healthSlider.maxValue;
        }
}
