window.applyBrightness = function (levelIndex) {
    const root = document.documentElement;

    // 5 levels of brightness for hero section
    const brightness = {
        0: { // Bardzo jasny
            name: "very-light",
            mainGradient: "linear-gradient(135deg, #8B5CF6 0%, #6366F1 35%, #06B6D4 65%, #10B981 100%)",
            bubblePurple: "rgba(168, 85, 247, 0.55)",
            bubbleBlue: "rgba(99, 102, 241, 0.50)",
            bubbleCyan: "rgba(6, 182, 212, 0.48)",
            bubbleGreen: "rgba(16, 185, 129, 0.55)"
        },
        1: { // Jasny
            name: "light",
            mainGradient: "linear-gradient(135deg, #7C3AED 0%, #4F46E5 35%, #0891B2 65%, #059669 100%)",
            bubblePurple: "rgba(124, 58, 237, 0.65)",
            bubbleBlue: "rgba(79, 70, 229, 0.60)",
            bubbleCyan: "rgba(8, 145, 178, 0.58)",
            bubbleGreen: "rgba(5, 150, 105, 0.65)"
        },
        2: { // Aktualny (domyślnie)
            name: "current",
            mainGradient: "linear-gradient(135deg, #2a0d45 0%, #1338a0 35%, #0575b8 65%, #064839 100%)",
            bubblePurple: "rgba(88, 28, 135, 0.75)",
            bubbleBlue: "rgba(37, 99, 235, 0.70)",
            bubbleCyan: "rgba(6, 182, 212, 0.68)",
            bubbleGreen: "rgba(5, 150, 105, 0.75)"
        },
        3: { // Ciemny - Ciemne odcienie ale wciąż żywe
            name: "dark",
            mainGradient: "linear-gradient(135deg, #1a0629 0%, #0d1f6a 35%, #032d4a 65%, #021a12 100%)",
            bubblePurple: "rgba(62, 14, 97, 0.85)",
            bubbleBlue: "rgba(21, 46, 135, 0.82)",
            bubbleCyan: "rgba(3, 90, 120, 0.80)",
            bubbleGreen: "rgba(2, 80, 50, 0.85)"
        },
        4: { // Bardzo ciemny - Ciemne ale intensywnie żywe
            name: "very-dark",
            mainGradient: "linear-gradient(135deg, #0f031a 0%, #061247 35%, #001f34 65%, #010d08 100%)",
            bubblePurple: "rgba(45, 10, 70, 0.92)",
            bubbleBlue: "rgba(15, 30, 100, 0.88)",
            bubbleCyan: "rgba(2, 65, 90, 0.86)",
            bubbleGreen: "rgba(1, 55, 35, 0.92)"
        }
    };

    const level = brightness[levelIndex] || brightness[2];

    // Update hero gradient variables
    root.style.setProperty('--hero-main-gradient', level.mainGradient);
    root.style.setProperty('--hero-bubble-purple', level.bubblePurple);
    root.style.setProperty('--hero-bubble-blue', level.bubbleBlue);
    root.style.setProperty('--hero-bubble-cyan', level.bubbleCyan);
    root.style.setProperty('--hero-bubble-green', level.bubbleGreen);

    // Also update body background
    root.style.setProperty('--gradient-main', level.mainGradient);
    document.body.style.background = level.mainGradient;
    document.body.style.backgroundAttachment = 'fixed';

    console.log(`Brightness zmieniony na: ${level.name}`);
};

// Load saved brightness on page load
document.addEventListener('DOMContentLoaded', function () {
    const savedBrightness = localStorage.getItem('brightness-preference');
    const levelIndex = savedBrightness !== null ? parseInt(savedBrightness, 10) : 2;

    if (!isNaN(levelIndex) && levelIndex >= 0 && levelIndex < 5) {
        window.applyBrightness(levelIndex);
    } else {
        window.applyBrightness(2); // Default: Current
    }
});