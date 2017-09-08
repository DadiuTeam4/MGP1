using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSynchronizer : MonoBehaviour 
{
	public int beatsPerLoop;
	public AudioClip[] tracks;
	public float accuracyRange;
    public float aliveTime = 0.5f;

	private float currentTrackLength;
	private float[] keyTimeStamps;
	private List<Rhythmic> rhythmicObjects;
	[SerializeField]
	private AudioSource audioPlayer;
	private int currentTrack;
	private float currentBPM;
	private int nextBeat;
    private int lastAudioTime;
    

	void Awake() 
	{
		rhythmicObjects = new List<Rhythmic>();
		// Get all rhythmic objects which are affected my the beat
		Rhythmic[] objs = FindObjectsOfType<Rhythmic>();

        int i = 0;
		// Convert to list
		foreach (Rhythmic obj in objs) 
		{
            obj.position = i;//turn to be clickable
            rhythmicObjects.Add(obj);
            i++;
        }

		// Set player to first track
		currentTrack = 1;
		// Get attributes from clip
		AudioClip clip = tracks[currentTrack];
		audioPlayer.clip = clip;
		currentTrackLength = clip.length;

		// Set key time stamps according to the number of beats and the track length
		UpdateKeyTimeStamps();

		// Set next beat to 0
		nextBeat = 0;

		// Start music
		audioPlayer.Play();
	}

	void Update()
	{
        // Check if a beat is in range
        if (keyTimeStamps[nextBeat] < audioPlayer.time + accuracyRange && (int)(audioPlayer.time + accuracyRange) != lastAudioTime) 
		{
            //print("KeyTimeStamp:" + keyTimeStamps[nextBeat].ToString());
            //print("Audioplayer.time:" + (audioPlayer.time + accuracyRange).ToString());

            UpdateRhythmics();
			nextBeat = nextBeat + 1 == beatsPerLoop ? 0 : nextBeat + 1;
            print("RHYTHMIC OBJECTS = "+rhythmicObjects.Count);
            lastAudioTime = (int)(audioPlayer.time + accuracyRange);
		}

        //removing destroyed objects
        rhythmicObjects.RemoveAll(x => x == null);
        
        
        //Checking if the objects should be deactivated
        if (lastAudioTime + aliveTime < audioPlayer.time)
        {
            foreach (Rhythmic obj in rhythmicObjects)
            {

                if (obj.active)
                {
                    
                    obj.InitialState();
                }
 
            }

        }

        // Changing tracks for debugging purposes
        if (Input.anyKeyDown)
		{
			ChangeTracks(currentTrack + 1 < 3 ? currentTrack + 1 : 0);
		}
	}

    public int TurnOfClickable()
    {
        int next = -1;
        foreach (Rhythmic obj in rhythmicObjects)
        {

            if (next > obj.position)
            {
                next = obj.position;
            }

        }
        return next;
    }


	public void ChangeTracks(int trackIndex) 
	{
		if (audioPlayer.isPlaying) { audioPlayer.Stop(); }

		// Update attributes
		currentTrack = trackIndex;
		AudioClip clip = tracks[currentTrack];
		audioPlayer.clip = clip;
		currentTrackLength = clip.length;
		UpdateKeyTimeStamps();

		if (!audioPlayer.isPlaying) { audioPlayer.Play(); }
	}

	public void SetBeats(int beats) 
	{
		// Update attributes
		beatsPerLoop = beats;
		// Find new key time stamps
		UpdateKeyTimeStamps();
	}

	public void UpdateKeyTimeStamps() 
	{
		keyTimeStamps = new float[beatsPerLoop];
		// Find key time stamps by splitting the track time by number of beats
		float interval = currentTrackLength / beatsPerLoop;
		keyTimeStamps[beatsPerLoop - 1] = interval * beatsPerLoop;
		for (int i = 1; i < beatsPerLoop; i++) 
		{

			keyTimeStamps[i - 1] = i * interval;
            
        }
    }

    public void UpdateRhythmics()
    {
        foreach (Rhythmic obj in rhythmicObjects)
        {
            obj.IncrementCurrentBeat();
        }
    }
}
