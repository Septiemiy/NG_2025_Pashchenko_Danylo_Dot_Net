export function changeDifficulty(difficulty) {
    switch (difficulty) {
        case 'Character (Easy)':
            return 0;
        case 'Character Status (Moderate)':
            return 1;
        case 'Location Type (Hard)':
            return 2;
    }
}