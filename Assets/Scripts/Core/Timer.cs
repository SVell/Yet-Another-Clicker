using System;
using UnityEngine;

namespace Core
{
    public class Timer : MonoBehaviour
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
            _dateTime = DateTime.Parse(PlayerPrefs.GetString("Date"));
            GetAFKGold();
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetString("Date", DateTime.Now.ToString());
            Debug.Log("Time of last enter: " + PlayerPrefs.GetString("Date"));
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
            TimeSpan timeSpan = DateTime.Now.Subtract(_dateTime);
            int seconds = (int)timeSpan.TotalSeconds;
            Debug.Log("Seconds: " + seconds);
            
            _goldManager.GoldTick((int)(seconds / timerOffset));
        }
    }
}
