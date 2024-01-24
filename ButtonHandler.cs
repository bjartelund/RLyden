public class ButtonHandler
{
    private static readonly Random _random = new Random();
    private static readonly string[] _vowels = ["a", "e", "i", "o", "u","y","æ","ø","å"];
    private static readonly string[] _lettersOfInterest = ["r", "l"];
    public string Text = GenerateThreeLetterCombination();
    public void ButtonClicked(LetterVariant letters)
    {
        Text = letters switch
        {
            LetterVariant.VowelPrefixAndSuffix => GenerateThreeLetterCombination(),
            LetterVariant.VowelPrefix => GenerateWithVowelPrefix(),
            LetterVariant.VowelSuffix => GenerateWithVowelSuffix(),
            LetterVariant.LetterOfInterest => GetLetterOfInterest(),
            _ => GenerateThreeLetterCombination(),
        };
    }

    private static string GetVowel()
    {
        return _vowels[_random.Next(0, _vowels.Length)];
    }
    private static string GetLetterOfInterest()
    {
        return _lettersOfInterest[_random.Next(0, _lettersOfInterest.Length)];
    }
    private static string GenerateThreeLetterCombination()
    {
        return $"{GetVowel()}{GetLetterOfInterest()}{GetVowel()}";
    }
    private static string GenerateWithVowelPrefix()
    {
        return $"{GetVowel()}{GetLetterOfInterest()}";
    }
    private static string GenerateWithVowelSuffix()
    {
        return $"{GetLetterOfInterest()}{GetVowel()}";
    }
}

public enum LetterVariant
{
    LetterOfInterest,
    VowelPrefix,
    VowelSuffix,
    VowelPrefixAndSuffix,
}