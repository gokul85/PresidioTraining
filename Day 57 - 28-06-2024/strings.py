# String Concatenation
str1 = "Hello"
str2 = "World"
result = str1 + " " + str2
print(result)

print("-------------------------------------")

# String Repetition
str1 = "Hello"
result = str1 * 3
print(result)

print("-------------------------------------")

# String Slicing
str1 = "Hello World"
print(str1[0:5])
print(str1[6:]) 
print(str1[-5:])

print("-------------------------------------")

# String Length
str1 = "Hello"
print(len(str1))

print("-------------------------------------")

# Convert to Upper/Lower Case
str1 = "Hello World"
print(str1.upper())
print(str1.lower())

print("-------------------------------------")

# Replace
str1 = "Hello World"
print(str1.replace("World", "Python"))

print("-------------------------------------")

# Split
str1 = "Hello World"
print(str1.split())

print("-------------------------------------")

# Check Prefix/Suffix
str1 = "Hello World"
print(str1.startswith("Hello"))
print(str1.endswith("World"))  

print("-------------------------------------")

# Strip Whitespace
str1 = "  Hello World  "
print(str1.strip())

print("-------------------------------------")

# String Formatting using format()
name = "John"
age = 30
print("My name is {} and I am {} years old".format(name, age))

print("-------------------------------------")

# String Formatting using f-Strings
name = "John"
age = 30
print(f"My name is {name} and I am {age} years old")

print("-------------------------------------")

# Find a Substring
str1 = "Hello World"
print(str1.find("World"))
print(str1.find("Python"))

print("-------------------------------------")

# Join a List into a String
list1 = ["Hello", "World"]
print(" ".join(list1))
