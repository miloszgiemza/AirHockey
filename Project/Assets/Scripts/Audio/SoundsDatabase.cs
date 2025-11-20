using UnityEngine;
using System;
using System.Collections;

using AudioClasses;
using System.Collections.Generic;

namespace Audio
{
    public enum SoundsMusic
    {
        MainMenuMusic,
        GamepayMusic
    }

    public enum SoundsEffects
    {
        WeakImpact,
        NormalImpact,
        StrongImpact,
        GoalScored,
        PuckBackInGame
    }

    public enum SoundsUI
    {
        Button
    }

    [Serializable]
    public class ItemSoundsDatabase<TKey>
    {
        public TKey Key => key;
        public AudioClip Value => value;

        [SerializeField] private TKey key;
        [SerializeField] private AudioClip value;
    }

    [Serializable]
    public class SoundsDatabase : MonoBehaviour
    {
        public AudioClip this[SoundsMusic key] 
        { 
            get => ReturnValueByKey(key); 
        }

        public AudioClip this[SoundsEffects key]
        {
            get => ReturnValueByKey(key);
        }
       
        public AudioClip this[SoundsUI key]
        {
            get => ReturnValueByKey(key);
        }

        public static SoundsDatabase Instance => instance;

        public ItemSoundsDatabase<SoundsMusic>[] SoundFilesMusic => soundFilesMusic;
        public ItemSoundsDatabase<SoundsEffects>[] SoundFilesEffects => soundFilesEffects;
        public ItemSoundsDatabase<SoundsUI>[] SoundFilesUI => soundFilesUI;

        private static SoundsDatabase instance;

        [SerializeField] private ItemSoundsDatabase<SoundsMusic>[] soundFilesMusic;
        [SerializeField] private ItemSoundsDatabase<SoundsEffects>[] soundFilesEffects;
        [SerializeField] private ItemSoundsDatabase<SoundsUI>[] soundFilesUI;

        private void Awake()
        {
            if(ReferenceEquals(SoundsDatabase.Instance, null))
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private AudioClip ReturnValueByKey(SoundsMusic key)
        {
            AudioClip value = null;

            for(int i = 0; i < soundFilesMusic.Length && ReferenceEquals(value, null); i++)
            {
                if(soundFilesMusic[i].Key == key)
                {
                    value = soundFilesMusic[i].Value;
                }
            }

            return value;
        }

        private AudioClip ReturnValueByKey(SoundsEffects key)
        {
            AudioClip value = null;

            for (int i = 0; i < soundFilesEffects.Length && ReferenceEquals(value, null); i++)
            {
                if (soundFilesEffects[i].Key == key)
                {
                    value = soundFilesEffects[i].Value;
                }
            }

            return value;
        }

        private AudioClip ReturnValueByKey(SoundsUI key)
        {
            AudioClip value = null;

            for (int i = 0; i < soundFilesUI.Length && ReferenceEquals(value, null); i++)
            {
                if (soundFilesUI[i].Key == key)
                {
                    value = soundFilesUI[i].Value;
                }
            }

            return value;
        }
    }
}
