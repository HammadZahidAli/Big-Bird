using UnityEngine;
using System.Collections;

public class SoundManager : SingeltonBase<SoundManager> {

    public AudioSource efxSource;


    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.pitch = randomPitch;
        efxSource.clip = clips[randomIndex];
        efxSource.Play();
    }

    // to add a new sound effecr,
    // just add a new AudioClip variable here
    public AudioClip shatterSound;
	public AudioClip gemCollectSound;
	public AudioClip fallingSound;
	public AudioSource audioSource;
	public AudioSource playerAudioSource;

	// to add a new music ,
	// just add a new AudioClip variable here
	public AudioClip gameMusic;
	public AudioClip menuMusic;
	public AudioClip gameOverMusic;
	public AudioSource musicSource;

	// thsi is the music played when the script awakes
	public void Start() {
        Application.targetFrameRate = 100;

        if (PlayerPrefs.GetInt("firstTime") == 0)
        {
            UpdateHighScore.currentSoundState = 1;
            PlayerPrefs.SetInt("firstTime", 1);
            PlayerPrefs.SetInt("currentSoundState", 1);
            PlayerPrefs.Save();
        }

        UpdateHighScore.currentSoundState = PlayerPrefs.GetInt("currentSoundState");

        if(UpdateHighScore.currentSoundState == 1)
        {

            SoundManager.Instance.musicSource.mute = false;
            SoundManager.Instance.audioSource.mute = false;
            SoundManager.Instance.playerAudioSource.mute = false;
        }
        else
        {
            SoundManager.Instance.musicSource.mute = true;
            SoundManager.Instance.audioSource.mute = true;
            SoundManager.Instance.playerAudioSource.mute = true;
        }

        GameOverManager.totalScore = PlayerPrefs.GetInt("totalScore");
        GameOverManager.highScore = PlayerPrefs.GetInt("highScore");

 
        PlayMenuMusic();
	}

	// this method may be called from the outside 
	// to start the menu music
	public void PlayMenuMusic() {
		PlayMusic (menuMusic, true, 0.175f);
	}

	// this method may be called from the outside 
	// to start the game music
	public void PlayMusicGame() {
		PlayMusic (gameMusic, true, 0.15f);
	}


	// this method may be called from the outside 
	// to start the game over music
	public void PlayGameOverMusic() {
		PlayMusic (gameOverMusic, false, 2f);
	}

	// this is the master method which plays the selected audio 
	// via the corresponding AudioSource
	private void PlayMusic(AudioClip a, bool isLooping, float volume)
	{
		if (musicSource != null && musicSource.clip != null) {
			musicSource.Stop ();
		}
			
		musicSource.clip = a;
		musicSource.loop = isLooping;
		musicSource.volume = volume;
		musicSource.Play ();
	}

	
	// this method may be called from the outside 
	// to play the ball falling sound once
	public void playFallingSound() {
		playPlayerSound (fallingSound,0.1f);
	}

	// this method may be called from the outside 
	// to play the shatter sound once
	public void playShatterSound() {
		playSound (shatterSound,0.1f);
	}

	// this method may be called from the outside 
	// to play the gem collect sound once
	public void playGemSound() {
		playSound (gemCollectSound,0.1f);
	}

	// this is the master method which plays the selected sound effect 
	// via the corresponding AudioSource
	public void playSound(AudioClip audioClip, float volume) {
		if (audioSource != null && audioSource != null) {
			audioSource.Stop();
		}
		// play the effect once
		audioSource.volume = volume;
		audioSource.PlayOneShot(audioClip);
	}

	public void playPlayerSound(AudioClip audioClip, float volume) {
		if (playerAudioSource != null && playerAudioSource != null) {
			audioSource.Stop();
		}
		// play the effect once
		playerAudioSource.volume = volume;
		playerAudioSource.PlayOneShot(audioClip);
	}
}
