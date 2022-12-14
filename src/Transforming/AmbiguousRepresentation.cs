using LannaUtils.Unicodes;

namespace LannaUtils.Transforming;

public static class AmbiguousRepresentation
{
    public readonly static IDictionary<string, string> SpecialValuesDict = new Dictionary<string, string>
    {
        { "ᨣᩝᩴ᩵", "koaboa" },
        { "ᨷᩴ᩵", "boa" },
        { "ᩓ᩠ᩅ", "laew" },
        { "ᩐᩣ", "ʔao" },
    };

    public readonly static IDictionary<string, string> LetterValuesDict = new Dictionary<string, string>
    {
        { Characters.LetterHighKa.ToString(), "k" },
        { Characters.LetterHighKha.ToString(), "k" },
        { Characters.LetterHighKxa.ToString(), "k" },
        { Characters.LetterLowKa.ToString(), "k" },
        { Characters.LetterLowKxa.ToString(), "k" },
        { Characters.LetterLowKha.ToString(), "k" },
        { Characters.LetterNga.ToString(), "ng" },
        { Characters.LetterHighCa.ToString(), "c" },
        { Characters.LetterHighCha.ToString(), "sh" },
        { Characters.LetterLowCa.ToString(), "c" },
        { Characters.LetterLowSa.ToString(), "s" },
        { Characters.LetterLowCha.ToString(), "sh" },
        { Characters.LetterNya.ToString(), "y" },
        { Characters.LetterRata.ToString(), "t" },
        { Characters.LetterHighRatha.ToString(), "t" },
        { Characters.LetterDa.ToString(), "d" },
        { Characters.LetterLowRatha.ToString(), "t" },
        { Characters.LetterRana.ToString(), "n" },
        { Characters.LetterHighTa.ToString(), "t" },
        { Characters.LetterHighTha.ToString(), "t" },
        { Characters.LetterLowTa.ToString(), "t" },
        { Characters.LetterLowTha.ToString(), "t" },
        { Characters.LetterNa.ToString(), "n" },
        { Characters.LetterBa.ToString(), "b" },
        { Characters.LetterHighPa.ToString(), "p" },
        { Characters.LetterHighPha.ToString(), "p" },
        { Characters.LetterHighFa.ToString(), "f" },
        { Characters.LetterLowPa.ToString(), "p" },
        { Characters.LetterLowFa.ToString(), "f" },
        { Characters.LetterLowPha.ToString(), "p" },
        { Characters.LetterMa.ToString(), "m" },
        { Characters.LetterLowYa.ToString(), "y" },
        { Characters.LetterHighYa.ToString(), "y" },
        { Characters.LetterRa.ToString(), "r" },
        { Characters.LetterRue.ToString(), "rue" },
        { Characters.LetterLa.ToString(), "l" },
        { Characters.LetterLue.ToString(), "lue" },
        { Characters.LetterWa.ToString(), "w" },
        { Characters.LetterHighSha.ToString(), "s" },
        { Characters.LetterHighSsa.ToString(), "s" },
        { Characters.LetterHighSa.ToString(), "s" },
        { Characters.LetterHighHa.ToString(), "h" },
        { Characters.LetterLla.ToString(), "l" },
        { Characters.LetterA.ToString(), "ʔ" },
        { Characters.LetterLowHa.ToString(), "h" },
        { Characters.LetterI.ToString(), "ʔi" },
        { Characters.LetterIi.ToString(), "ʔi" },
        { Characters.LetterU.ToString(), "ʔu" },
        { Characters.LetterUu.ToString(), "ʔu" },
        { Characters.LetterEe.ToString(), "ʔe" },
        { Characters.LetterOo.ToString(), "ʔo" },
        { Characters.LetterLae.ToString(), "lae" },
        { Characters.ConsonantSignMedialRa.ToString(), "r" },
        { Characters.ConsonantSignMedialLa.ToString(), "l" },
        { Characters.ConsonantSignLaTangLai.ToString(), "l" },
        { Characters.ConsonantSignHighRathaOrLowPa.ToString(), "p" },
        { Characters.ConsonantSignMa.ToString(), "m" },
        { Characters.ConsonantSignBa.ToString(), "b" },
        { Characters.ConsonantSignSa.ToString(), "s" },
        { Characters.LetterGreatSa.ToString(), "ss" },
        { Characters.HoraDigitZero.ToString(), "0" },
        { Characters.HoraDigitOne.ToString(), "1" },
        { Characters.HoraDigitTwo.ToString(), "2" },
        { Characters.HoraDigitThree.ToString(), "3" },
        { Characters.HoraDigitFour.ToString(), "4" },
        { Characters.HoraDigitFive.ToString(), "5" },
        { Characters.HoraDigitSix.ToString(), "6" },
        { Characters.HoraDigitSeven.ToString(), "7" },
        { Characters.HoraDigitEight.ToString(), "8" },
        { Characters.HoraDigitNine.ToString(), "9" },
        { Characters.ThamDigitZero.ToString(), "0" },
        { Characters.ThamDigitOne.ToString(), "1" },
        { Characters.ThamDigitTwo.ToString(), "2" },
        { Characters.ThamDigitThree.ToString(), "3" },
        { Characters.ThamDigitFour.ToString(), "4" },
        { Characters.ThamDigitFive.ToString(), "5" },
        { Characters.ThamDigitSix.ToString(), "6" },
        { Characters.ThamDigitSeven.ToString(), "7" },
        { Characters.ThamDigitEight.ToString(), "8" },
        { Characters.ThamDigitNine.ToString(), "9" },
        { Characters.VowelSignA.ToString(), "a" },
        { Characters.VowelSignMaiSat.ToString(), "a" },
        { Characters.VowelSignAa.ToString(), "a" },
        { Characters.VowelSignTallAa.ToString(), "a" },
        { Characters.VowelSignI.ToString(), "i" },
        { Characters.VowelSignIi.ToString(), "i" },
        { Characters.VowelSignUe.ToString(), "ue" },
        { Characters.VowelSignUue.ToString(), "ue" },
        { Characters.VowelSignU.ToString(), "u" },
        { Characters.VowelSignUu.ToString(), "u" },
        { Characters.VowelSignO.ToString(), "o" },
        { Characters.VowelSignOaBelow.ToString(), "oa" },
        { Characters.VowelSignOy.ToString(), "oy" },
        { Characters.VowelSignE.ToString(), "e" },
        { Characters.VowelSignAe.ToString(), "ae" },
        { Characters.VowelSignOo.ToString(), "o" },
        { Characters.VowelSignAi.ToString(), "ai" },
        { Characters.VowelSignThamAi.ToString(), "ai" },
        { Characters.VowelSignOaAbove.ToString(), "oa" },
        { Characters.SignMaiKang.ToString(), "ang" },
        { Characters.SignMaiSam.ToString(), "" },
        { Characters.SignTone1.ToString(), "" },
        { Characters.SignTone2.ToString(), "" }
    };

    public static string GetValue(string input) => LetterValuesDict.ContainsKey(input) ? LetterValuesDict[input] : "?";
    public static string GetSpecialValue(string input) => SpecialValuesDict.ContainsKey(input) ? SpecialValuesDict[input] : "?";
}
