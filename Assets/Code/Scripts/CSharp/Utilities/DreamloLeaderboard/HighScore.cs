using System.Collections;
using UnityEngine;

//Class Used to Store Highscore Data
public class Highscore {
    public string username;
    public int score;
    public int rank;
    public Highscore (string un = "", int sc = 0, int rk = 0) {
        username = un;
        score = sc;
        rank = rk;
    } 
}
