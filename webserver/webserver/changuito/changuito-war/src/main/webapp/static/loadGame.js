var gameRoundToPlay;

function load(gameRound) {

    gameRoundToPlay = gameRound;

    console.log(gameRoundToPlay)

    $("#resultado").load("static/unityPlayer/unityPlayerLoader.jsp");

    setTimeout("startUnity()", 9000);
}

function startUnity(){

    console.log("Starting StartAlreadyPlayedGameRound");
    sendMessageToUnity(JSON.stringify(gameRoundToPlay));
}

function isIE() {
    var isIE11 = navigator.userAgent.indexOf(".NET CLR") > -1;
    var isIE11orLess = isIE11 || navigator.appVersion.indexOf("MSIE") != -1;
    return isIE11orLess;
}

function getUnityEmbed() {

    if (isIE())
        return document.getElementById("unityPlayerEmbed").childNodes[0];

    return document.embeds[0];
}

function sendMessageToUnity(value) {

    console.log("Invoking callback with value [" + value + "]");

    var unityEmbed = getUnityEmbed();
    unityEmbed.SendMessage("PlayButton", "StartAlreadyPlayedGame", value);
}