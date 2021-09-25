'use strict';

const score0 = document.getElementById('score--0');
const score1 = document.getElementById('score--1');
const currentScore0 = document.getElementById('current--0');
const currentScore1 = document.getElementById('current--1');
const dice = document.querySelector('.dice');
const btnNew = document.querySelector('.btn--new');
const btnRoll = document.querySelector('.btn--roll');
const btnHold = document.querySelector('.btn--hold');
const player0 = document.querySelector('.player--0');
const player1 = document.querySelector('.player--1');
score1.textContent = 0;
score0.textContent = 0;
dice.classList.add('hidden');

let score = [0, 0];
let activeplayer = 0;
let playing = true;

btnRoll.addEventListener('click', function () {
  if (playing) {
    let randomDice = Math.trunc(Math.random() * 6 + 1);
    console.log(randomDice);
    dice.setAttribute('src', `dice-${randomDice}.png`);
    dice.classList.remove('hidden');
    if (randomDice !== 1) {
      let scoreDisplay = Number(
        document.getElementById(`current--${activeplayer}`).textContent
      );
      scoreDisplay += randomDice;
      document.getElementById(`current--${activeplayer}`).textContent =
        scoreDisplay;
    } else {
      changePlayer();
    }
  }
});

btnHold.addEventListener('click', function () {
  let scoreDisplay = Number(
    document.getElementById(`current--${activeplayer}`).textContent
  );
  score[activeplayer] += scoreDisplay;
  score0.textContent = score[0];
  score1.textContent = score[1];
  document.getElementById(`current--${activeplayer}`).textContent = 0;
  changePlayer();
  if (score[activeplayer] >= 100) {
    playing = false;
    document
      .querySelector(`.player--${activeplayer}`)
      .classList.add('player--winner');
    document
      .querySelector(`.player--${activeplayer}`)
      .classList.remove('player--active');
  }
});

function changePlayer() {
  document.getElementById(`current--${activeplayer}`).textContent = 0;
  activeplayer = activeplayer === 0 ? 1 : 0;
  player0.classList.toggle('player--active');
  player1.classList.toggle('player--active');
}

btnNew.addEventListener('click', function () {
  score0.textContent = 0;
  score1.textContent = 0;
  currentScore0.textContent = 0;
  currentScore1.textContent = 0;
  score = [0, 0];
  player0.classList.remove('player--winner');
  player1.classList.remove('player--winner');
  player0.classList.add('player--active');
  player1.classList.remove('player--active');
  activeplayer = 0;
  dice.classList.add('hidden');
  playing = true;
});
