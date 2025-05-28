export function addToLocalStorage(key) {
    if (!localStorage.getItem('correct')) {
        localStorage.setItem('correct', 0)
        localStorage.setItem('incorrect', 0)
        localStorage.setItem('unanswered', 0)
    }

    try {
        switch (key) {
            case 'correct':
                localStorage.correct = parseInt(localStorage.correct) + 1
                break; 
            case 'incorrect':
                localStorage.incorrect = parseInt(localStorage.incorrect) + 1
                break;
            case 'unanswered':
                localStorage.unanswered = parseInt(localStorage.unanswered) + 1
                break;
        }
    } catch (error) {
        console.error('Error adding to local storage:', error);
    }
}