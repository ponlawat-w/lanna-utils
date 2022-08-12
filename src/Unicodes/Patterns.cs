namespace LannaUtils.Unicodes;

public static class Patterns
{
    public readonly static string TaiThamLanna = @"\u1A20-\u1AAF";

    public readonly static string Choeng = @"\u1A60";

    public readonly static string DefaultLetters = @"\u1A20-\u1A4C";
    public readonly static string DefaultLettersExceptWa = @"\u1A20-\u1A44\u1A46-\u1A4C";
    public readonly static string TallAaLetters = @"\u1A23\u1A34\u1A35\u1A37\u1A45";
    public readonly static string LetterWa = @"\u1A45";
    public readonly static string LetterLowYa = @"\u1A3F";
    public readonly static string LetterNa = @"\u1A36";
    public readonly static string SingleVowelLetters = @"\u1A4D-\u1A52";
    public readonly static string ExtendedLetters = @"\u1A53-\u1A54";
    public readonly static string HoraNumbers = @"\u1A80-\u1A89";
    public readonly static string NaiThamNumbers = @"\u1A90-\u1A99";
    public readonly static string SpecialCharacters = @"\u1AA0-\u1AAD";
    public readonly static string SpatialCharacters = @"\u1A20-\u1A54\u1A80-\u1A99\u1AA0-\u1AAD";

    public readonly static string LowerChoengLetters = @"\u1A20-\u1A24\u1A26-\u1A2A\u1A2D-\u1A2F\u1A31-\u1A36\u1A3A-\u1A3E\u1A40-\u1A42\u1A44-\u1A46\u1A49-\u1A4C";
    public readonly static string LowerToRightChoengLetters = @"\u1A25\u1A2B\u1A2C\u1A30\u1A37-\u1A39\u1A3F\u1A43\u1A47\u1A48";
    public readonly static string ChoengableLetters = @"\u1A20-\u1A4C";
    public readonly static string ChoengableLettersExceptYa = @"\u1A20-\u1A3E\u1A40-\u1A4C";
    public readonly static string ChoengableLettersExceptYaWa = @"\u1A20-\u1A3E\u1A40-\u1A44\u1A46-\u1A4C";
    public readonly static string ChoengYa = @"\u1A60\u1A3F";
    public readonly static string ChoengWa = @"\u1A60\u1A45";

    public readonly static string UpperVowels = @"\u1A62\u1A65-\u1A68\u1A6B\u1A73\u1A74";
    public readonly static string UpperVowelsExceptO = @"\u1A62\u1A65-\u1A68\u1A73\u1A74";
    public readonly static string UpperVowelO = @"\u1A6B";
    public readonly static string UpperMaikang = @"\u1A74";
    public readonly static string LowerVowels = @"\u1A69\u1A6A\u1A6C";
    public readonly static string LowerVowelOa = @"\u1A6C";
    public readonly static string LeftVowels = @"\u1A6E-\u1A72";
    public readonly static string LeftVowelE = @"\u1A6E";
    public readonly static string RightVowels = @"\u1A61\u1A63\u1A64";
    public readonly static string RightVowelAa = @"\u1A63";
    public readonly static string RightVowelTallAa = @"\u1A64";
    public readonly static string LowerToRightVowels = @"\u1A6D";
    public readonly static string Vowels = @"\u1A61-\u1A74";

    public readonly static string Tones = @"\u1A75-\u1A79";
    public readonly static string Tone2 = @"\u1A76";
    public readonly static string UpperComponents = @"\u1A58-\u1A5A\u1A7A-\u1A7C";
    public readonly static string LowerComponents = @"\u1A56\u1A5B-\u1A5E\u1A7F";
    public readonly static string LeftComponents = @"\u1A55";
    public readonly static string LowerToRightComponents = @"\u1A57";
    public readonly static string Components = @"\u1A55\u1A58-\u1A5E\u1A75-\u1A7C\u1A7F";

    public readonly static string UpperCharacters = @"\u1A58-\u1A5A\u1A62\u1A65-\u1A68\u1A6B\u1A73-\u1A7C";
    public readonly static string LowerCharacters = @"\u1A56\u1A5B-\u1A5E\u1A69\u1A6A\u1A6C\u1A7F";
    public readonly static string LeftCharacters = @"\u1A55\u1A6E-\u1A72";
    public readonly static string NonRightCharacters = @"\u1A55\u1A56\u1A58-\u1A5E\u1A62\u1A65-\u1A6C\u1A6E-\u1A7C\u1A7F";
    public readonly static string RightCharacters = @"\u1A61\u1A63\u1A64";
    public readonly static string LowerToRightCharacters = @"\u1A57\u1A6D";
    public readonly static string NonSpatialCharacters = @"\u1A55-\u1A5E\u1A61-\u1A7C\u1A7F";
}
