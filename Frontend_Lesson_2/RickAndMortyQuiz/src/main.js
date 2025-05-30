import './style.css'
import { createCharCard } from './create-char-card.js'
import { createStatusCard } from './create-status-card.js'
import { createTypesCard } from './create-location-type.js'
import { changeDifficulty } from './change-difficulty.js'

const cardFuncs = [createCharCard, createStatusCard, createTypesCard]

if (!sessionStorage.difficulty) {
    sessionStorage.setItem('difficulty', "Character (Easy)")
}

const app = document.querySelector('#app')
const { card } = await cardFuncs[changeDifficulty(sessionStorage.difficulty)]()
app.appendChild(card)

const localStorageDiv = document.createElement('div')
localStorageDiv.id = 'localStorage'

const correctP = document.createElement('p')
correctP.textContent = `Correct: ${localStorage.getItem('correct')}`
correctP.classList.add('correct')

const incorrectP = document.createElement('p')
incorrectP.textContent = `Incorrect: ${localStorage.getItem('incorrect')}`
incorrectP.classList.add('incorrect')

const unansweredP = document.createElement('p')
unansweredP.textContent = `Unanswered: ${localStorage.getItem('unanswered')}`
unansweredP.classList.add('unanswered')

localStorageDiv.appendChild(correctP)
localStorageDiv.appendChild(incorrectP)
localStorageDiv.appendChild(unansweredP)
app.appendChild(localStorageDiv)

const difficultySelect = document.createElement('div')
difficultySelect.id = 'difficultySelect'

const difficultyLabel = document.createElement('label')
difficultyLabel.textContent = 'Select Difficulty:'
difficultyLabel.classList.add('difficulty-label')
difficultySelect.appendChild(difficultyLabel)
difficultySelect.appendChild(document.createElement('br'))

const difficultyOption = ["Character (Easy)", "Character Status (Moderate)", "Location Type (Hard)"]

for(let index = 0; index < difficultyOption.length; index++) {
    const label = document.createElement('label')
    const radio = document.createElement('input')

    radio.type = 'radio'
    radio.name = 'difficulty'
    radio.value = difficultyOption[index]

    if (sessionStorage.difficulty === difficultyOption[index]) {
        radio.checked = true
    }

    radio.addEventListener('change', async () => {
        sessionStorage.difficulty = radio.value
        const { card } = await cardFuncs[changeDifficulty(sessionStorage.difficulty)]()
        
        app.querySelector('.quiz-card').remove()
        app.appendChild(card)
    })

    radio.classList.add('difficulty-radio')
    label.classList.add('difficulty-label')

    label.appendChild(radio)
    label.appendChild(document.createTextNode(radio.value))
    
    difficultySelect.appendChild(label)
    difficultySelect.appendChild(document.createElement('br'))
}

app.appendChild(difficultySelect)