using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cocos2dxDeployer
{
  public class RandomStringGenerator
  {
    private Random _Random = new Random();
    private List<char> _Consonants = new List<char>() { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z' };
    private List<char> _Vowels = new List<char>() { 'A', 'E', 'I', 'O', 'U' };

    public List<string> GenerateRandomString(int totalStrings, int minLength, int maxLength, double vowelsPercentage)
    {
      int length = _Random.Next(minLength, maxLength + 1);
      int totalVowels = (int)Math.Round((double)length * vowelsPercentage);

      List<char> chars = new List<char>();
      for (int i = 0; i < totalVowels; i++)
        chars.Add(_Vowels[_Random.Next(0, _Vowels.Count)]);
      for (int i = totalVowels; i < length; i++)
        chars.Add(_Consonants[_Random.Next(0, _Consonants.Count)]);

      List<string> list = new List<string>();
      for (int i = 0; i < totalStrings; i++)
      {
        list.Add(GetRandomString(chars, _Random));
      }
      return list;
    }

    private string GetRandomString(List<char> chars, Random random)
    {
      int count = chars.Count, index;
      char swap;
      for (int i = 0; i < count - 1; i++)
      {
        index = random.Next(i, count);
        swap = chars[i];
        chars[i] = chars[index];
        chars[index] = swap;
      }
      StringBuilder sb = new StringBuilder();
      foreach (char s in chars)
        sb.Append(s);
      return sb.ToString();
    }
  }
}
