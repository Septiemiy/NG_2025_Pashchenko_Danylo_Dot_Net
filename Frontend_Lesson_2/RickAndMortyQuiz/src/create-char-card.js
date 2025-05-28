import { getCharsData } from './get-data.js'
import { checkAnswer } from './check-answer.js'

const chars_url = 'https://rickandmortyapi.com/api/character'
const name_options = 4;
const names = ["Rick Sanchez", "Morty Smith", "Summer Smith", "Alien Rick", "Aqua Morty", "Evil Morty", "Mr. Meeseeks", 
               "Birdperson", "Squanchy", "Mr. Poopybutthole", "Arcade Alien", "Stair Goblin", "Super Turkey", "Mr. Goldenfold",
               "Principal V", "Tammy Guetermann", "Jessica", "Krombopulos Michael", "Unity", "Birdperson", "Evil Rick"]

export async function createCharCard() {
    let charId = getRandomNumber()
    let charUrl = `${chars_url}/${charId}`
    const char = await getCharsData(charUrl)

    let nameForBack = checkNameInArray(char.name)

    const card = document.createElement('div')
    card.classList.add('quiz-card')

    const title = document.createElement('h2')
    title.textContent = `Who is this character?`
    title.classList.add('quiz-title')
    card.appendChild(title)

    const img = document.createElement('img')
    img.src = char.image
    img.alt = 'character image'
    img.classList.add('quiz-image')
    
    card.appendChild(img)
    card.appendChild(document.createElement('br'))

    let rightNameRandomNumber = Math.floor(Math.random() * name_options) + 1;
    
    for(let index = 0; index < name_options; index++) {
        const label = document.createElement('label')
        const radio = document.createElement('input')

        let randomName = getRandomName()

        radio.type = 'radio'
        radio.name = 'char-name'
        if (index === rightNameRandomNumber) {
            radio.value = char.name
        }
        else {
            radio.value = randomName
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
        checkAnswer(char.name)
    })
    card.appendChild(button)

    names.push(nameForBack)

    return { card }
}

function getRandomNumber() {
    return Math.floor(Math.random() * 826) + 1
}

function checkNameInArray(name) {
    if (names.includes(name)) {
        names.pop(names.indexOf(name))
        return name;
    }
}

function getRandomName() {
    return names[Math.floor(Math.random() * names.length)]
}