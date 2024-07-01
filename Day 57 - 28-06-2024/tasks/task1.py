def longest_unique_substring(s):
    char_index = {}
    max_length = start = 0

    for i, char in enumerate(s):
        if char in char_index and char_index[char] >= start:
            start = char_index[char] + 1
        char_index[char] = i
        max_length = max(max_length, i - start + 1)
    
    return max_length

s = "abcabcbbaaab"
print(f"Longest substring length of {s}:", longest_unique_substring(s))
