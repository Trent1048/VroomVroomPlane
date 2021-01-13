using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class Score {
    private static int score = 0; 

    public static void updateScore(int amount){
        score += amount;
    }

    public static int getScore(){
        return score;
    }

    public static void resetScore(){
        score = 0;
    }
}
