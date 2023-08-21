import character from './character.js';

// Description popup
const descriptionText = "Welcome to My Idle Game! Cultivate your crops and earn gold to level up and gain experience. Good luck!";
const descriptionWindow = document.getElementById("description");
const descriptionContent = document.getElementById("descriptionText");
let isDescriptionScrolling = false;

export function typeText() {
    let i = 0;
    let text = "";
    isDescriptionScrolling = true;
    descriptionWindow.addEventListener("click", () => {
        console.log("click");
        if (isDescriptionScrolling) {
            isDescriptionScrolling = false;
            descriptionContent.textContent = descriptionText;
        } else {
            descriptionWindow.style.display = "none";
            clearInterval(interval);
        }
    });
    const interval = setInterval(() => {
        if (isDescriptionScrolling) {
            text += descriptionText[i];
            descriptionContent.textContent = text;
            i++;
            if (i > descriptionText.length - 1) {
                isDescriptionScrolling = false;
            }
        }
    }, 50);
}


// Actions
const cultivateInput = document.getElementById("cultivateInput");
const cultivateButton = document.getElementById("cultivateButton");
const cultivateProgressBar = document.getElementById("cultivateProgressBar");
let isCultivating = false;

function cultivate() {
    if (isCultivating) {
        return;
    }
    const times = Number(cultivateInput.value);
    if (isNaN(times)) {
        return;
    }
    cultivateButton.disabled = true;
    isCultivating = true;
    let progress = 0;
    const interval = setInterval(() => {
        if (progress >= 100) {
            clearInterval(interval);
            gold += times;
            experience += times;
            updateStats();
            cultivateButton.disabled = false;
            isCultivating = false;
        } else {
            progress += 100 / 1000;
            cultivateProgressBar.style.width = `${progress}%`;
        }
    }, 10);
}

// Options
const languageOption = document.querySelector(".options .languageOption");
const modeOption = document.querySelector(".options .modeOption");
let isEnglish = true;
let isLightMode = true;

function toggleLanguage() {
    if (isEnglish) {
        languageOption.textContent = "Español";
        isEnglish = false;
    } else {
        languageOption.textContent = "English";
        isEnglish = true;
    }
}

function toggleMode() {
    const body = document.querySelector("body");
    if (isLightMode) {
        modeOption.textContent = "Dark mode";
        body.classList.remove("light");
        body.classList.add("dark");
        isLightMode = false;
    } else {
        modeOption.textContent = "Light mode";
        body.classList.remove("dark");
        body.classList.add("light");
        isLightMode = true;
    }
}