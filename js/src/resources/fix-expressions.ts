export default {
  "fixTextExpressions": [
    {
      "name": "FixDanglingChoeng",
      "pattern": "([\\u1A60])([^\\u1A20-\\u1A4C])\u002B([\\u1A20-\\u1A4C])",
      "replace": "$1$3$2"
    },
    {
      "name": "FixLeftVowels",
      "pattern": "(^|\\s)(?\u003Cleft\u003E[\\u1A6E-\\u1A72])(?\u003Cmain\u003E[\\u1A20-\\u1A54\\u1A80-\\u1A99\\u1AA0-\\u1AAD][\\u1A55\\u1A6E-\\u1A72]?)",
      "replace": "$\u003Cmain\u003E$\u003Cleft\u003E"
    }
  ],
  "fixSegmentExpressions": [
    {
      "name": "FixUa",
      "pattern": "^(.\u002B)(\\u1A6B)([\\u1A75-\\u1A79]?)(\\u1A60[\\u1A20-\\u1A4C])?(\\u1A60\\u1A45)(.*)",
      "replace": "$1$4$5$2$3$6"
    },
    {
      "name": "FixAa",
      "pattern": "^(?\u003Cletters\u003E[\\u1A23\\u1A34\\u1A35\\u1A37\\u1A45])(?\u003Ccomponents\u003E([\\u1A55\\u1A56\\u1A58-\\u1A5E\\u1A62\\u1A65-\\u1A6C\\u1A6E-\\u1A7C\\u1A7F])*(\\u1A60[\\u1A20-\\u1A24\\u1A26-\\u1A2A\\u1A2D-\\u1A2F\\u1A31-\\u1A36\\u1A3A-\\u1A3E\\u1A40-\\u1A42\\u1A44-\\u1A46\\u1A49-\\u1A4C])*([\\u1A55\\u1A56\\u1A58-\\u1A5E\\u1A62\\u1A65-\\u1A6C\\u1A6E-\\u1A7C\\u1A7F])*)?(?\u003Caa\u003E\\u1A63)(?\u003Cfinal\u003E.*)?",
      "replace": "$\u003Cletters\u003E$\u003Ccomponents\u003E\u1A64$\u003Cfinal\u003E"
    },
    {
      "name": "FixOa",
      "pattern": "^(.\u002B)(\\u1A74)([\\u1A75-\\u1A79]?)(\\u1A6C)(.*)",
      "replace": "$1$4$2$3$5"
    },
    {
      "name": "FixAm",
      "pattern": "^(.\u002B)(\\u1A74)([\\u1A75-\\u1A79]?)(\\u1A63|\\u1A64)",
      "replace": "$1$4$2$3"
    },
    {
      "name": "FixIa",
      "pattern": "(?\u003CuayCase\u003E(?\u003CuayInit\u003E^[\\u1A20-\\u1A54\\u1A80-\\u1A99\\u1AA0-\\u1AAD]([\\u1A55])?([\\u1A56\\u1A5B-\\u1A5E\\u1A7F])?(\\u1A60[\\u1A20-\\u1A3E\\u1A40-\\u1A44\\u1A46-\\u1A4C])?)(?\u003CuayTone1\u003E[\\u1A75-\\u1A79]?)(?\u003CuayCw\u003E\\u1A60\\u1A45)(?\u003CuayCy\u003E\\u1A60\\u1A3F)(?\u003CuayTone2\u003E[\\u1A75-\\u1A79]?))|(?\u003CnonUay\u003E(?\u003Cinit\u003E^[\\u1A20-\\u1A54\\u1A80-\\u1A99\\u1AA0-\\u1AAD]([\\u1A55])?([\\u1A56\\u1A5B-\\u1A5E\\u1A7F])?(\\u1A60[\\u1A20-\\u1A3E\\u1A40-\\u1A44\\u1A46-\\u1A4C])?)((?\u003CiaCase\u003E(?\u003CiaCaseE\u003E\\u1A6E)(?\u003CiaCaseCy\u003E\\u1A60\\u1A3F)(?\u003CiaCaseTone\u003E[\\u1A75-\\u1A79]?))|(?\u003CiaFinalCase\u003E(?\u003CiaFinalCaseTone\u003E[\\u1A75-\\u1A79]?)(?\u003CiaFinalCaseCy\u003E\\u1A60\\u1A3F))|(?\u003CfinalYaCase\u003E(?\u003CfinalYaCaseTone\u003E[\\u1A75-\\u1A79]?)(?\u003CfinalYaCaseVowel\u003E([\\u1A69\\u1A6A\\u1A6C])|(\\u1A60\\u1A45))(?\u003CfinalYaCaseCy\u003E\\u1A60\\u1A3F))))",
      "replace": "$\u003CuayInit\u003E$\u003CuayCw\u003E$\u003CuayTone1\u003E$\u003CuayTone2\u003E$\u003CuayCy\u003E$\u003Cinit\u003E$\u003CiaCaseE\u003E$\u003CiaCaseTone\u003E$\u003CiaCaseCy\u003E$\u003CiaFinalCaseCy\u003E$\u003CiaFinalCaseTone\u003E$\u003CfinalYaCaseVowel\u003E$\u003CfinalYaCaseTone\u003E$\u003CfinalYaCaseCy\u003E"
    },
    {
      "name": "FixLowVowelTone",
      "pattern": "^(.\u002B)([\\u1A75-\\u1A79])([\\u1A69\\u1A6A\\u1A6C])(.*)",
      "replace": "$1$3$2$4"
    },
    {
      "name": "FixUea",
      "pattern": "^(?\u003Cinit\u003E.\u002B)(?\u003Ce\u003E\\u1A6E)(?\u003Ci\u003E\\u1A65[\\u1A75-\\u1A79]?)?(?\u003Co\u003E\\u1A6C)(?\u003Crest\u003E.*)",
      "replace": "$\u003Cinit\u003E$\u003Ce\u003E$\u003Co\u003E$\u003Ci\u003E$\u003Crest\u003E"
    },
    {
      "name": "FixWater",
      "pattern": "(\u1A36\u1A74\u1A76\u1A63|\u1A36\u1A63\u1A76\u1A74|\u1A36\u1A76\u1A63\u1A74|\u1A36\u1A74\u1A63\u1A76)",
      "replace": "\u1A36\u1A63\u1A74\u1A76"
    }
  ]
};