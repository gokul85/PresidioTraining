import re
from datetime import datetime
from itertools import permutations

def is_prime(number):
    if number <= 1:
        return False
    for i in range(2, int(number**0.5) + 1):
        if number % i == 0:
            return False
    return True


print("1) Print hello world\n")
print("Hello World")
print("\n-----------------------------\n")
print("2) Take a name and print greet\n")
name = input("Enter your name: ")
print("Hello "+name)
print("\n-----------------------------\n")
print("3) Take name and gender print greet with salutation\n")
name = input("Enter your name: ")
gender = input("Enter your gender (male/female): ")
salutation = "Mr." if gender.lower() == 'male' else "Ms." if gender.lower() == 'female' else ""
print(f"Hello, {salutation} {name}")
print("\n-----------------------------\n")
print("4) Take name, age, date of birth and phone print details in proper format\n")
name = input("Enter your name: ")
age = input("Enter your age: ")
dob = input("Enter your date of birth: ")
phone = input("Enter your phone number: ")
print(f"Name: {name}\nAge: {age}\nDate of Birth: {dob}\nPhone: {phone}")
print("\n-----------------------------\n")
print("6) Find if the given number is prime\n")
number = int(input("Enter a number: "))
print(f"{number} is {'a prime number' if is_prime(number) else 'not a prime number'}.")
print("\n-----------------------------\n")
print("7) Take 10 numbers and find the average of all the prime numbers in the collection\n")
numbers = [int(input(f"Enter number {i+1}: ")) for i in range(10)]
prime_numbers = [num for num in numbers if is_prime(num)]
if prime_numbers:
    average = sum(prime_numbers) / len(prime_numbers)
    print(f"Average of prime numbers: {average}")
else:
    print("No prime numbers in the input.")
print("\n-----------------------------\n")
print("8) Length of a given input string\n")
input_string = input("Enter a string: ")
print(f"Length of the given string is {len(input_string)}")
print("\n-----------------------------\n")
print("9) Find All Permutations of a given string\n")
input_string = input("Enter a string: ")
permus = [''.join(p) for p in permutations(input_string)]
print(f"Permutations of the given string are: {permus}")
print("\n-----------------------------\n")
print("10) Print a pyramid of starts for the number of rows specified\n")
rows = int(input("Enter the number of rows: "))
for i in range(rows):
        print(' ' * (rows - i - 1) + '*' * (2 * i + 1))
