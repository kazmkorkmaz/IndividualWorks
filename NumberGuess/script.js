'use strict';
let score = 20;

if (localStorage.getItem('highScore') === null) {
  localStorage.setItem('highScore', 0);
} else {
  localStorage.setItem('highScore', localStorage.getItem('highScore'));
}
document.querySelector('.highscore').textContent =
  localStorage.getItem('highScore');
const secretNumber = Math.trunc(Math.random() * 20 + 1);
const messageContent = function (message) {
  document.querySelector('.message').textContent = message;
};
document.querySelector('.check').addEventListener('click', function () {
  const guessNumber = Number(document.querySelector('.guess').value);

  document.querySelector('.label-score').textContent = '💯 Score:' + score;
  if (score >= 1) {
    if (!guessNumber) {
      messageContent('Please type a number');
    } else if (guessNumber > 20 || guessNumber < 0) {
      messageContent('Your number should be between 1 and 20');

      score--;
    } else if (guessNumber === secretNumber) {
      messageContent('Good Job');
      document.querySelector('body').style.backgroundColor = '#60b347';
      document.querySelector('.number').textContent = secretNumber;
      let highscore = localStorage.getItem('highScore');
      if (score > highscore) {
        localStorage.setItem('highScore', score);
        document.querySelector('.highscore').textContent =
          localStorage.getItem('highScore');
      }
    } else if (guessNumber > secretNumber) {
      messageContent('More low');
      score--;
    } else if (secretNumber > guessNumber) {
      messageContent('More high');
      score--;
    }
  } else {
    messageContent('Such a Loser!!');
    document.querySelector('body').style.backgroundColor = '#FF0000';
  }
});

document.querySelector('.again').addEventListener('click', function () {
  location.reload();
});
document.querySelector('.restart').addEventListener('click', function () {
  localStorage.setItem('highScore', 0);
  location.reload();
});
