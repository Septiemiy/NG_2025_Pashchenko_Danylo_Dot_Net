import { getCharsData } from './get-data.js'
import { checkAnswer } from './check-answer.js'

const chars_url = 'https://rickandmortyapi.com/api/character'
const status_options = ['Alive', 'Dead', 'Unknown']

export async function createStatusCard() {
    let charId = getRandomNumber()
    let charUrl = `${chars_url}/${charId}`
    const char = await getCharsData(charUrl)

    const card = document.createElement('div')
    card.classList.add('quiz-card')

    const title = document.createElement('h2')
    title.textContent = `What is the status of this character?`
    title.classList.add('quiz-title')
    card.appendChild(title)

    const img = document.createElement('img')
    img.src = char.image
    img.alt = 'character image'
    img.classList.add('quiz-image')
    
    card.appendChild(img)
    card.appendChild(document.createElement('br'))
    
    for(let index = 0; index < status_options.length; index++) {
        const label = document.createElement('label')
        const radio = document.createElement('input')

        radio.type = 'radio'
        radio.name = 'char-status'
        radio.value = status_options[index]

        radio.classList.add('quiz-radio')
        label.classList.add('quiz-label')

        label.appendChild(radio)
        label.appendChild(document.createTextNode(radio.value))
        card.appendChild(label)
        card.appendChild(document.createElement('br'))
    }

    const button = document.createElement('button')
    button.classList.add('quiz-button')
    button.textContent = 'Check Answer'
    button.addEventListener('click', () => {
        button.disabled = true
        checkAnswer(char.status)
    })
    card.appendChild(button)

    return { card }
}

function getRandomNumber() {
    return Math.floor(Math.random() * 826) + 1
}