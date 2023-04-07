using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardManager : MonoBehaviour {
    const string PrivateCode    = ""; //Paste your Dreamlo PrivateCode Here
    const string PublicCode     = ""; //Paste Your Dreamlo Public Code Here
    const string WebURL         = "http://dreamlo.com/lb/";
    private UnityWebRequest Web;
	public List<Highscore> HighscoreList = new List<Highscore>();
    
	//Start Method
	private void Start() { 
		Download(); 
	}
	
	//Method To Initiate Coroutine that Uploads Score(s)
    public void AddNewScore(string username, int score) { 
		StartCoroutine(UploadScore(username, score)); 
	}

	//Method To Initiate Coroutine that Downloads Score(s)
    public void Download() { 
		StartCoroutine(DownloadScore()); 
	}

    private IEnumerator UploadScore(string UserName, int Score) {
        Web = UnityWebRequest.Get(WebURL + PrivateCode + "/add/" + UnityWebRequest.EscapeURL(UserName) + "/" + Score);
        yield return Web.SendWebRequest();
        if (string.IsNullOrEmpty(Web.error)) {
            Debug.Log("Score Added To Leaderboard");
        }
        else {
            Debug.Log(Web.error);
        }
    }
	
    private IEnumerator DownloadScore() {
        Web = UnityWebRequest.Get(WebURL + PublicCode + "/pipe/");
        yield return Web.SendWebRequest();
        if (string.IsNullOrEmpty(Web.error)) {
            Debug.Log("1.\n" + "Username: " + GetHighscore(1).username + "\n" + "Score: " + GetHighscore(1).score);
        }
        else {
            Debug.Log(Web.error);
        }
    }

    public void UpdateHighscoreList(string textstream) {
        string[] entries = textstream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        HighscoreList.Clear();
        for (int i = 0; i < entries.Length; i++) {
            if (i > 10) { break; } //only take the top 10 entries
            string[] entryInfo  = entries[i].Split(new char[]{'|'});
            string username     = entryInfo[0];
            int score           = int.Parse(entries[1]);
            int rank            = i++;
            HighscoreList.Add(new Highscore(username, score, rank));
        }
    }

    public Highscore GetHighscore(int TargetRank) {
        Highscore target = new Highscore();
        if (HighscoreList.Count > 0) {
            foreach(Highscore hs in HighscoreList) {
                if (hs.rank == TargetRank){ target = hs;}
            }
        }    
        return target;
    }
}
