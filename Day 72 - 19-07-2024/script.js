const validWords = [
    "ACHOO", "ARCH", "ARCHAIC", "ARHAT", "ARTHRITIC", "ATTACH", "CATARRH", "CATCH", "CATHARTIC", "CHAI",
    "CHAIR", "CHAOTIC", "CHAR", "CHARIOT", "CHART", "CHAT", "CHIA", "CHIC", "CHICA", "CHICHI", "CHIT",
    "CHITCHAT", "CHOIR", "COACH", "COCHAIR", "COHO", "COHORT", "CROTCH", "HAIR", "HARICOT", "HART",
    "HATCH", "HATH", "HATHA", "HITCH", "HOAR", "HOOCH", "HOORAH", "HOOT", "HORA", "HORCHATA", "HORROR",
    "ICHOR", "ITCH", "OATH", "ORTHOTIC", "RHOTIC", "RICH", "ROACH", "TACH", "THAT", "THATCH", "THORACIC",
    "THROAT", "TOOTH", "TORAH", "TORCH", "TROTH"
];
let currentInput = '';
let score = 0;

document.querySelectorAll('.heptagon div').forEach(item => {
    item.addEventListener('click', event => {
        const letter = item.getAttribute('data-letter');
        currentInput += letter;
        document.getElementById('inputBox').value = currentInput;
    });
});

function deleteLetter() {
    currentInput = currentInput.slice(0, -1);
    document.getElementById('inputBox').value = currentInput;
}

function submitWord() {
    if (currentInput.length < 4) {
        alert("The word must be at least 4 letters long.");
    } else if (!currentInput.includes('H')) {
        alert("The word must include the center letter 'H'.");
    } else if (!validWords.includes(currentInput)) {
        alert("The entered word is not valid.");
    } else {
        score++;
        document.getElementById('score').textContent = score;
        updateProgressBar();
    }
    currentInput = '';
    document.getElementById('inputBox').value = '';
}

function updateProgressBar() {
    const progressBar = document.getElementById('progressBar');
    const progress = (score / validWords.length) * 100;
    progressBar.style.width = `${progress}%`;
    progressBar.textContent = `${Math.round(progress)}%`;
    if (progress == 100) {
        alert("Congratulations! You found all the valid words.");
    }
}