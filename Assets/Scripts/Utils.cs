using System.ComponentModel.Design.Serialization;
using UnityEngine;

public static class Utils
{
    public static int[] RandomNumerics(int _maxCount, int _n)
    {
        // 0 ~ _maxCount까지의 숫자 중 겹치지 않는 _n개의 난수가 필요할 때 사용
        int[] defaults  = new int[_maxCount];
        int[] results   = new int[_n];

        // 배열 전체에 0부터 maxCount의 값을 순서대로 저장
        for (int i = 0; i < _maxCount; ++i)
        {
            defaults[i] = i;
        }

        for (int i = 0; i < _n; ++i)
        {
            int index = Random.Range(0, _maxCount); // 임의의 숫자를 하나 뽑아서

            results[i] = defaults[index];
            defaults[index] = defaults[_maxCount-1];

            _maxCount--;
        }

        return results;

    }
        

}
