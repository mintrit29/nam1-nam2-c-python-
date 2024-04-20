#Generate a 645 list: 6 numbers, a number belongs to [1, 45]
#Hint: Using list[], Add a element to list: .append(element), Using random library : from random import* and number = randint(1,45)

#Cach 1
from random import randint

random_numbers = []

for _ in range(6):
    number = randint(1, 45)
    random_numbers.append(number)

print(random_numbers)

#Cach 2
from random import *
bo_so = []
while len(bo_so) < 6:
    so_ngau_nhien = randint(1, 45)
    if so_ngau_nhien not in bo_so:
        bo_so.append(so_ngau_nhien)

print("Bo so cua ban: ", bo_so)
bo_so.sort()
print("Bo so cua ban: ", bo_so)

#Dung while loop voi 10 so tu nhien
# Task 1
print("Task 1: First 10 natural numbers using a while loop")
num = 1
while num <= 10:
    print(num, end=", ")
    num += 1
print()

# Task 2
print("\nTask 2: Display numbers from a list based on conditions")
numbers = [12, 75, 150, 180, 145, 525, 50]
result = []

for num in numbers:
    if num % 5 == 0 and num <= 500:
        if num > 150:
            continue
        result.append(num)
    if num > 500:
        break

print("Output:", ", ".join(map(str, result)))

#Task 3
n = 12923
tong = 0
temp = n
while temp > 0:
    # Trích xuất chữ số cuối cùng
    chu_so = temp % 10
    # Thêm chữ số vào tổng
    tong += chu_so
    # Loại bỏ chữ số cuối cùng từ số
    temp //= 10
print("Tổng của các chữ số trong", n, "là:", tong)

#Display Fibonacci series up to n terms
N = int(input("Nhập vào N: "))
n = 1
temp1 = 0
temp2 = 1

while n <= N:
    print(temp2, end=" ")
    tong = temp1 + temp2
    temp1 = temp2
    temp2 = tong
    n += 1

