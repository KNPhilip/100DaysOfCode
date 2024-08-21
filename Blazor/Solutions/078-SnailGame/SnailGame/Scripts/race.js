//Variables
let modal = document.querySelector("#modal-container");
let modalText = document.querySelector("#winnertext");
let modalImage = document.querySelector("#winnerimg");
let span = document.querySelector("#close");
let startButton = document.querySelector("#startbutton");
let buttons = document.querySelector(".buttons");
let topText = document.querySelector("#top");
let currentRaceTime = 0;
let currentTopRaces = 0;
let currentTimeRecord, finishLine;
let snails = [];
if (screen.width > 500) {
    finishLine = 38;
}
else {
    finishLine = 22;
}

//Checks the snail names are set correctly and which snails are participating.
function validateSnails() {
    if (!getParameterByName("firstSnail").match(/^[A-Za-z]+$/) || !getParameterByName("firstSnail").match(/^[A-Za-z]+$/)) {
        window.location.href = "index.html";
        alert("Navngiv mindst 2 af de første snegle (Noget ordenligt..)");
    }
    else {
        let firstSnail = new Snail("firstSnail", getParameterByName("firstSnail"), "img/snail1", 0, -20, -34);
        let secondSnail = new Snail("secondSnail", getParameterByName("secondSnail"), "img/snail2", 0, -7, -34);
        snails.push(firstSnail);
        snails.push(secondSnail);
        if (getParameterByName("thirdSnail") != "") {
            if (!getParameterByName("thirdSnail").match(/^[A-Za-z]+$/)) {
                window.location.href = "index.html";
                alert("Navngiv den tredje snegl (Noget ordenligt..)");
            }
            else {
                let thirdSnail = new Snail("thirdSnail", getParameterByName("thirdSnail"), "img/snail3", 0, 6, -34);
                snails.push(thirdSnail);
                if (getParameterByName("fourthSnail") != "") {
                    if (!getParameterByName("fourthSnail").match(/^[A-Za-z]+$/)) {
                        window.location.href = "index.html";
                        alert("Navngiv den fjerde snegl (Noget ordenligt..)");
                    }
                    else {
                        let fourthSnail = new Snail("fourthSnail", getParameterByName("fourthSnail"), "img/snail4", 0, 19, -34);
                        snails.push(fourthSnail);
                    }
                }
            }
        }
    }

    //For loop to create the snails in the HTML
    for (i = 0; i < snails.length; i++) {
        document.querySelector("#raceway").innerHTML += '<div id="' + snails[i].id + '" class="snail-container"><p>' + snails[i].name + '<br>Points: ' + snails[i].racesWon + '</p></div>';

        let snailToEdit = document.getElementById(snails[i].id);
        snailToEdit.style.backgroundImage = "url('" + snails[i].icon + ".png')";
        snailToEdit.style.left = snails[i].left + "vw";
        if (screen.width > 1200) {
            snailToEdit.style.top = snails[i].top + "vh";
        }
        else {
            snailToEdit.style.top = (snails[i].top * 8) + "px";
        }
    }
}

//Starting the race
function start() {
    buttons.style.display = "none";
    startButton.innerText = "OMKAMP";

    for (i = 0; i < snails.length; i++) {
        let currentSnail = document.getElementById(snails[i].id);
        snails[i].left += (Math.round((Math.random() * 2) + 5) / Math.round((Math.random() * 14) + 5));
        currentSnail.style.left = snails[i].left + "vw";

        if (snails[i].left >= finishLine) {
            snails[i].racesWon += 1;
            setTimeout("gameOver('" + snails[i].name + "', '" + snails[i].icon + "winner.png')", 1000);
            break;
        }
        else if (i + 1 == snails.length) {
            setTimeout("start();", 100);
            currentRaceTime += 1;
        }
    }
}

//Ending the game, is executed when a snail reaches the finish line
function gameOver(fastestSnail, snailImage) {
    currentRaceTime = (currentRaceTime * 100) / 1000;

    modalText.innerText = "Ræset er slut og " + fastestSnail + " vandt! Det tog " + currentRaceTime.toFixed(1) + " sekunder";
    modalImage.src = snailImage;
    modal.style.display = "block";
    buttons.style.display = "block";

    if (currentRaceTime < currentTimeRecord || currentTimeRecord == undefined) {
        currentTimeRecord = currentRaceTime;
        topText.innerHTML = "Hurtigste tid sat af " + fastestSnail + " på <br> " + currentRaceTime.toFixed(1) + " sekunder!";
    }

    for (i = 0; i < snails.length; i++) {
        let currentSnail = document.getElementById(snails[i].id);
        currentSnail.style.left = "-34vw";
        currentSnail.innerHTML = '<p>' + snails[i].name + '<br>Points: ' + snails[i].racesWon + '</p>';
        snails[i].left = -34;
        if (snails[i].name == fastestSnail && snails[i].racesWon > currentTopRaces) {
            currentTopRaces += 1;
            currentSnail.style.backgroundImage = "url('" + snails[i].icon + "crown.png')";
        }
    }
    for (i = 0; i < snails.length; i++) {
        let currentSnail = document.getElementById(snails[i].id);
        if (snails[i].racesWon != currentTopRaces) {
            currentSnail.style.backgroundImage = "url('" + snails[i].icon + ".png')";
        }
    }
}

//Close winner modal when clicking on the close button
span.onclick = function () {
    modal.style.display = "none";
}

//Closes the winner modal when the user clicks anywhere outside it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
