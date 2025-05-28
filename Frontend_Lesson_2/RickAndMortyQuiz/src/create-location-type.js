import { getCharsData } from './get-data.js'
import { checkAnswer } from './check-answer.js'

const chars_url = 'https://rickandmortyapi.com/api/location'
const type_options = 4;
const locationTypes = ["Planet", "Cluster", "Space Station", "Microverse", "Dimension", "Citadel", "Reality", 
                       "World", "Universe", "Galaxy", "TV", "Resort", "Memory", "Diegesis"];

export async function createTypesCard() {
    let charId = getRandomNumber()
    let charUrl = `${chars_url}/${charId}`
    const location = await getCharsData(charUrl)

    let typeForBack = checkTypeInArray(location.type)

    const card = document.createElement('div')
    card.classList.add('quiz-card')

    const title = document.createElement('h2')
    title.textContent = `Guess the type of this location`
    title.classList.add('quiz-title')
    card.appendChild(title)

    const locName = document.createElement('p')
    locName.textContent = location.name
    locName.classList.add('loc-name')
    card.appendChild(locName)
    
    card.appendChild(document.createElement('br'))

    let rightTypeRandomNumber = Math.floor(Math.random() * type_options) + 1;
    
    for(let index = 0; index < type_options; index++) {
        const label = document.createElement('label')
        const radio = document.createElement('input')

        let randomType = getRandomType()

        radio.type = 'radio'
        radio.name = 'loc-type'
        if (index === rightTypeRandomNumber) {
            radio.value = location.type
        }
        else {
            radio.value = randomType
        }

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
        checkAnswer(location.type)
    })
    card.appendChild(button)

    locationTypes.push(typeForBack)

    return { card }
}

function getRandomNumber() {
    return Math.floor(Math.random() * 126) + 1
}

function checkTypeInArray(type) {
    if (locationTypes.includes(type)) {
        locationTypes.pop(locationTypes.indexOf(type))
        return type
    }
}

function getRandomType() {
    return locationTypes[Math.floor(Math.random() * locationTypes.length)]
}