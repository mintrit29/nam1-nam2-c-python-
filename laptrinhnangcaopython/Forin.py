#Ví dụ về for...in

#Duyệt từng kí tự trong chuổi
for ki_tu in "Hello world":
    print(ki_tu)

#Duyệt từng kí tự trong mảng/tập hợp
for phan_tu in [1, 6, 3, 5, 12, 34]:
    print(phan_tu)

'''
range(start, stop, step=1): mảng các phần tử bắt đầu từ start, nhỏ hơn (không bằng) stop; các phần tử cách nhau step
'''
print(list(range(10))) #start=0 ==> [0,1,2,3,4,5,6,7,8,9]
print(list(range(2, 10))) #start=0 ==> [2,3,4,5,6,7,8,9]
print(list(range(3, 9, 2))) #start=0 ==> [3,5,7]
print(list(range(15, 5, -3))) #start=0 ==> [15, 12 ,9 ,6]

#Bảng cửu chương
N = int(input("Nhap so nguyen N: "))
for i in range(1,11):
    print(f"{N} x {i:2} = {N*i}")
#Dấu : để format


