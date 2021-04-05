using System;
using UnityEngine;

namespace Core
{
    public class GoldTimer : MonoBehaviour
    {
        [SerializeField] private float timerOffset = 1f;
        private float _timer;

        private GoldManager _goldManager;

        private DateTime _dateTime;

        private void Awake()
        {
            _goldManager = GetComponent<GoldManager>();
        }

        private void Start()
        {
            GetAFKGold();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
            {
                SaveCurrentDate();
            }
            else
            {
                GetAFKGold();
            }
        }

        private void OnApplicationQuit()
        {
            SaveCurrentDate();
        }
        
        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= timerOffset)
            {
                _goldManager.GoldTick();
                _timer = 0;
            }
        }

        private void GetAFKGold()
        {
            // Get date of last enter
            _dateTime = DateTime.Parse(PlayerPrefs.GetString("Date"));
            
            // Calculate seconds since last enter
            TimeSpan timeSpan = DateTime.Now.Subtract(_dateTime);
            int seconds = (int)timeSpan.TotalSeconds;
            Debug.Log("Seconds: " + seconds);
            
            // Give gold to player
            _goldManager.GoldTick((int)(seconds / timerOffset));
        }

        private void SaveCurrentDate()
        {
            PlayerPrefs.SetString("Date", DateTime.Now.ToString());
            Debug.Log("Time of last enter: " + PlayerPrefs.GetString("Date"));
        }
    }
}
