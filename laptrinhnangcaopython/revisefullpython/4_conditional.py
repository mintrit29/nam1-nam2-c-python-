#Basic condition
age = int(input('Type your age here: '))
name = 'Vincent'
if age >=18:
    print(f'Welcome {name}')
else:
    print(f'You are too young {name}')

#Elif condition
marks = int(input('Enter your marks'))
if marks >= 90:
    print('A')
elif marks >= 70:
    print('B')
elif marks >= 60:
    print('C')
else:
    print('D')

#Nested if condition
a = 10
b = 20
if a>5:
    if b>15:
        print('A is greater than 5 and B is greater than 15')
    else:
        print('A is greater than 5 but B is less than 15')
else:
    print('A is less than 5')

#Range function
numbers = list(range(10))#0->9
numbers1 = list(range(1,11))#1->10
numbers2 = list(range(1,101,3))
print(numbers)
print(numbers1)
print(numbers2)

#For loop
fruits = ['Apple','Mango','Banana','Orange']
people = {'John':32,'Rob':40,'Tim':20}
for x in people:
    print(x)
    print(people[x])

#While loop
counter = 0
while counter <= 10:
    print(counter)
    if counter == 5:
        break
    counter += 1

#Continue statement
while counter <=10:
    counter += 1
    if counter == 5:
        continue
    print(counter)

#Adding item to cart using For loop
cart = []
n = int(input('Type the number of items you want to add: '))
for x in range(n):
    item = input('Type the item you want to add: ')
    cart.append(item)
    print(cart)

#Adding item to cart using While loop
cart = []
x = 0
n = int(input('Type the number of items you want to add: '))
while x < n:
    item = input('Type the item you want to add: ')
    cart.append(item)
    print(cart)
    x += 1
#Adding item to cart using While loop 2
cart =[]
while True:
    choice = input('Do you want to add item? ')
    if choice == 'yes':
        item = input('Type the item you want to add: ')
        cart.append(item)
        print(cart)
    else:
        break