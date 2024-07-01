import random

def generate_secret_word():
    words = ["plant", "table", "apple", "grape", "smart"]
    return random.choice(words)

def get_cows_and_bulls(secret_word, guess):
    cows = bulls = 0
    for i in range(len(secret_word)):
        if guess[i] == secret_word[i]:
            bulls += 1
        elif guess[i] in secret_word:
            cows += 1
    return cows, bulls

def cow_and_bull_game():
    secret_word = generate_secret_word()
    attempts = 0
    print("Welcome to the Cow and Bull game!")

    while True:
        guess = input("Enter your guess: ")
        if len(guess) != len(secret_word):
            print(f"Guess should be {len(secret_word)} letters long.")
            continue

        attempts += 1
        cows, bulls = get_cows_and_bulls(secret_word, guess)
        print(f"Cows: {cows}, Bulls: {bulls}")

        if bulls == len(secret_word):
            print(f"Congratulations! You've guessed the word '{secret_word}' in {attempts} attempts.")
            break

cow_and_bull_game()
