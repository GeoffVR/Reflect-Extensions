﻿using System.Collections;
using UnityEngine;

[ExecuteAlways]
public class RandomAudioPlayback : MonoBehaviour
{
    [SerializeField] float interval_min = .5f;
    [SerializeField] float interval_max = 5f;

    [SerializeField] bool refreshAudioSources = false;

    [SerializeField] AudioClip[] clips = default;

    AudioSource[] _sources;

    private void Awake()
    {
        _sources = GetComponentsInChildren<AudioSource>();

        enabled = clips.Length != 0;
    }

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(interval_min, interval_max));

            if (refreshAudioSources)
                _sources = GetComponentsInChildren<AudioSource>();

            _sources[Random.Range(0, _sources.Length)].PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
    }
}