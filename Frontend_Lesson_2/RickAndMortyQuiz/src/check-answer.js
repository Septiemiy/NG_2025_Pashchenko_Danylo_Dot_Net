import { addToLocalStorage } from "./add-to-local-storage"

export function checkAnswer(correctAnswer) {
    try {
        const charCard = document.querySelector('.quiz-card')
        const selectedOption = charCard.querySelector('input[type="radio"]:checked')
        

        const selectedName = selectedOption.value
        if (selectedName === correctAnswer) {
            selectedOption.closest('label').style.color = 'rgb(18, 211, 18)'
            addToLocalStorage('correct')
        }
        else {
            selectedOption.closest('label').style.color = 'rgb(242, 10, 10)'
            addToLocalStorage('incorrect')
        }

        setTimeout(() => {
            location.reload()
        }, 1000)

    } catch {
        addToLocalStorage('unanswered')
        location.reload()
    }
}