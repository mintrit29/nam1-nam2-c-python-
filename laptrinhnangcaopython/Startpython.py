print('Hello world')

#variable
x = 5 
y = x * 2
greet = 'Hello world wide web'
name = ' Triết'
print(x, y)
print(greet + name*3)
print(greet.split(' '))
print('wide' in greet)
print('w3de' in greet)

#array/list
numbers = [1, 2, 3, 4, 5, 6, 7]
names = ['Triet','Skylar Vox', 'Sweetie Fox', 'Yua Mikami']
numbers.append(10)
print(numbers)
print(numbers[2])
print(10 in numbers)
print(names)

#if else
age = 15
if age < 18:
    print('You are too young'+ name)
else:
    print('Welcome' + name)
    
#vòng lặp
i = 0
while i < 5:
    print('FBI warning!!!')
    i= i + 1

web_phim_hay = ['spankbang','missav','210z','stripchat']
for web in web_phim_hay:
    print(web)

#function
def tinh_tong(n):
    tong = 0
    i = 1
    while i <= n:
        tong = tong + i
        i = i + 1
    return tong
print(tinh_tong(4))