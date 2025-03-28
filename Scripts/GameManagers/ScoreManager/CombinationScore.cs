using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 블럭의 조합 점수와 계수를 저장하는 클래스
/// </summary>
public class CombinationData
{
    public Dictionary<string, int> CombinationScores { get; private set; }
    public Dictionary<string, float> CombinationCoefficients { get; private set; }

    public CombinationData()
    {
        CombinationScores = new Dictionary<string, int>();
        CombinationCoefficients = new Dictionary<string, float>();
    }

    public void SetCombinationData(string blockType, int score, float coefficient)
    {
        CombinationScores[blockType] = score;
        CombinationCoefficients[blockType] = coefficient;
    }

    public int GetScore(string blockType) => CombinationScores.ContainsKey(blockType) ? CombinationScores[blockType] : 0;
    public float GetCoefficient(string blockType) => CombinationCoefficients.ContainsKey(blockType) ? CombinationCoefficients[blockType] : 1.0f;
}

/// <summary>
/// 조합된 블럭들의 점수를 계산하는 클래스
/// </summary>
public class CombinationScoreCalculator
{
    private CombinationData combinationData;
    private int additionalScore;
    private float additionalCoefficient;

    public CombinationScoreCalculator(CombinationData data, int addScore = 0, float addCoefficient = 0.0f)
    {
        combinationData = data;
        additionalScore = addScore;
        additionalCoefficient = addCoefficient;
    }

    public int CalculateScore(IEnumerable<GameObject> matchedBlocks)
    {
        int totalScore = 0;
        float totalCoefficient = 1.0f;

        foreach (var block in matchedBlocks)
        {
            string blockType = block.name; // 블럭의 종류를 GameObject의 이름으로 가정
            totalScore += combinationData.GetScore(blockType);
            totalCoefficient *= combinationData.GetCoefficient(blockType);
        }

        totalScore += additionalScore;
        totalCoefficient += additionalCoefficient;

        return Mathf.RoundToInt(totalScore * totalCoefficient);
    }

    public static int CalculateScore(MatchesInfo matches)
    {
        int totalScore = 0;
        float totalMultiplier = 1.0f;


        Debug.Log("score combination");

        foreach (var candy in matches.MatchedCandy)
        {
            BlockProperties properties = candy.GetComponent<BlockProperties>();

            if (properties != null)
            {
                totalScore += properties.BaseScore;
                totalMultiplier *= properties.ScoreMultiplier;
            }
        }

        return Mathf.RoundToInt(totalScore * totalMultiplier);
    }
}

public class CombinationScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
