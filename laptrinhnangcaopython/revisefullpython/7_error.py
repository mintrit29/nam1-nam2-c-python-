n = int(input('Enter numberator'))
d = int(input('Enter denominator'))
try:
    result = n/d
except ZeroDivisionError:
    print('Cannot division by zero!')
else:
    print(result)
finally:
    print('This code will be executed no matter what')