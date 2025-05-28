import './style.css'
import { createCharCard } from './create-char-card.js'
import { createStatusCard } from './create-status-card.js'
import { createTypesCard } from './create-location-type.js'

const cardFuncs = [createCharCard, createStatusCard, createTypesCard]

const app = document.querySelector('#app')
const { card } = await cardFuncs[Math.floor(Math.random() * cardFuncs.length)]()
app.appendChild(card)