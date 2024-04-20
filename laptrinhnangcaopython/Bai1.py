# Chia lấy nguyên và dư
try:
    a = int(input("Nhập vào số nguyên dương a: "))
    b = int(input("Nhập vào số nguyên dương b: "))
    if (a or b) <= 0:
      raise ValueError("Vui lòng nhập số nguyên dương")
except ValueError as error:
    print(f"Lỗi: {error}")
    exit()

print(f"Đáp án lấy phần nguyên là: {a // b}")
print(f"Đáp án lấy phần dư là: {a % b}")
