def is_prime(n):
    if n <= 1:
        return False
    if n <= 3:
        return True
    if n % 2 == 0 or n % 3 == 0:
        return False
    i = 5
    while i * i <= n:
        if n % i == 0 or n % (i + 2) == 0:
            return False
        i += 6
    return True

def list_primes(up_to):
    primes = []
    for num in range(2, up_to + 1):
        if is_prime(num):
            primes.append(num)
    return primes

up_to = 50
print(f"Prime numbers up to {up_to} :", list_primes(up_to))
