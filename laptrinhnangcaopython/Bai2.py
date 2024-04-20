try:
    N = int(input("Nhập vào số nguyên dương N: "))
    if (N <= 0) and (N >= 100):
      raise ValueError("Vui lòng nhập đúng yêu cầu")

except ValueError as error:
   print(f"Lỗi {error}")
   exit()
n = N//10
p = N%10
print(f"Tổng các chữ số là", {n+p})